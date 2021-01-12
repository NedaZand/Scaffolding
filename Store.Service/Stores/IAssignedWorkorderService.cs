using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;

namespace Store.Service.Stores
{
    public interface IAssignedWorkorderService
    {

        AssignedWorkorder GetById(int id);
        void Insert(AssignedWorkorder entity);
        void Insert(IEnumerable<AssignedWorkorder> entities);
        void Remove(AssignedWorkorder entity);
        void Update(AssignedWorkorder entity);
        List<AssignedWorkorder> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null);
        List<AssignedWorkorder> GetAll(DateTime? date);
        int Count();
    }
}