using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.Work;

namespace Store.Service.Stores
{
    public interface IWorkOrderService
    {

        WorkOrder GetById(int id);
        void Insert(WorkOrder entity);
        void Insert(IEnumerable<WorkOrder> entities);
        void Remove(WorkOrder entity);
        void Update(WorkOrder entity);
        List<WorkOrder> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, WorkOrderStatus? status = null, WorkOrderType? type = null, WorkOrderPriority? priority = null, string title = null, string tag = null, string description = null, int? company = null,int? scaffoldingId=null);
        List<WorkOrder> GetAll(int companyId = 0, List<Company> companies = null, string search = null, DateTime? date = null, WorkOrderStatus[] status = null, WorkOrderType? type = null,int scaffoldingId=0, bool showTodayAssigned = false);
        int Count(string search=null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, WorkOrderStatus? status = null, WorkOrderType? type = null, WorkOrderPriority? priority = null, string title = null, string tag = null, string description = null, int? company = null, int? scaffoldingId = null);
    }
}