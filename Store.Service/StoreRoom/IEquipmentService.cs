using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.Work;

namespace Store.Service.StoreRoom
{
    public interface IEquipmentService
    {
        Equipment GetById(int id);
        void Insert(Equipment entity);
        void Remove(Equipment entity);
        void Update(Equipment entity);
        //List<Equipment> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, EquipmentType? Type = null, EquipmentUnit? Unit = null, WorkOrderPriority? priority = null, string title = null, string tag = null, string description = null, int company = 0);
        //List<Equipment> GetAll(int companyId = 0, string search = null, DateTime? date = null, WorkOrderStatus? status = null);
        //int Count(string search, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, WorkOrderStatus? status = null, WorkOrderType? type = null, WorkOrderPriority? priority = null, string title = null, string tag = null, string description = null, int company = 0);
    
    }
}
