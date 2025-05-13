namespace PBL111.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ngansach")]
    public partial class Ngansach
    {
        public int NgansachID { get; set; }

        public int userID { get; set; }

        public decimal Soluong { get; set; }

        public DateTime NgayBD { get; set; }

        public DateTime NgayKT { get; set; }

        public DateTime? Ngaytao { get; set; }

        public virtual user user { get; set; }
    }
}
