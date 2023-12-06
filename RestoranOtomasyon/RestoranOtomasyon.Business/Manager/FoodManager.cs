
using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.Data.Entities;
using RestoranOtomasyon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Manager
{
    public class FoodManager : IFoodService
    {
        private readonly IRepository<FoodEntity> _foodRepository;
        public FoodManager(IRepository<FoodEntity> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public void AddFood(AddFoodDto addFoodDto)
        {
            var foodEntity = new FoodEntity()
            {
                Name = addFoodDto.Name,
                CategoryId = addFoodDto.CategoryId,
                UnitPrice = addFoodDto.UnitPrice,
                ImagePath = addFoodDto.ImagePath,
                Available = addFoodDto.Available,
                Description = addFoodDto.Description,
                RestoranId=addFoodDto.RestoranId,
            };
            _foodRepository.Add(foodEntity);
        }

        public void DeleteFood(int id)
        {
            _foodRepository.Delete(id);
        }

        public List<ListFoodDto> GetAllFood()
        {
            var listFoodDto = _foodRepository.GetAll().Select(x => new ListFoodDto()
            {
                Id = x.Id,
                Available=x.Available,
                CategoryId=x.CategoryId,
                ImagePath=x.ImagePath,
                Description=x.Description,
                Name = x.Name,
                UnitPrice=x.UnitPrice,
                CategoryName=x.Category.CategoryName,
                RestoranId = x.RestoranId,
                


            }).ToList();
             return listFoodDto;    
           
        }

        public EditFoodDto GetFoodById(int id)
        {
           var foodEntity= _foodRepository.GetById(id);
            var editFoodDto = new EditFoodDto()
            {
                Id = id,
                CategoryId = foodEntity.CategoryId,
                Description = foodEntity.Description,
                ImagePath = foodEntity.ImagePath,
                Available = foodEntity.Available,
                Name = foodEntity.Name,
                UnitPrice = foodEntity.UnitPrice,
                RestoranId= foodEntity.RestoranId,

            };
            return editFoodDto; 

        }

        public void UpdateFood(EditFoodDto editFoodDto)
        {
            var foodEntity=_foodRepository.GetById(editFoodDto.Id);

            foodEntity.Description = editFoodDto.Description;   
            foodEntity.UnitPrice= editFoodDto.UnitPrice;    
           
            foodEntity.Name = editFoodDto.Name;
            foodEntity.Available = editFoodDto.Available;
            foodEntity.CategoryId = editFoodDto.CategoryId;

            if (editFoodDto.ImagePath is not null)
            {
                foodEntity.ImagePath = editFoodDto.ImagePath;
            }


            _foodRepository.Update(foodEntity);
        }
    }
}
