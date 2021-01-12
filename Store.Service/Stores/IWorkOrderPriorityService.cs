using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.Work;

namespace Store.Service.Stores
{
    public interface IWorkOrderPriorityService
    {

        WorkOrderPriority GetById(int id);
        void Insert(WorkOrderPriority entity);
        void Remove(WorkOrderPriority entity);
        void Update(WorkOrderPriority entity);
        List<WorkOrderPriority> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null);
        List<WorkOrderPriority> GetAll(string search = null);
        int Count(string search = null);
    }
}