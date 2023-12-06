using Microsoft.AspNetCore.Mvc;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.WebUI.Models;

namespace RestoranOtomasyon.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IFoodService _foodService;

        public HomeController(ICategoryService categoryService,IFoodService foodService)
        {
                    _categoryService = categoryService;
                    _foodService = foodService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Home(int id)
        {
            var categoryViewModel= _categoryService.GetAllCategories().Where(x=>x.RestoranId==id).Select(x=> new CategoryViewModel()
            {
                Id =x.Id,
                Description=x.CategoryDescription,
                Name=x.CategoryName,
                RestoranId=id


            }).ToList();

            var foodViewModel = _foodService.GetAllFood().Where(x => x.RestoranId == id).Select(x => new FoodViewModel()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                RestoranId = x.RestoranId,
                Description = x.Description,
                Name = x.Name,
                ImagePath = x.ImagePath,
                Available = x.Available,
                UnitPrice = x.UnitPrice,
                CategoryName=x.CategoryName,



            }).ToList();
            ViewBag.Food = foodViewModel;


            return View(categoryViewModel);
        }
    }
}
