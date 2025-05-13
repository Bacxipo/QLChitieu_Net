using PBL111.BLL;
using PBL111.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL111.DAL
{
    public class ChiphiDAL
    {
        public bool AddGD(Giaodich expense, int currentUserid)
        {
            if (expense.userID != currentUserid)
                return false;
            using (var context = new QLTC())
            {
                expense.ngaytao = DateTime.Now;
                context.Giaodiches.Add(expense);
                context.SaveChanges();
                return true;
            }
        }

        public bool updateGD(Giaodich giaodich, int currrentUserid)
        {
            using (var context = new QLTC())
            {
                var existingGD = context.Giaodiches.Find(giaodich.giaodichID);
                if (existingGD == null)
                    return false;
                if (existingGD.userID != currrentUserid)
                    return false;
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
            using (var context = new QLTC())
            {
                var giaodich = context.Giaodiches.Find(giaodichID);
                if (giaodich == null)
                    return false;
                if (giaodich.userID != currentUserid)
                    return false;
                context.Giaodiches.Remove(giaodich);
                context.SaveChanges();
                return true;
            }
        }

        public List<Giaodich> GetUserExpenses(int userId, DateTime? ngayBD = null, DateTime? ngayKT = null)
        {
            using (var context = new QLTC())
            {
                var query = context.Giaodiches
                    .Include("Theloai")
                    .Where(g => g.userID == userId);

                if (ngayBD.HasValue)
                    query = query.Where(g => g.ngayGD >= ngayBD.Value);

                if (ngayKT.HasValue)
                    query = query.Where(g => g.ngayGD <= ngayKT.Value);

                return query.ToList();
            }
        }

        public List<Giaodich> GetAllExpenses(int userId, DateTime? ngayBD = null, DateTime? ngayKT = null)
        {
            using (var context = new QLTC())
            {
                var query = context.Giaodiches
                    .Include("Theloai")
                    .Where(e => e.userID == userId);

                if (ngayBD.HasValue)
                    query = query.Where(e => e.ngayGD >= ngayBD.Value);

                if (ngayKT.HasValue)
                    query = query.Where(e => e.ngayGD <= ngayKT.Value);

                return query.OrderByDescending(e => e.ngayGD).ToList();
            }
        }

        public Dictionary<string, decimal> GetMonthlyExpenses(int userId, DateTime month)
        {
            using (var context = new QLTC())
            {
                var startDate = new DateTime(month.Year, month.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var monthlyExpenses = context.Giaodiches
                    .Where(e => e.userID == userId && e.ngayGD >= startDate && e.ngayGD <= endDate)
                    .GroupBy(e => e.Theloai.nameTL)
                    .Select(g => new
                    {
                        nameTL = g.Key,
                        TotalAmount = g.Sum(e => e.soluong)
                    })
                    .ToDictionary(g => g.nameTL, g => g.TotalAmount);

                return monthlyExpenses ?? new Dictionary<string, decimal>();
            }
        }
    }
}
