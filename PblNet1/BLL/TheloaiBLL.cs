using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PblNet1.DAL;
using PblNet1.DTO;
using System.Data.Entity;

namespace PblNet1.BLL
{
    public class TheloaiBLL
    {
        private readonly UserBLL _userBLL;
        public TheloaiBLL()
        {
            _userBLL = new UserBLL();
        }
        public List<Theloai> GetAllTheloai()
        {
            using (var context = new ExpenseDbContext())
            {
                return context.Theloais.ToList();
            }
        }
        public bool AddTheloai(Theloai theloai, int currentUserid)
        {
            // Kiểm tra quyền thêm loại chi phí
            if (!_userBLL.HasPermission(currentUserid, "manager"))
                return false;
            // Kiểm tra xem loại chi phí đã tồn tại chưa
            using (var context = new ExpenseDbContext())
            {
                context.Theloais.Add(theloai);
                context.SaveChanges();
                return true;
            }
        }
        public bool UpdateTheloai(Theloai theloai, int currentUserid)
        {
            // Kiểm tra quyền sửa loại chi phí
            if (!_userBLL.HasPermission(currentUserid, "manager"))
                return false;
            using (var context = new ExpenseDbContext())
            {
                var existingTheloai = context.Theloais.Find(theloai.theloaiID);
                if (existingTheloai == null)
                    return false;
                existingTheloai.nameTL = theloai.nameTL;
                existingTheloai.description = theloai.description;
                existingTheloai.ParenttheloaiID = theloai.ParenttheloaiID;
               
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteTheloai(int theloaiID, int currentUserid)
        {
            // Kiểm tra quyền xóa loại chi phí
            if (!_userBLL.HasPermission(currentUserid, "manager"))
                return false;
            using (var context = new ExpenseDbContext())
            {
                // Kiểm tra xem loại chi phí có tồn tại không
                if (context.Giaodichs.Any(e => e.theloaiID == theloaiID))
                        return false;
                // Kiểm tra xem loại chi phí có giao dịch nào không
                var theloai = context.Theloais.Find(theloaiID);
                if (theloai == null)
                    return false;
                context.Theloais.Remove(theloai);
                context.SaveChanges();
                return true;
            }
        }
    }
}
