using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PblNet1.DTO;
using System.Data.Entity;
namespace PblNet1.DAL
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext() : base("name=ExpenseDbContext")
        {
        }
        public DbSet<Giaodich> Giaodichs { get; set; }
        public DbSet<Theloai> Theloais { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Ngansach> Ngansach { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("userID");
                    m.MapRightKey("roleID");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
