using RestoranOtomasyon.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Services
{
    public  interface IFoodService
    {

        void AddFood(AddFoodDto addFoodDto);

        void UpdateFood(EditFoodDto editFoodDto);

        void DeleteFood(int id);

        List<ListFoodDto> GetAllFood();

        EditFoodDto GetFoodById(int id);

    }
}
