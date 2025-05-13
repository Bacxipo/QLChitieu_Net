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
    public class NgansachBLL
    {
        public readonly UserBLL _userBLL;
        
        public NgansachBLL()
        {
            _userBLL = new UserBLL();
        }
       
        public bool setupNgansach(Ngansach ngansach, int currentUserid)
        { // Kiểm tra quyền thêm ngân sách
            if (ngansach.userID != currentUserid && !_userBLL.HasPermission(currentUserid, "manager"))
                return false;
            // Kiểm tra xem ngân sách đã tồn tại chưa
            using (var context = new ExpenseDbContext())
            {
                ngansach.Ngaytao = DateTime.Now;
                context.Ngansach.Add(ngansach);
                context.SaveChanges();
                return true;

            }
               
        }
        // Cập nhật ngân sách
        public bool updateNgansach(Ngansach ngansach, int currentUserid)
        {
            using (var context = new ExpenseDbContext())
            {
                var existingNgansach = context.Ngansach.Find(ngansach.NgansachID);
                if (existingNgansach == null)
                    return false;
                // Kiểm tra quyền sửa đổi
                if (existingNgansach.userID != currentUserid && !_userBLL.HasPermission(currentUserid, "manager"))
                    return false;
                // Cập nhật thông tin ngân sách
                existingNgansach.Soluong = ngansach.Soluong;
                existingNgansach.NgayBD = ngansach.NgayBD;
                existingNgansach.NgayKT = ngansach.NgayKT;
                existingNgansach.theloaiID = ngansach.theloaiID;

                context.SaveChanges();
                return true;
            }
        }
        // Xóa ngân sách
        public List<Ngansach> GetUserNgansach(int userId, DateTime? asOfDate = null, DateTime? ngayKT = null)
        {
            using (var context = new ExpenseDbContext())
            {
                var date = asOfDate ?? DateTime.Now;
                return context.Ngansach
                    .Include("Thể loại")
                    .Where(e => e.userID == userId && e.NgayBD <= date && e.NgayKT >= date)
                    .ToList();

            }
        }
        // Lấy danh sách ngân sách của người dùng
        public decimal GetTotalNgansach(int ngansachId, int currentUserId)
        {
            using (var context = new ExpenseDbContext())
            {
                var ngansach = context.Ngansach.Find(ngansachId);
                if (ngansach == null)
                    return 0;
                if(ngansach.userID != currentUserId && !_userBLL.HasPermission(currentUserId, "manager"))
                    return 0;
                var total = context.Giaodichs
                    .Where(e => e.theloaiID == ngansach.theloaiID &&
                    e.ngayGD >= ngansach.NgayBD &&
                    e.ngayGD <= ngansach.NgayKT);
                return 0;
            }
        }
    }
}
