using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;

namespace Store.Service
{
    public interface IUserService
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(string id);
        void Insert(ApplicationUser entity);
        void Remove(ApplicationUser entity);
        void Update(ApplicationUser entity);
        Task<List<ApplicationUser>> FindByRole(string role);
        List<ApplicationUser> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection);
        int UserCount();
    }
}