﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Dtos
{
    public class ListRestoranDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RestroanName { get; set; }
        public string Password { get; set; }
    }
}
