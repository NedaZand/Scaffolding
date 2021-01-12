using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;

namespace Store.Service.User
{
    public interface IPermissionService
    {
        List<Permission> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection);
        List<Permission> GetAll();
        Permission GetById(int id);
        bool HasAccess(Permission permission, ApplicationUser user);
        void Insert(Permission entity);
        void Remove(Permission entity);
        void Update(Permission entity);
    }
}