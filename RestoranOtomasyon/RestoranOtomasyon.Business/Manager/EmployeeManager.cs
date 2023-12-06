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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepository<WorkerEntity> _workerRepository;
        public EmployeeManager(IRepository<WorkerEntity> workerRepository)
        {
                _workerRepository = workerRepository;
        }

        public bool AddEmployee(AddEmployeeDto addEmployeeDto)
        {
          var hasEmployee=_workerRepository.Get(x=>x.Email==addEmployeeDto.Email);

            if(hasEmployee is not null)
            {
                return false;  
            }
            var employeeEntity = new WorkerEntity()
            {
                Email = addEmployeeDto.Email,
                EmployeeStatus = addEmployeeDto.EmployeeStatus,
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                Password = addEmployeeDto.Password,
                RestoranId = addEmployeeDto.RestoranId,

            };
            _workerRepository.Add(employeeEntity);
            return true;

        }

        public void DeleteEmployee(int id)
        {
            _workerRepository.Delete(id);
        }

        public List<ListEmployeeDto> GetAllEmployees()
        {
            var listEmployeeDto = _workerRepository.GetAll().Select(x => new ListEmployeeDto()
            {
                Id = x.Id,
                EmployeeStatus = x.EmployeeStatus,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName  = x.LastName,
                Password = x.Password,
                RestoranId = x.RestoranId,
                

            }).ToList();
            return listEmployeeDto; 
        }

        public EditEmployeeDto GetEmployee(int id)
        {
           var entity= _workerRepository.GetById(id);
            var editEmployeeDto = new EditEmployeeDto()
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                EmployeeStatus = entity.EmployeeStatus,
                RestoranId = entity.RestoranId,

            };
            return editEmployeeDto; 

        }

        public EmployeeInfoDto LoginEmployee(LoginEmployeeDto loginEmployeeDto)
        {
          var hasWorker= _workerRepository.Get(x=>x.Email==loginEmployeeDto.Email&&x.Password==loginEmployeeDto.Password);
            //if(hasWorker.RestoranId!=loginEmployeeDto.RestoranId)
            //{
            //    return null;

            //}
            if(hasWorker is  null||hasWorker.RestoranId!=loginEmployeeDto.RestoranId)
            {
                return null;
            }
            var employeeInfoDto = new EmployeeInfoDto()
            {
                Id=hasWorker.Id,
                Email = hasWorker.Email,
                Password = hasWorker.Password,
                EmployeeStatus = hasWorker.EmployeeStatus,
                FirstName = hasWorker.FirstName,
                LastName = hasWorker.LastName,
                RestoranId=hasWorker.RestoranId,

            };
            return employeeInfoDto;

           
        }

        public void UpdateEmployee(EditEmployeeDto editEmployeeDto)
        {
          var entity=_workerRepository.GetById(editEmployeeDto.Id);
            entity.Email = editEmployeeDto.Email;   
            entity.Password = editEmployeeDto.Password;
            entity.FirstName = editEmployeeDto.FirstName;
            entity.LastName = editEmployeeDto.LastName;
            entity.EmployeeStatus = editEmployeeDto.EmployeeStatus;
            _workerRepository.Update(entity);
          
        }
    }
}
