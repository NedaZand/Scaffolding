using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using System.Linq;

namespace Store.Service.Stores
{
    public interface IAssignedTaskService
    {

        AssignedTask GetById(int id);
        void Insert(AssignedTask entity);
        void Insert(IEnumerable<AssignedTask> entities);
        void Remove(AssignedTask entity);
        void Update(AssignedTask entity);
        void Update(IEnumerable<AssignedTask> entities);
        List<AssignedTask> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null, int? routinId = null, int? personnelCode = null);
        IEnumerable<AssignedTask> GetAll(DateTime? fromDate = null);
        int Count(string search, DateTime? fromDate = null, DateTime? toDate = null, int? routinId = null, int? personnelCode = null);
    }
}