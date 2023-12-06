using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.WebUI.Areas.Executive.Models;
using RestoranOtomasyon.WebUI.Extensions;

namespace RestoranOtomasyon.WebUI.Areas.Executive.Controllers
  { 
    [Area("Executive")]
    [Authorize(Roles = "Executive")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
                
        }

        public IActionResult Index()
        {
           var categoryViewModel= _categoryService.GetAllCategories().Where(x=>x.RestoranId==User.RestoranId()).Select(x=> new CategoryViewModel()
           {
               Id = x.Id,
               CategoryDescription=x.CategoryDescription,
               CategoryName=x.CategoryName,
               RestoranId=x.Id,


           }).ToList();
            
            return View(categoryViewModel);
           
        }
        [HttpGet]
        public IActionResult Add()
        {


            return View(new CategoryViewModel());
        }
        [HttpPost] 
        public IActionResult Save(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.Id != 0)
            {
                var editCategoryDto = new EditCategoryDto()
                {
                    Id = categoryViewModel.Id,
                    CategoryDescription = categoryViewModel.CategoryDescription,
                    CategoryName = categoryViewModel.CategoryName,
                    RestoranId = categoryViewModel.RestoranId
                };
                _categoryService.UpdateCategory(editCategoryDto);
                return Redirect("Index");

            }



            var addCategoryDto = new AddCategoryDto()
            {
                CategoryName = categoryViewModel.CategoryName,
                CategoryDescription = categoryViewModel.CategoryDescription,
                RestoranId = User.RestoranId()
            };
            var result= _categoryService.AddCategory(addCategoryDto);
            if (result)
            { 
                return Redirect("Index");

            }
            ViewBag.CategoryEror = "Category Eklenmedi";
           return View("Add",categoryViewModel);
        }
        public IActionResult Update(int id)
        {
            var editCategoryDto=_categoryService.GetCategory(id);
            var categoryViewModel = new CategoryViewModel()
            {
                Id = editCategoryDto.Id,
                CategoryName = editCategoryDto.CategoryName,
                CategoryDescription = editCategoryDto.CategoryDescription,
                RestoranId = User.RestoranId()
            };
           
            return View("Add",categoryViewModel);
        }

        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index","Category");

        }
    }
}
