using RestoranOtomasyon.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Services
{
   public  interface ITableService
    {
        bool TableAdd(AddTableDto addTableDto);
        EditTableDto GetTable(int id);
        void DeleteTable(int id);
        List<ListTableDto> GetAllTable();

        void UpdateTable(EditTableDto editTableDto);







    }
}
