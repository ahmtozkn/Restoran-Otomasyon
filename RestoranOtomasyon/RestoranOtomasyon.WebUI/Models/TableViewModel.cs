using RestoranOtomasyon.Data.Enums;

namespace RestoranOtomasyon.WebUI.Models
{
    public class TableViewModel
    {
        public int Id { get; set; }

        public string TableNo { get; set; }

        public int RestoranId { get; set; }

        public ActivatedEnum Activated { get; set; }
    }
}
