using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.WebUI.Areas.Executive.Models;
using RestoranOtomasyon.WebUI.Extensions;

namespace RestoranOtomasyon.WebUI.Areas.Executive.Controllers
{
        [Area("Executive")]
        [Authorize(Roles = "Executive")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FoodController(IFoodService foodService,ICategoryService categoryService,IWebHostEnvironment webHostEnvironment)
        {
                _foodService = foodService;
                _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
          var listFoodViewModel=_foodService.GetAllFood().Where(x=>x.RestoranId==User.RestoranId()).Select(x=> new ListFoodViewModel()
          {
              Id = x.Id,
              Name = x.Name,
              CategoryName = x.CategoryName,
              CategoryId = x.CategoryId,
              Description = x.Description,
              Available=x.Available,
              ImagePath = x.ImagePath,
              UnitPrice = x.UnitPrice,
              RestoranId=x.RestoranId,
             

          }).ToList();
            
            return View(listFoodViewModel);
        }

        public IActionResult Add()
        {
            ViewBag.CategoryList=_categoryService.GetAllCategories().Where(x=>x.RestoranId==User.RestoranId());

            return View("Form",new FoodViewModel());
        }

        [HttpPost]

        public IActionResult Save(FoodViewModel foodViewModel) 
        {
            var newFileName = "";
            if(foodViewModel.ImagePath is not null)
            {
                var allowedFileTypes = new string[]
                {
                    "image/jpeg","image/jpg","image/png","image/jfif" };
                var allowedFileExtensions = new string[]
                {
                    ".jpg",".jpeg",".png",".jfif"
                };

                var fileContentType = foodViewModel.ImagePath.ContentType;

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(foodViewModel.ImagePath.FileName);

                var fileExtension = Path.GetExtension(foodViewModel.ImagePath.FileName);

                if (!allowedFileTypes.Contains(fileContentType) ||
                    !allowedFileExtensions.Contains(fileExtension))
                {
                    ViewBag.FileError = "Dosya formatı veya içeriği hatalı";


                    ViewBag.CategoryList = _categoryService.GetAllCategories();
                    return View("Form", foodViewModel);

                }

                newFileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;


                var folderPath = Path.Combine("images", "Food");


                var wwwrootFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);


                var wwwrootFilePath = Path.Combine(wwwrootFolderPath, newFileName);


                Directory.CreateDirectory(wwwrootFolderPath);

                using (var fileStream = new FileStream(
                    wwwrootFilePath, FileMode.Create))
                {
                    foodViewModel.ImagePath.CopyTo(fileStream);
                }

            }
            if (foodViewModel.Id==0)
            {
                var addFoodDto = new AddFoodDto()
                {
                    Name = foodViewModel.Name,
                    Description = foodViewModel.Description,
                    ImagePath = newFileName,
                    CategoryId = foodViewModel.CategoryId,
                    RestoranId = User.RestoranId(),
                    UnitPrice = foodViewModel.UnitPrice,
                    Available = Data.Enums.AvailableEnum.Mevcut
                };
                _foodService.AddFood(addFoodDto);
            }

            else
            {
                var editFoodDto = new EditFoodDto()
                {
                    Id = foodViewModel.Id,
                    Name= foodViewModel.Name,
                    Available = Data.Enums.AvailableEnum.Mevcut,
                    Description = foodViewModel.Description,
                    CategoryId= foodViewModel.CategoryId,
                    UnitPrice= foodViewModel.UnitPrice,
                   




                };

                if(foodViewModel.ImagePath is not null)
                {
                    editFoodDto.ImagePath = newFileName;
                }
                _foodService.UpdateFood(editFoodDto);
            }
            return RedirectToAction("Index", "Food");
        
        }

        public IActionResult Delete(int id)
        {

            _foodService.DeleteFood(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var editFoodDto=_foodService.GetFoodById(id);
            var viewModel = new FoodViewModel()
            {
                Id = editFoodDto.Id,
                Name = editFoodDto.Name,
                Description = editFoodDto.Description,
                UnitPrice = editFoodDto.UnitPrice,
                CategoryId = editFoodDto.CategoryId,
            };
            ViewBag.ImagePath=editFoodDto.ImagePath;
            ViewBag.CategoryList=_categoryService.GetAllCategories().Where(x => x.RestoranId == User.RestoranId());
            return View("Form",viewModel);

        }

    }
}
