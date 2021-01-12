using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables;

namespace Store.Service
{
    public interface IWorkgroupPersonnelService
    {
        List<WorkingGroupPersonnel> GetAll();
        WorkingGroupPersonnel GetById(int id);
        void Insert(WorkingGroupPersonnel entity);
        void Remove(WorkingGroupPersonnel entity);
        void Remove(IEnumerable<WorkingGroupPersonnel> entities);
        void Update(WorkingGroupPersonnel entity);
        List<WorkingGroupPersonnel> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection);
        int Count(string title);
    }
}