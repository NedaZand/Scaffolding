using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.Work;

namespace Store.Service.Stores
{
    public interface IWorkOrderStatusService
    {

        WorkOrderStatus GetById(int id);
        void Insert(WorkOrderStatus entity);
        void Remove(WorkOrderStatus entity);
        void Update(WorkOrderStatus entity);
        List<WorkOrderStatus> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null);
        List<WorkOrderStatus> GetAll(string search = null);
        int Count(string search = null);
    }
}