namespace PBL111.DTO

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giaodich")]
    public partial class Giaodich
    {
        public int giaodichID { get; set; }

        public int userID { get; set; }

        public int theloaiID { get; set; }

        public decimal soluong { get; set; }

        public DateTime ngayGD { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        public DateTime? ngaytao { get; set; }

        public virtual Theloai Theloai { get; set; }

        public virtual user user { get; set; }
    }
}
