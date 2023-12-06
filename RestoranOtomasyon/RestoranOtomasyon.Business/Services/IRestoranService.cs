using RestoranOtomasyon.Business.Dtos;
using RestoranOtomasyon.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranOtomasyon.Business.Services
{
    public  interface IRestoranService
    {
        bool AddRestoran(AddRestoranDto addRestoranDto);

        void DeleteRestoran(int id);

        void UpdateRestoran(EditRestoranDto editRestoranDto);

        List<ListRestoranDto>GetRestoranList();

        EditRestoranDto GetRestoranById(int id);

        RestoranInfoDto LoginUser(LoginRestoranDto loginRestoranDto);



        





    }
}
