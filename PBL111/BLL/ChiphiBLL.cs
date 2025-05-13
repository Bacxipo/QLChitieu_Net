using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL111.DAL;
using PBL111.DTO;
using System.Data.Entity;

namespace PBL111.BLL
{
    public class ChiphiBLL
    {
        private readonly ChiphiDAL _chiphiDAL;

        public ChiphiBLL()
        {
            _chiphiDAL = new ChiphiDAL();
        }

        public bool AddGD(Giaodich expense, int currentUserid)
        {
            return _chiphiDAL.AddGD(expense, currentUserid);
        }

        public bool updateGD(Giaodich giaodich, int currentUserid)
        {
            return _chiphiDAL.updateGD(giaodich, currentUserid);
        }

        public bool deleteGD(int giaodichID, int currentUserid)
        {
            return _chiphiDAL.deleteGD(giaodichID, currentUserid);
        }

        public List<Giaodich> GetUserExpenses(int userId, DateTime? ngayBD = null, DateTime? ngayKT = null)
        {
            return _chiphiDAL.GetUserExpenses(userId, ngayBD, ngayKT);
        }

        public List<Giaodich> GetAllExpenses(int userId, DateTime? ngayBD = null, DateTime? ngayKT = null)
        {
            return _chiphiDAL.GetAllExpenses(userId, ngayBD, ngayKT);
        }

        public Dictionary<string, decimal> GetMonthlyExpenses(int userId, DateTime month)
        {
            return _chiphiDAL.GetMonthlyExpenses(userId, month);
        }
    }
}
