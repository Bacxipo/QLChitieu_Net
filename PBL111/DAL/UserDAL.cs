using PBL111.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text; 
using System.Threading.Tasks;

namespace PBL111.DAL
{
   public class UserDAL
    {
        public user Authenticate(string username, string password)
        {
            using (var context = new QLTC())
            { 
                var hashedPassword = HashPassword(password).ToString();
                
                var user = context.users
                    .Include("Roles")
                    .FirstOrDefault(u => u.username == username && u.password == hashedPassword);
                return user;
            }
        }
        public bool Register(user newUser, string plainPassword, int roledID = 9)
        {
            using (var context = new QLTC())
            {
                if (context.users.Any(u => u.username == newUser.username))
                {
                    return false;
                }
                
                newUser.password = (string)HashPassword(plainPassword).ToString();
                newUser.CreateDate = DateTime.Now;
                newUser.IsActive = true;


                var role = context.Roles.Find(roledID);
                if (role != null)
                {
                    newUser.Roles.Add(role);
                    context.SaveChanges();
                }

                context.users.Add(newUser);
                context.SaveChanges();
                return true;
            }
        }
        public bool ChangePassword(int userID, string oldPassword, string newPassword)
        {
            using (var context = new QLTC())
            {
                var user = context.users.Find(userID);
                if (user == null)
                {
                    Console.WriteLine("Người dùng không tồn tại.");
                    return false;
                }

                var hashedOldPassword = HashPassword(oldPassword);
                Console.WriteLine($"Mật khẩu cũ (người dùng nhập): {oldPassword}");
                Console.WriteLine($"Mật khẩu cũ (đã mã hóa): {hashedOldPassword}");
                Console.WriteLine($"Mật khẩu trong cơ sở dữ liệu: {user.password}");

                if (!string.Equals(user.password, hashedOldPassword))
                {
                    Console.WriteLine("Mật khẩu cũ không khớp.");
                    return false;
                }

                user.password = (string)HashPassword(newPassword);
                context.SaveChanges();
                Console.WriteLine("Đổi mật khẩu thành công.");
                return true;
            }
        }

        private object HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        public user GetUserByid(int userID)
        {
            using (var context = new QLTC())
            {
                return context.users.FirstOrDefault(u => u.userID == userID);
            }
        }
        public List<user> GetAllUsers()
        {
            using (var context = new QLTC())
            {
                return context.users.ToList();
            }
        }
        public bool UpdateUser(user updatedUser)
        {
            using (var context = new QLTC())
            {
                var existingUser = context.users.FirstOrDefault(u => u.userID == updatedUser.userID);
                if (existingUser == null)
                {
                    return false;
                }

                existingUser.Fullname = updatedUser.Fullname;
                existingUser.username = updatedUser.username;
                existingUser.Email = updatedUser.Email;
                existingUser.password = updatedUser.password;
                existingUser.IsActive = updatedUser.IsActive;

                context.SaveChanges();
                return true;
            }
        }
        public bool HasPermission(int userId, string permission)
        {
            using (var context = new QLTC())
            {
                var user = context.users
                    .Include("Roles")
                    .FirstOrDefault(u => u.userID == userId);

                if (user == null)
                    return false;


                switch (permission.ToLower())
                {
                    case "admin":
                        return user.Roles.Any(r => r.rolename == "Admin");
                    case "user":
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var context = new QLTC())
            {
                var user = context.users.FirstOrDefault(u => u.userID == userId);
                if (user == null)
                {
                    return false;
                }
                context.users.Remove(user);
                context.SaveChanges();
                return true;
            }
        }
    }
}
