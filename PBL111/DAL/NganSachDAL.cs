using PBL111.BLL;
using PBL111.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL111.DAL
{
    public class NganSachDAL
    {
        public NganSachDAL() { }

        public bool setupNgansach(Ngansach ngansach, int currentUserid)
        {
            if (ngansach.userID != currentUserid)
                return false;
            using (var context = new QLTC())
            {
                ngansach.Ngaytao = DateTime.Now;
                context.Ngansaches.Add(ngansach);
                context.SaveChanges();
                return true;
            }
        }

        public bool updateNgansach(Ngansach ngansach, int currentUserid)
        {
            using (var context = new QLTC())
            {
                var existingNgansach = context.Ngansaches.Find(ngansach.NgansachID);
                if (existingNgansach == null)
                    return false;
                if (existingNgansach.userID != currentUserid)
                    return false;
                existingNgansach.Soluong = ngansach.Soluong;
                existingNgansach.NgayBD = ngansach.NgayBD;
                existingNgansach.NgayKT = ngansach.NgayKT;
                context.SaveChanges();
                return true;
            }
        }

        public List<Ngansach> GetUserNgansach(int userId, DateTime? asOfDate = null, DateTime? ngayKT = null)
        {
            using (var context = new QLTC())
            {
                var query = context.Ngansaches.Where(n => n.userID == userId);
                if (asOfDate.HasValue)
                    query = query.Where(n => n.NgayBD >= asOfDate.Value);
                if (ngayKT.HasValue)
                    query = query.Where(n => n.NgayKT <= ngayKT.Value);
                return query.ToList();
            }
        }

        public decimal GetTotalNgansach(int ngansachId, int currentUserId)
        {
            using (var context = new QLTC())
            {
                var ngansach = context.Ngansaches.Find(ngansachId);
                if (ngansach == null)
                    return 0;
                if (ngansach.userID != currentUserId)
                    return 0;
                return 0;
            }
        }
    }
}
