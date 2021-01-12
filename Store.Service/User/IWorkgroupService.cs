using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables;

namespace Store.Service
{
    public interface IWorkgroupService
    {
        List<Workgroup> GetAll(string title = null);
        Workgroup GetById(int id);
        void Insert(Workgroup entity);
        void Remove(Workgroup entity);
        void Update(Workgroup entity);
        List<Workgroup> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection);
        int Count(string title);
    }
}