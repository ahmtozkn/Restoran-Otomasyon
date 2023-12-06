using RestoranOtomasyon.Data.Enums;

namespace RestoranOtomasyon.WebUI.Areas.Executive.Models
{
    public class FoodViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public AvailableEnum Available { get; set; }

        public decimal? UnitPrice { get; set; }

        public IFormFile? ImagePath { get; set; }

        public int RestoranId { get; set; } 

    }

}
