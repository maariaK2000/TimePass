using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entities
{
    public partial class Adaa : DbContext
    {
        public Adaa()
            : base("name=Adaa")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<customercart> customercarts { get; set; }
        public virtual DbSet<historycart> historycarts { get; set; }
        public virtual DbSet<myadmin> myadmins { get; set; }
        public virtual DbSet<myregister> myregisters { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<registerlocation> registerlocations { get; set; }
        public virtual DbSet<storelocation> storelocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.SubcategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<myadmin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<myadmin>()
                .Property(e => e.AdminPwd)
                .IsUnicode(false);

            modelBuilder.Entity<myregister>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<myregister>()
                .Property(e => e.RegisterPwd)
                .IsUnicode(false);

            modelBuilder.Entity<myregister>()
                .Property(e => e.RegisterContact)
                .IsUnicode(false);

            modelBuilder.Entity<myregister>()
                .HasMany(e => e.customercarts)
                .WithRequired(e => e.myregister)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<myregister>()
                .HasMany(e => e.historycarts)
                .WithRequired(e => e.myregister)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<myregister>()
                .HasMany(e => e.registerlocations)
                .WithRequired(e => e.myregister)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.PrdName)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.PrdPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .HasMany(e => e.customercarts)
                .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.historycarts)
                .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.storelocations)
                .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<registerlocation>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<registerlocation>()
                .Property(e => e.UserLocation)
                .IsUnicode(false);

            modelBuilder.Entity<storelocation>()
                .Property(e => e.StoreLocation1)
                .IsUnicode(false);
        }
    }
}
