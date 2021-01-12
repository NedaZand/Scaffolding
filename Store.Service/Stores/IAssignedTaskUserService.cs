using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;

namespace Store.Service.Stores
{
    public interface IAssignedTaskUserService
    {

        AssignedTaskUsers GetById(int id);
        void Insert(AssignedTaskUsers entity);
        void Insert(IEnumerable<AssignedTaskUsers> entities);
        void Remove(AssignedTaskUsers entity);
        void Update(AssignedTaskUsers entity);
        void Update(IEnumerable<AssignedTaskUsers> entities);
        List<AssignedTaskUsers> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null,int assignedTaskId=0);
        List<AssignedTaskUsers> GetAll(DateTime? date);
        int Count();
    }
}