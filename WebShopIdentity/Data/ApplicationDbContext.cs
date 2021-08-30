using WebShopIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShopIdentity.ViewModels;
using WebShopIdentity.Models.Stores;
using WebShopIdentity.Models.Orders;

namespace WebShopIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cties { get; set; }

        //------------------------
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreRow> StoreRows { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        public DbSet<VW_ShopHistory> VW_ShopHistory { get; set; }
        public DbSet<VW_Stores> VW_Stores { get; set; }
        public DbSet<VW_StoreRows> VW_StoreRows { get; set; }
        public DbSet<VW_StoreBalance> VW_StoreBalance { get; set; }
        public DbSet<VW_UserCity> VW_UserCity { get; set; }
        

        //------------------------

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Country>(entity =>
            //{
            //    entity.Property(e => e.CountryName)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            base.OnModelCreating(builder);

            //--------------------------
            builder.Entity<VW_ShopHistory>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VW_ShopHistory");
            });
            builder.Entity<VW_Stores>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VW_Stores");
            });
            builder.Entity<VW_StoreRows>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VW_StoreRows");
            });
            builder.Entity<VW_StoreBalance>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VW_StoreBalance"); 
            });
            
            builder.Entity<VW_UserCity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VW_UserCity");
            });



            builder.Entity<ProductCategory>().HasData(new ProductCategory { ProductCategoryID = 1, Name = "Spel" });
            builder.Entity<ProductCategory>().HasData(new ProductCategory { ProductCategoryID = 2, Name = "Dator&Tillbehör" });
            builder.Entity<ProductCategory>().HasData(new ProductCategory { ProductCategoryID = 3, Name = "TV&Ljud" });
            builder.Entity<ProductCategory>().HasData(new ProductCategory { ProductCategoryID = 4, Name = "Hem&Hälsa" });

            builder.Entity<Product>().HasData(new Product { ProductID = 1, Name = "BärbarHuawei", ProductPrice = 8000, ProductCategoryID = 2, PhotoName = "BärbarHuawei.png" });
            builder.Entity<Product>().HasData(new Product { ProductID = 2, Name = "ElCykel", ProductPrice = 10000, ProductCategoryID = 1, PhotoName = "ElCykel.png" });
            builder.Entity<Product>().HasData(new Product { ProductID = 3, Name = "GamingDator", ProductPrice = 3500, ProductCategoryID = 2, PhotoName = "GamingDator.png" });
            builder.Entity<Product>().HasData(new Product { ProductID = 4, Name = "GamingSkärm", ProductPrice = 2500, ProductCategoryID = 2, PhotoName = "GamingSkärm.png" });
            builder.Entity<Product>().HasData(new Product { ProductID = 5, Name = "Playstation4", ProductPrice = 550, ProductCategoryID = 1, PhotoName = "Playstation4.png" });
            builder.Entity<Product>().HasData(new Product { ProductID = 6, Name = "Playstation5", ProductPrice = 800, ProductCategoryID = 1, PhotoName = "Playstation5.png" });

            builder.Entity<DocumentType>().HasData(new DocumentType { Id = 1, DocumentName = "receipt" });
            builder.Entity<DocumentType>().HasData(new DocumentType { Id = 2, DocumentName = "Remittance" });

            builder.Entity<OrderState>().HasData(new OrderState { Id = 1, StateName = "Delivered" });
            builder.Entity<OrderState>().HasData(new OrderState { Id = 2, StateName = "Remains" });
            //---------------------------


            builder.Entity<Country>().HasData(
               new Country { Id = 1, CountryName = "Sweden" },
               new Country { Id = 2, CountryName = "Norway" }
               );
            builder.Entity<City>().HasData(
                new City { Id = 1, CityName = "Stockholm", CountryId = 1 },
                new City { Id = 2, CityName = "Göteborg", CountryId = 1 },
                new City { Id = 3, CityName = "Bergen", CountryId = 2 }
                );
            string roleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = roleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = roleId
                });
             var roleIdc = Guid.NewGuid().ToString();
             builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = roleIdc,
                    Name = "common",
                    NormalizedName = "COMMON",
                    ConcurrencyStamp = roleIdc
                });
            var adminUser = new ApplicationUser
            {
                Id = userId,
                //FirstName = "Admin",
                //LastName = "Adminsson",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                UserName = "AdminUser",
                NormalizedUserName = "ADMINUSER",
                CityId = 2
            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "password");
            builder.Entity<ApplicationUser>().HasData(adminUser);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = roleId,
                    UserId = userId
                });
        }
    }
}
