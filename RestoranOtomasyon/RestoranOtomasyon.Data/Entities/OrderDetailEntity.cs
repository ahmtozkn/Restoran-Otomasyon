using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Entities
{
   public class OrderDetailEntity:BaseEntity
    {
        public int OrderId {  get; set; }

        public int FoodId {  get; set; }

        public int Quantity { get; set; }

        public OrderEntity Order { get; set; }

        public FoodEntity Food { get; set; }

       

    }

    public class OrderDetailConfiguration : BaseConfiguration<OrderDetailEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.Property(x => x.OrderId).IsRequired();
            builder.HasOne(od => od.Order)
           .WithMany(p => p.OrderDetails)
           .HasForeignKey(od => od.OrderId)
           .OnDelete(DeleteBehavior.ClientSetNull);
            base.Configure(builder);
        }
    }

}
