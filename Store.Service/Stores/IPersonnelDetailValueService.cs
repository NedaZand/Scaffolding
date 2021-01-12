using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;

namespace Store.Service.Stores
{
    public interface IPersonnelDetailValueService
    {

        PersonnelDetailValue GetById(int id);
        void Insert(PersonnelDetailValue entity);
        void Remove(PersonnelDetailValue entity);
        void Update(PersonnelDetailValue entity);
        List<PersonnelDetailValue> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null);
            List<PersonnelDetailValue> GetAll(string search = null);
        int Count(string search,DateTime? createDate = null, DateTime? editDate = null);
    }
}