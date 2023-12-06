using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Entities
{
    public  class RestoranEntity:BaseEntity
    {
        public string UserName { get; set; }
        public string Email {  get; set; }
        public string RestroanName { get; set; }
        public string Password { get; set; }

        public List<TableEntity> Tables { get; set; }
        public List<CategoryEntity> Categories { get; set; }
       public  List<WorkerEntity> Workers { get; set; }
        public List<FoodEntity> Foods { get; set; }

    }

    public class RestoranConfiguration : BaseConfiguration<RestoranEntity>
    {
        public override void Configure(EntityTypeBuilder<RestoranEntity> builder)
        {
            


            base.Configure(builder);
        }
    }
}
