using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;

namespace Store.Service.Stores
{
    public interface IPersonnelDetailService
    {

        PersonnelDetail GetById(int id);
        void Insert(PersonnelDetail entity);
        void Remove(PersonnelDetail entity);
        void Update(PersonnelDetail entity);
        List<PersonnelDetail> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null);
            List<PersonnelDetail> GetAll(string search = null);
        int Count(string search,DateTime? createDate = null, DateTime? editDate = null);
    }
}