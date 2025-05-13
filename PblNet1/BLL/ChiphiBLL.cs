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
    public class ChiphiBLL
    {
        private readonly UserBLL _userBLL;
        public ChiphiBLL()
        {
            _userBLL = new UserBLL();
        }
        public bool AddGD(Giaodich expense, int currentUserid)
        {
            if (expense.userID != currentUserid && !_userBLL.HasPermission(currentUserid, "manager"))
                return false;
            using (var context = new ExpenseDbContext())
            {
                expense.ngaytao = DateTime.Now;
                context.Giaodichs.Add(expense);
                context.SaveChanges();
                return true;
            }
        }
        public bool updateGD(Giaodich giaodich, int currrentUserid)
        {
            using (var context = new ExpenseDbContext())
            {
                var existingGD = context.Giaodichs.Find(giaodich.giaodichID);
                if (existingGD == null)
                    return false;
                // Kiểm tra quyền sửa đổi
                if (existingGD.userID != currrentUserid && !_userBLL.HasPermission(currrentUserid, "manager"))
                    return false;
                // Cập nhật thông tin giao dịch
                existingGD.soluong = giaodich.soluong;
                existingGD.ngayGD = giaodich.ngayGD;
                existingGD.Description = giaodich.Description;
                existingGD.diachi = giaodich.diachi;
                context.SaveChanges();
                return true;
            }
        }
        public bool deleteGD(int giaodichID, int currentUserid)
        {
            using (var context = new ExpenseDbContext())
            {
                var giaodich = context.Giaodichs.Find(giaodichID);
                // Kiểm tra xem giao dịch có tồn tại không
                if (giaodich == null)
                    return false;
                // Kiểm tra quyền xóa
                if (giaodich.userID != currentUserid && !_userBLL.HasPermission(currentUserid, "manager"))
                    return false;
                context.Giaodichs.Remove(giaodich);
                context.SaveChanges();
                return true;
            }
        }
        /// Lấy danh sách giao dịch của người dùng
        public List<Giaodich> GetUserExpenses(int userId, DateTime? ngayBD = null, DateTime? ngayKT = null)
        {
            using (var context = new ExpenseDbContext())
            {
                var query = context.Giaodichs
                    .Include(e => e.Theloai)
                    .Include(e => e.userID == userId);
                // Lọc theo ngày bắt đầu nếu có
                if (ngayBD.HasValue)
                {
                    query = query.Where(g => g.ngayGD >= ngayBD.Value);
                }
                // Lọc theo ngày kết thúc nếu có
                if (ngayKT.HasValue)
                {
                    query = query.Where(g => g.ngayGD <= ngayKT.Value);
                }
                return query.Where(g => g.userID == userId).ToList();
            }
        }
        /// Lấy danh sách tất cả giao dịch
        public List<Giaodich> GetAllExpenses(int userId,DateTime? ngayBD = null,DateTime? ngayKT = null)
        {
            // Kiểm tra quyền truy cập
            if (!_userBLL.HasPermission(userId, "manager"))
                return null;
            using (var context = new ExpenseDbContext())
            {
                // Lấy danh sách giao dịch
                var query = context.Giaodichs
                    .Include(e => e.Theloai)
                    .Include(e => e.userID == userId);
                // Lọc theo ngày bắt đầu nếu có
                if (ngayBD.HasValue)
                    query = query.Where(e => e.ngayGD >= ngayBD.Value);
                // Lọc theo ngày kết thúc nếu có
                if (ngayKT.HasValue)
                    query = query.Where(e => e.ngayGD <= ngayKT.Value);
                return query.OrderByDescending(e =>e.ngayGD).ToList();
            }
        }
    }
}
