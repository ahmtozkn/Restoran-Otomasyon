using Microsoft.EntityFrameworkCore;
using RestoranOtomasyon.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Context
{
   public class RestoranOtomasyonContext:DbContext
    {
       public RestoranOtomasyonContext(DbContextOptions<RestoranOtomasyonContext> options):base(options) 
        {
        
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new RestoranConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<FoodEntity> Foods => Set<FoodEntity>();
       public DbSet<OrderEntity> OrderEntities => Set<OrderEntity>();
        public DbSet<OrderDetailEntity> OrderDetails => Set<OrderDetailEntity>();
        
        public DbSet<RestoranEntity> Restorans => Set<RestoranEntity>();
        public DbSet<TableEntity> Tables => Set<TableEntity>();
        public DbSet<WorkerEntity> Workers => Set<WorkerEntity>();
    }
}
