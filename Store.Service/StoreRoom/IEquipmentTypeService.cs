using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Service.StoreRoom;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.StoreRoom
{
    public interface IEquipmentTypeService
    {
        EquipmentType GetById(int id);
        void Insert(EquipmentType entity);
        void Remove(EquipmentType entity);
        void Update(EquipmentType entity);
        List<EquipmentType> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null);
        List<EquipmentType> GetAll(string search = null);
        int Count(string search = null);
    }
}
