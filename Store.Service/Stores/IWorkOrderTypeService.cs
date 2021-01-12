using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.Work;

namespace Store.Service.Stores
{
    public interface IWorkOrderTypeService
    {

        WorkOrderType GetById(int id);
        void Insert(WorkOrderType entity);
        void Remove(WorkOrderType entity);
        void Update(WorkOrderType entity);
        List<WorkOrderType> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null);
        List<WorkOrderType> GetAll(string search = null);
        int Count(string search = null);
    }
}