using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.Data.Enums;
using RestoranOtomasyon.WebUI.Areas.Executive.Models;
using RestoranOtomasyon.WebUI.Extensions;

namespace RestoranOtomasyon.WebUI.Areas.Executive.Controllers
{
    [Area("Executive")]
    [Authorize(Roles = "Executive")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
         _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var employeeViewModel = _employeeService.GetAllEmployees().Where(x => x.RestoranId == User.RestoranId()).Select(X => new EmployeeViewModel()
            {
                Id = X.Id,
                FirstName = X.FirstName,
                LastName = X.LastName,
                EmployeeStatus = X.EmployeeStatus,
                Email = X.Email,
                RestoranId = User.RestoranId()

            }).ToList();  

            return View(employeeViewModel);
        }

        public IActionResult Add()
        {
            var employeeEnumList = Enum.GetValues(typeof(EmployeeStatusEnum)).Cast<EmployeeStatusEnum>().Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            }).ToList();
            ViewBag.EmployeeStatus = employeeEnumList;

            return View("Form",new EmployeeViewModel());
        }

        public IActionResult Save(EmployeeViewModel employeeViewModel) 
        {
            if (employeeViewModel.Id != 0)
            {
                var editEmployeeDto = new EditEmployeeDto()
                {
                    Id = employeeViewModel.Id,
                    FirstName = employeeViewModel.FirstName,
                    LastName = employeeViewModel.LastName,
                    EmployeeStatus = employeeViewModel.EmployeeStatus,
                    Password = employeeViewModel.Password,
                    Email = employeeViewModel.Email
                };
                _employeeService.UpdateEmployee(editEmployeeDto);

                return RedirectToAction("Index","Employee");
            }






            var addEmployeeDto = new AddEmployeeDto()
            {
                Email = employeeViewModel.Email,
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Password = employeeViewModel.Password,
                EmployeeStatus = employeeViewModel.EmployeeStatus,
                RestoranId = User.RestoranId()
            };
           var result=_employeeService.AddEmployee(addEmployeeDto);
            if(result)
            {
                return RedirectToAction("Index","Employee");
            }

            var employeeEnumList = Enum.GetValues(typeof(EmployeeStatusEnum)).Cast<EmployeeStatusEnum>().Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            }).ToList();
            ViewBag.EmployeeStatus = new SelectList(employeeEnumList, "Value", "Text");

            ViewBag.ErorEmployee = "Çalışan Eklenmedi.Böyle bir Eposta Zaten Kullanımda";
            return View("Form",employeeViewModel);
            
        }

        public IActionResult Delete(int id) 
        {
         _employeeService.DeleteEmployee(id);
         return RedirectToAction("Index", "Employee");
        }

        public IActionResult Update(int id)
        { 
            var employeeDto= _employeeService.GetEmployee(id);
            var employee = new EmployeeViewModel()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                EmployeeStatus = employeeDto.EmployeeStatus,
                Email = employeeDto.Email,
                Password = employeeDto.Password
            };
            var employeeEnumList = Enum.GetValues(typeof(EmployeeStatusEnum)).Cast<EmployeeStatusEnum>().Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            }).ToList();
            ViewBag.EmployeeStatus = new SelectList(employeeEnumList, "Value", "Text");

            return View("Form",employee);  
        }  
        
       
    }
}
