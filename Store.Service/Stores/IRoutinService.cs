using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;

namespace Store.Service.Stores
{
    public interface IRoutinService
    {

        Routine GetById(int id);
        void Insert(Routine entity);
        void Remove(Routine entity);
        void Update(Routine entity);
        List<Routine> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<Routine> GetAll(string title = null);
        int Count(string search = null);
    }
}