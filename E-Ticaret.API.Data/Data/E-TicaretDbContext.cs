using E_Ticaret.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Data.Data
{
    public class E_TicaretDbContext : DbContext
    {
        public DbSet<UserModel> UserModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=localhost;Port=3307;Database=db;Uid=root;Pwd=admin;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductModel>().HasKey(x => x.Id);
            modelBuilder.Entity<BasketModel>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
