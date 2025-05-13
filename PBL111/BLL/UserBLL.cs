using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL111.DAL;
using PBL111.DTO;
using System.Data.Entity;
using System.Security.Cryptography;

namespace PBL111.BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }

        public user Authenticate(string username, string password)
        {
            return _userDAL.Authenticate(username, password);
        }

        public bool Register(user newUser, string plainPassword, int roledID = 9)
        {
            return _userDAL.Register(newUser, plainPassword, roledID);
        }

        public bool ChangePassword(int userID, string oldPassword, string newPassword)
        {
            return _userDAL.ChangePassword(userID, oldPassword, newPassword);
        }

        public user GetUserByid(int userID)
        {
            return _userDAL.GetUserByid(userID);
        }

        public List<user> GetAllUsers()
        {
            return _userDAL.GetAllUsers();
        }

        public bool UpdateUser(user updatedUser)
        {
            return _userDAL.UpdateUser(updatedUser);
        }

        public bool HasPermission(int userId, string permission)
        {
            return _userDAL.HasPermission(userId, permission);
        }

        public bool DeleteUser(int userId)
        {
            return _userDAL.DeleteUser(userId);
        }
    }

}
