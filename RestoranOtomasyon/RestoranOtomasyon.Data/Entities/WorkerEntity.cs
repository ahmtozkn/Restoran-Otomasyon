using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestoranOtomasyon.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Data.Entities
{
    public class WorkerEntity:BaseEntity
    {
        public int RestoranId { get; set; }

        public string Email  { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public EmployeeStatusEnum  EmployeeStatus { get; set; }

        public RestoranEntity Restoran { get; set; }    

    }

    public class WorkerConfiguration :BaseConfiguration<WorkerEntity> 
    {
        public override void Configure(EntityTypeBuilder<WorkerEntity> builder)
        {
            base.Configure(builder);
        }

    }
}
