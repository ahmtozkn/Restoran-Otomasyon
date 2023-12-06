using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.WebUI.Models;
using System.Security.Claims;

namespace RestoranOtomasyon.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRestoranService _restoranService;

        public LoginController(IRestoranService restoranService)
        {
                _restoranService = restoranService;
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(RestoranViewModel restoranViewModel) 
        {
            var addRestoranDto = new AddRestoranDto()
            {
                Email = restoranViewModel.Email,
                Password = restoranViewModel.Password,
                UserName = restoranViewModel.UserName,
                RestroanName = restoranViewModel.RestroanName,
            };
           var restoran= _restoranService.AddRestoran(addRestoranDto);
            if (restoran == false)
            {
                ViewBag.Eror = "Böyle Bir Kullanıcı Adı Veya Email Zaten Kullanımda";
                return View();  
            }

             return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Login() 
        {        
         return View();
        
        }
        [HttpPost]
        public  async Task<IActionResult>Login(RestoranLoginViewModel restoranLoginViewModel) 
        {
            var restoranLoginDto = new LoginRestoranDto()
            {   
                UserName = restoranLoginViewModel.UserName,
                Password = restoranLoginViewModel.Password,
            };
          var restoranInfoDto=  _restoranService.LoginUser(restoranLoginDto);

            if(restoranInfoDto is null)
            {
                return Redirect("Login");
            }
            var claims=new List<Claim>();
            claims.Add(new Claim("RestoranId", restoranInfoDto.Id.ToString()));
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48))
            };


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);


            return RedirectToAction("Home", "Home",new { id=restoranInfoDto.Id });
        }

    }
}
