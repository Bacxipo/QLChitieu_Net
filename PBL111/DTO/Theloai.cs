namespace PBL111.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theloai")]
    public partial class Theloai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Theloai()
        {
            Giaodiches = new HashSet<Giaodich>();
        }

        public int theloaiID { get; set; }

        [Required]
        [StringLength(50)]
        public string nameTL { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giaodich> Giaodiches { get; set; }
    }
}
