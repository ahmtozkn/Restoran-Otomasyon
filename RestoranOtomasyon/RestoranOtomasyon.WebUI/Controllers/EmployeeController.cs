using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.WebUI.Extensions;
using RestoranOtomasyon.WebUI.Models;
using System.Security.Claims;

namespace RestoranOtomasyon.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITableService _tableService;
        public EmployeeController(IEmployeeService employeeService,ITableService tableService)
        {
                _employeeService = employeeService;
                _tableService = tableService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(EmployeeLoginViewModel employeeLoginViewModel)
        {
            var loginEmployeeDto = new LoginEmployeeDto()
            {
                Email = employeeLoginViewModel.Email,
                Password = employeeLoginViewModel.Password,
                RestoranId=User.RestoranId()
            };
            
            var employeeInfoDto= _employeeService.LoginEmployee(loginEmployeeDto);
            if(employeeInfoDto is null)
            {
                ViewBag.EmployeeEror = "Kullanıcı Adı Veya Şifre Yanlış"; 
                return View();
            }

            var claims= new List<Claim>();

            claims.Add(new Claim("EmployeeId", employeeInfoDto.Id.ToString()));
            claims.Add(new Claim("RestoranId",employeeInfoDto.RestoranId.ToString()));
            claims.Add(new Claim("userStatus",employeeInfoDto.EmployeeStatus.ToString()));

            claims.Add(new Claim(ClaimTypes.Role, employeeInfoDto.EmployeeStatus.ToString()));
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48))
            };




            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);
            return RedirectToAction( "Home", "Employee");//burdan yönetim paneline gitmek lazım

        }
        public IActionResult Home() 
        {

            var tableViewModel= _tableService.GetAllTable().Where(x => x.RestoranId == User.RestoranId()).Select(x => new TableViewModel()
            {
                Id = x.Id,
                TableNo = x.TableNo,
                Activated=x.IsActivated
                
            }).ToList();


            return View(tableViewModel);
        
        
        }

    }
}
