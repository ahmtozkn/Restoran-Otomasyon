using RestoranOtomasyon.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Services
{
   public  interface ICategoryService
    {
       bool AddCategory(AddCategoryDto addCategoryDto);

       void DeleteCategory(int id);

       EditCategoryDto GetCategory(int id);

       List<ListCategoryDto> GetAllCategories();
       
       void UpdateCategory(EditCategoryDto editCategoryDto);
       
    
       

    }
}
