using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Business.Services;
using RestoranOtomasyon.Data.Entities;
using RestoranOtomasyon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Manager
{
    public class RestoranManager : IRestoranService
    {
        private readonly IRepository<RestoranEntity> _restoranRepository;
        public RestoranManager(IRepository<RestoranEntity> restoranRepository)
        {
            _restoranRepository = restoranRepository;
        }
        public bool AddRestoran(AddRestoranDto addRestoranDto)
        {
            var hasRestoran=_restoranRepository.Get(x=>x.Email==addRestoranDto.Email||x.UserName==addRestoranDto.UserName);
            if (hasRestoran is not null)
            {
                return false;
            }

            

            var restoranEntity = new RestoranEntity()
            {
                RestroanName = addRestoranDto.RestroanName,
                Email = addRestoranDto.Email,
                Password = addRestoranDto.Password,
                UserName = addRestoranDto.UserName,
            };
            _restoranRepository.Add(restoranEntity);
            return true;
        }

        public void DeleteRestoran(int id)
        {
           _restoranRepository.Delete(id);
        }

        public EditRestoranDto GetRestoranById(int id)
        {

          var restoranEntity=_restoranRepository.GetById(id);
          var editRestoranDto = new EditRestoranDto()
          {
                Id = restoranEntity.Id,
                RestroanName =restoranEntity.RestroanName,
                Email =restoranEntity.Email,
                Password=restoranEntity.Password,
                UserName=restoranEntity.UserName,
          };
            return editRestoranDto;

        }

        public List<ListRestoranDto> GetRestoranList()
        {
            var listRestoranDto=_restoranRepository.GetAll().Select(x => new ListRestoranDto()
            {
                Id=x.Id,
                Email=x.Email,
                Password=x.Password,
                RestroanName=x.RestroanName,
                UserName =x.UserName,

            }).ToList();
            return listRestoranDto;
        }

        public RestoranInfoDto LoginUser(LoginRestoranDto loginRestoranDto)
        {
           var restoranEntity= _restoranRepository.Get(x => x.UserName == loginRestoranDto.UserName);
            if(restoranEntity is null||restoranEntity.Password!=loginRestoranDto.Password)
            {
                return null;
            }

            var restoranInfoDto = new RestoranInfoDto()
            {
                Id = restoranEntity.Id,
                Email = restoranEntity.Email,
                Password = restoranEntity.Password,
                UserName = restoranEntity.UserName,
                RestroanName=restoranEntity.RestroanName,
            };
            return restoranInfoDto;
            
        }

        public void UpdateRestoran(EditRestoranDto editRestoranDto)
        {
            var restoranEntity=_restoranRepository.Get(x => x.Id == editRestoranDto.Id);
            
            restoranEntity.Email = editRestoranDto.Email;
            restoranEntity.RestroanName = editRestoranDto.RestroanName;
            restoranEntity.UserName = editRestoranDto.UserName;
            restoranEntity.Password = editRestoranDto.Password;
            _restoranRepository.Update(restoranEntity);
        }
    }
}
