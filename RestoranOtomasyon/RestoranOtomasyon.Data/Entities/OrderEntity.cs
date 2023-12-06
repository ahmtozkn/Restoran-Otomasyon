using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestoranOtomasyon.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Entities
{
   public class OrderEntity:BaseEntity
    {
        public int TableId {  get; set; }

        public decimal? TotalPrice { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        public TableEntity Table { get; set; }
        public List<OrderDetailEntity> OrderDetails { get; set; }

       

    }
    public class OrderConfiguration:BaseConfiguration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
