using RestoranOtomasyon.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Dtos
{
   public  class AddTableDto
    {
        public string TableNo { get; set; }
        public int RestoranId { get; set; }
        public ActivatedEnum IsActivated { get; set; }


    }
}
