using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using PBL111.DTO;

namespace PBL111.DAL
{
    public partial class QLTC : DbContext
    {
        public QLTC()
            : base("name=QLTC")
        {
        }

        public virtual DbSet<Giaodich> Giaodiches { get; set; }
        public virtual DbSet<Ngansach> Ngansaches { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Theloai> Theloais { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("roleID").MapRightKey("userID"));

            modelBuilder.Entity<Theloai>()
                .HasMany(e => e.Giaodiches)
                .WithRequired(e => e.Theloai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.Giaodiches)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.Ngansaches)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
