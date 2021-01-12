using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IEquipmentService
    {
        Equipment GetById(int id);
        void Insert(Equipment entity);
        void Remove(Equipment entity);
        void Update(Equipment entity);
        List<Equipment> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<Equipment> GetAll(string title = null);
        int Count(string search = null);
    }
}