using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Store.Service
{
    public interface IRoleService
    {
        List<ApplicationRole> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection);
        List<ApplicationRole> GetAll();
        ApplicationRole GetById(string id);
        void Insert(ApplicationRole entity);
        void Remove(ApplicationRole entity);
        void Update(ApplicationRole entity);
        int Count();
    }
}