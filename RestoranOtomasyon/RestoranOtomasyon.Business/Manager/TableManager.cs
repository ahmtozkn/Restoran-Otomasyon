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
   
    public class TableManager : ITableService
    { 
        private readonly IRepository<TableEntity> _tableRepository;
        public TableManager(IRepository<TableEntity> tableRepository)
        {
            _tableRepository = tableRepository;
                
        }
        public void DeleteTable(int id)
        {
            _tableRepository.Delete(id);
        }

        public List<ListTableDto> GetAllTable()
        {
            var listTableDto = _tableRepository.GetAll().Select(x => new ListTableDto
            {

                Id = x.Id,
                RestoranId = x.RestoranId,
                TableNo = x.TableNo,
                IsActivated = x.IsActivated,
            }).ToList();
            return listTableDto;
        }

        public EditTableDto GetTable(int id)
        {
          var tableEntity=_tableRepository.GetById(id);
            var editTableDto = new EditTableDto()
            {
                Id = tableEntity.Id,
                TableNo = tableEntity.TableNo,
                RestoranId = tableEntity.RestoranId,
                IsActivated = tableEntity.IsActivated,

            };
            return editTableDto;

        }

        public bool TableAdd(AddTableDto addTableDto)
        {
          var hasTable=_tableRepository.Get(x => x.TableNo == addTableDto.TableNo);
            if(hasTable is not null)
            {

                return false;
            }
            var tableEntity = new TableEntity()
            {
                TableNo = addTableDto.TableNo,
                IsActivated= addTableDto.IsActivated,
                RestoranId= addTableDto.RestoranId,
            };
            _tableRepository.Add(tableEntity);
            return true;
        }

        public void UpdateTable(EditTableDto editTableDto)
        {
           var tableEntity=_tableRepository.GetById(editTableDto.Id);
           tableEntity.TableNo = editTableDto.TableNo;
            _tableRepository.Update(tableEntity);
        }
    }
}
