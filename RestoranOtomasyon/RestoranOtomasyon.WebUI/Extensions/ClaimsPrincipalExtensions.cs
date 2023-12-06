using RestoranOtomasyon.Data.Enums;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RestoranOtomasyon.WebUI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsEmployeeLogged(this ClaimsPrincipal user)
        {
            if (user.Claims.FirstOrDefault(x => x.Type == "EmployeeId") != null)
                return true;
            else
            return false;
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return Convert.ToInt32(user.Claims.FirstOrDefault(x => x.Type == "EmployeeId")?.Value);
        }

        public static int RestoranId(this ClaimsPrincipal user) 
        {
            return Convert.ToInt32(user.Claims.FirstOrDefault(x => x.Type == "RestoranId")?.Value);
        
        
        }

        

        public static bool IsExecutive(this ClaimsPrincipal user)
        {
            var userType = user.Claims.FirstOrDefault(x => x.Type == "userStatus")?.Value;
            if (userType == EmployeeStatusEnum.Executive.ToString())
                return true;
            else
                return false;

        }

    }
}
