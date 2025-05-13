using PBL111.BLL;
using PBL111.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL111.DAL
{
    public class TheloaiDAL
    {
        private readonly UserDAL _UserDAL;
        public TheloaiDAL()
        {
            _UserDAL = new UserDAL();
        }
        public List<Theloai> GetAllTheloai()
        {
            using (var context = new QLTC())
            {
                return context.Theloais.ToList();
            }
        }
        public bool AddTheloai(Theloai theloai, int currentUserid)
        {
            if (!_UserDAL.HasPermission(currentUserid, "manager"))
                return false;
            using (var context = new QLTC())
            {
                if (context.Theloais.Any(t => t.nameTL == theloai.nameTL))
                    return false;

                context.Theloais.Add(theloai);
                context.SaveChanges();
                return true;
            }
        }
        public bool UpdateTheloai(Theloai theloai, int currentUserid)
        {
            if (!_UserDAL.HasPermission(currentUserid, "manager"))
                return false;
            using (var context = new QLTC())
            {
                var existingTheloai = context.Theloais.Find(theloai.theloaiID);
                if (existingTheloai == null)
                    return false;
                existingTheloai.nameTL = theloai.nameTL;
                existingTheloai.description = theloai.description;

                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteTheloai(int theloaiID, int currentUserid)
        {
            if (!_UserDAL.HasPermission(currentUserid, "manager"))
                return false;
            using (var context = new QLTC())
            {
                if (context.Giaodiches.Any(e => e.theloaiID == theloaiID))
                    return false;
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
