using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestoranOtomasyon.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Entities
{
    public class FoodEntity:BaseEntity
    {
        public string Name { get; set; }    

        public string Description { get; set; }

        public int CategoryId {  get; set; }

        public AvailableEnum Available { get; set; }

        public decimal? UnitPrice { get; set; }

        public string ImagePath { get; set; }

        public int RestoranId { get; set; } 

        public RestoranEntity Restoran { get; set; }
        public CategoryEntity Category { get; set; }
        public List<OrderDetailEntity> OrderDetails { get; set; }

    }
    public class FoodConfiguration:BaseConfiguration<FoodEntity>
    {

        public override void Configure(EntityTypeBuilder<FoodEntity> builder)
        {
           
            builder.Property(X => X.CategoryId).IsRequired();
            builder.Property(x => x.RestoranId).IsRequired();
            builder.HasOne(od => od.Restoran)
           .WithMany(p =>p.Foods)
           .HasForeignKey(od => od.RestoranId)
           .OnDelete(DeleteBehavior.ClientSetNull);
            base.Configure(builder);
        }
    }
}
