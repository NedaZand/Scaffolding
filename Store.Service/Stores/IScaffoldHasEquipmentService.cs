using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IScaffoldHasEquipmentService
    {

        ScaffoldHasEquipment GetById(int id);
        void Insert(ScaffoldHasEquipment entity);
        void Insert(IEnumerable<ScaffoldHasEquipment> entities);
        void Remove(ScaffoldHasEquipment entity);
        void Update(ScaffoldHasEquipment entity);
        List<ScaffoldHasEquipment> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null);
        List<ScaffoldHasEquipment> GetAll();
        int Count(string search = null);
    }
}