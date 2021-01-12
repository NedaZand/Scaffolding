using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IBuildingService
    {

        Building GetById(int id);
        void Insert(Building entity);
        void Remove(Building entity);
        void Update(Building entity);
        List<Building> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<Building> GetAll(string title = null);
        int Count(string search = null);
    }
}