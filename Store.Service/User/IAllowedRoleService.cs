using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;

namespace Store.Service
{
    public interface IAllowedRoleService
    {
        List<AllowedRole> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection);
        List<AllowedRole> GetAll();
        AllowedRole GetById(int id);
        void Insert(AllowedRole entity);
        void Remove(AllowedRole entity);
        void Update(AllowedRole entity);
        void RemoveAll(List<AllowedRole> allowedRoles);
    }
}