using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Entities
{
    public  class CategoryEntity:BaseEntity
    {
        public string CategoryName {  get; set; }

        public string CategoryDescription { get; set; }

        public int RestoranId {  get; set; }
        public List<FoodEntity> Foods { get; set; }

        public RestoranEntity Restoran { get; set; }
      
    }
    public class CategoryConfiguration:BaseConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {

            builder.Property(X => X.RestoranId).IsRequired();
            base.Configure(builder);
        }

    }
}
