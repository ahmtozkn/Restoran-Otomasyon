using RestoranOtomasyon.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Services
{
   public  interface IEmployeeService
    {
        EmployeeInfoDto LoginEmployee(LoginEmployeeDto loginEmployeeDto);
        List<ListEmployeeDto> GetAllEmployees();
        EditEmployeeDto GetEmployee(int id);
        void UpdateEmployee(EditEmployeeDto editEmployeeDto);
        void DeleteEmployee(int id);    
        bool AddEmployee(AddEmployeeDto addEmployeeDto);  





    }
}
