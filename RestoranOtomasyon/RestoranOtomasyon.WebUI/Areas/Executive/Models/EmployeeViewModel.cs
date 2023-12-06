using RestoranOtomasyon.Data.Enums;

namespace RestoranOtomasyon.WebUI.Areas.Executive.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; } 
        public int RestoranId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

       

        public EmployeeStatusEnum EmployeeStatus { get; set; }
    }
}
