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
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        public CategoryManager(IRepository<CategoryEntity> categoryRepository)
        {
                _categoryRepository = categoryRepository;
        }
        public bool AddCategory(AddCategoryDto addCategoryDto)
        {
            var hasCategory=_categoryRepository.Get(x=>x.CategoryName == addCategoryDto.CategoryName);
            if(hasCategory is not null)
            {
                return false;
            }
            var categoryEntity = new CategoryEntity()
            {
                CategoryName = addCategoryDto.CategoryName,
                CategoryDescription = addCategoryDto.CategoryDescription,
                RestoranId = addCategoryDto.RestoranId,
            };
            _categoryRepository.Add(categoryEntity);
            return true;

           
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<ListCategoryDto> GetAllCategories()
        {
          var listCategoryDto=  _categoryRepository.GetAll().Select(x=> new ListCategoryDto()
          {
              Id = x.Id,
              CategoryDescription= x.CategoryDescription,
              CategoryName = x.CategoryName,
              RestoranId= x.RestoranId,

          }).ToList();
            return listCategoryDto;
           
        }

        public EditCategoryDto GetCategory(int id)
        {
           var categoryEntity=_categoryRepository.GetById(id);
            var editCategoryDto = new EditCategoryDto()
            {
                Id = categoryEntity.Id,
                CategoryDescription = categoryEntity.CategoryDescription,
                CategoryName = categoryEntity.CategoryName,
                RestoranId = categoryEntity.RestoranId,

            };
            return editCategoryDto;
        }

        public void UpdateCategory(EditCategoryDto editCategoryDto)
        {
            var categoryEntity=  _categoryRepository.Get(x => x.Id == editCategoryDto.Id);
            categoryEntity.CategoryDescription = editCategoryDto.CategoryDescription;
            categoryEntity.CategoryName = editCategoryDto.CategoryName;
           _categoryRepository.Update(categoryEntity);
                       
        }
    }
}
