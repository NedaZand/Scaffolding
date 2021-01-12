using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using System.Linq;

namespace Store.Service.Stores
{
    public interface IAssignedWorkorderDetailService
    {
        
        AssignedWorkorderDetail GetById(int id);
        bool Insert(AssignedWorkorderDetail entity);
        void Insert(IEnumerable<AssignedWorkorderDetail> entities);
        bool Remove(AssignedWorkorderDetail entity);
        bool Update(AssignedWorkorderDetail entity);
        List<AssignedWorkorderDetail> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null,int assignedTaskId=0);
        IEnumerable<AssignedWorkorderDetail> GetAll(DateTime? fromDate = null);
        int Count(int assignedTaskId=0, int skip = 0);
    }
}