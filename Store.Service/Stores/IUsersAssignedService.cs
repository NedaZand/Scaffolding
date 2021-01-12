using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;

namespace Store.Service.Stores
{
    public interface IWorkorderAssignedUsersService
    {
        WorkorderAssignedUsers GetById(int id);
        void Insert(WorkorderAssignedUsers entity);
        void Insert(IEnumerable<WorkorderAssignedUsers> entities);
        void Remove(WorkorderAssignedUsers entity);
        void Update(WorkorderAssignedUsers entity);
        List<WorkorderAssignedUsers> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, int detailId = 0,int workorderId=0);
        List<WorkorderAssignedUsers> GetAll(string search = null, int workorderId = 0);
        int Count(int detailId = 0,int workorderId=0);
    }
}