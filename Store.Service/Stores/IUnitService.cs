using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IUnitService
    {

        Unit GetById(int id);
        void Insert(Unit entity);
        void Remove(Unit entity);
        void Update(Unit entity);
        List<Unit> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null);
        List<Unit> GetAll(string title = null);
        int Count(string search);

    }
}