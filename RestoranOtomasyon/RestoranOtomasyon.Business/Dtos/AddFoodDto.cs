using RestoranOtomasyon.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Dtos
{
    public class AddFoodDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public AvailableEnum Available { get; set; }

        public decimal? UnitPrice { get; set; }

        public string ImagePath { get; set; }

        public int RestoranId { get; set; } 
    }
}
