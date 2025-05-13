using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PblNet1.DAL;
using PblNet1.DTO;
using System.Data.Entity;
using System.Security.Cryptography;

namespace PblNet1.BLL
{
    public class UserBLL
    {
        public user Authenticate(string username, string password)
        {
            using (var context = new ExpenseDbContext())
            { // Băm mật khẩu
                var hashedPassword = HashPassword(password);
                // Tìm người dùng trong cơ sở dữ liệu
                var user = context.users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.username == username && u.password == password);
                return user;
            }
        }
        public bool Register(user newUser, string plainPassword, int roledID = 9)
        {
            using (var context = new ExpenseDbContext())
            {
                if (context.users.Any(u => u.username == newUser.username))
                {
                    return false; // Tên người dùng đã tồn tại
                }
                // Băm mật khẩu
                newUser.password = (string)HashPassword(plainPassword);
                newUser.CreateDate = DateTime.Now;
                newUser.IsActive = true;

                // Thêm vai trò cho người dùng
                var role = context.roles.Find(roledID);
                if (role != null)
                {
                    newUser.Roles.Add(role);
                    context.SaveChanges();
                }

                context.users.Add(newUser);
                context.SaveChanges();
                return true; // Đăng ký thành công
            }
        }
        public bool ChangePassword(int userID, string oldPassword, string newPassword)
        {
            using (var context = new ExpenseDbContext())
            {
                var user = context.users.Find(userID);
                if (user != null || user.password != (string)HashPassword(oldPassword) ){ return false; }
                user.password = (string)HashPassword(newPassword);
                context.SaveChanges();
                return true; // Đổi mật khẩu thành công
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
        public bool HasPermission(int userId, string permission)
        {
            using (var context = new ExpenseDbContext())
            {
                var user = context.users
                    .Include("Roles")
                    .FirstOrDefault(u => u.userID == userId);

                if (user == null)
                    return false;

                // Kiểm tra xem người dùng có vai trò yêu cầu không
                switch (permission.ToLower())
                {
                    case "admin":
                        return user.Roles.Any(r => r.rolename == "Admin");
                    case "manager":
                        return user.Roles.Any(r => r.rolename == "Admin" || r.rolename == "Manager");
                    case "user":
                        return true; // Tất cả người dùng đã xác thực đều có quyền này
                    default:
                        return false;
                }
            }
        } 
    }

}
