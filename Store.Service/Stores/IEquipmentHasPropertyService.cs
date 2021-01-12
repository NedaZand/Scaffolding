using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IEquipmentHasPropertyService
    {

        EquipmentHasProperty GetById(int id);
        void Insert(EquipmentHasProperty entity);
        void Insert(IEnumerable<EquipmentHasProperty> entities);
        void Remove(EquipmentHasProperty entity);
        void Update(EquipmentHasProperty entity);
        List<EquipmentHasProperty> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null, int equipmentId = 0);
        List<EquipmentHasProperty> GetAll();
        int Count(string search, int equipmentId = 0);
        }
}