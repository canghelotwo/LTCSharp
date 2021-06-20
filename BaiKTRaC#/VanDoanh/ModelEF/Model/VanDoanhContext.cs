namespace ModelEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VanDoanhContext : DbContext
    {
        public VanDoanhContext()
            : base("name=VanDoanhContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.PassWord)
                .IsUnicode(false);
        }
    }
}
