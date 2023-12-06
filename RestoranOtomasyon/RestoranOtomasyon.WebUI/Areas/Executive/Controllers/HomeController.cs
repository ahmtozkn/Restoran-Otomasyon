using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestoranOtomasyon.Business.Services;

namespace RestoranOtomasyon.WebUI.Areas.Executive.Controllers
{        [Area("Executive")]
        [Authorize(Roles = "Executive")]
    public class HomeController : Controller
    {
        private readonly IFoodService _foodService;

        public HomeController()
        {
            
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
