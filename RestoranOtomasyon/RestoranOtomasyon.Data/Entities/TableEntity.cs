using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestoranOtomasyon.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Entities
{
    public  class TableEntity:BaseEntity
    {   
        
        public string TableNo { get; set; }
        public int RestoranId {  get; set; }
        public ActivatedEnum IsActivated { get; set; }

        public RestoranEntity Restoran {  get; set; }
        public List<OrderEntity> Orders { get; set; }
       

    }

    public class TableConfiguration:BaseConfiguration<TableEntity>
    {
        public override void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
