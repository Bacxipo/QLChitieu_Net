using System;
using System.Collections.Generic;
using PBL111.DAL;
using PBL111.DTO;

namespace PBL111.BLL
{
    public class NganSachBLL
    {
        private readonly NganSachDAL _ngansachDAL;

        public NganSachBLL()
        {
            _ngansachDAL = new NganSachDAL();
        }

        public bool setupNgansach(Ngansach ngansach, int currentUserid)
        {
            return _ngansachDAL.setupNgansach(ngansach, currentUserid);
        }

        public bool updateNgansach(Ngansach ngansach, int currentUserid)
        {
            return _ngansachDAL.updateNgansach(ngansach, currentUserid);
        }

        public List<Ngansach> GetUserNgansach(int userId, DateTime? asOfDate = null, DateTime? ngayKT = null)
        {
            return _ngansachDAL.GetUserNgansach(userId, asOfDate, ngayKT);
        }

        public decimal GetTotalNgansach(int ngansachId, int currentUserId)
        {
            return _ngansachDAL.GetTotalNgansach(ngansachId, currentUserId);
        }
    }
}