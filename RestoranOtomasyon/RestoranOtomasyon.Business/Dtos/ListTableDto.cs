using RestoranOtomasyon.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Dtos
{
    public  class ListTableDto
    {
        public int Id { get; set; }
        public string TableNo { get; set; }
        public int RestoranId { get; set; }
        public ActivatedEnum IsActivated { get; set; }
    }
}
