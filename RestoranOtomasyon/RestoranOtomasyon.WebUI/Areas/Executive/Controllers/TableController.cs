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
    public class TableController : Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
                _tableService = tableService;
        }
        public IActionResult Index()
        {
          var tableViewModel=_tableService.GetAllTable().Where(x => x.RestoranId == User.RestoranId()).Select(x => new TableViewModel()
            {
                Id = x.Id,
                TableNo = x.TableNo,
            }).ToList();
            return View(tableViewModel);
        }

        public IActionResult Add() 
        {
           return View("Form",new TableViewModel());
        }

        public IActionResult Save(TableViewModel tableViewModel) 
        {
            if (tableViewModel.Id != 0)
            {
                var editTableDto = new EditTableDto()
                { 
                    Id = tableViewModel.Id,
                    TableNo = tableViewModel.TableNo,
                    RestoranId = User.RestoranId(),
                };
                _tableService.UpdateTable(editTableDto);
                return RedirectToAction("Index", "Table");
            }
            var addTableDto = new AddTableDto()
            {
                TableNo = tableViewModel.TableNo,
                RestoranId = User.RestoranId(),
                IsActivated=Data.Enums.ActivatedEnum.Passive
            };


            var result= _tableService.TableAdd(addTableDto);

            if (result)
            {
                return RedirectToAction("Index","Table");
            }

            ViewBag.TableEror = "Böyle bir masa zaten var";

             return View("Form", tableViewModel);

        }
        public IActionResult Delete(int id)
        {
            _tableService.DeleteTable(id);
            return RedirectToAction("Index","Table");
        }
        public IActionResult Update(int id)
        {
            var editTableDto = _tableService.GetTable(id);
            var tableViewModel = new TableViewModel()
            {
                Id = id,
                TableNo = editTableDto.TableNo,
            };
            return View("Form", tableViewModel);
           
        }
    }
}
