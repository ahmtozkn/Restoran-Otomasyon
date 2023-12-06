﻿using System.Diagnostics.Contracts;

namespace RestoranOtomasyon.WebUI.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int RestoranId {  get; set; }

    }
}
