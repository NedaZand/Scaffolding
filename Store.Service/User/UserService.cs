using Store.Core.Domain.StoreTables.User;
using Store.Data;
using Store.Service.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Store.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _repository;
        private readonly StoreContext _context;

        public UserService(IRepository<ApplicationUser> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(ApplicationUser entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(ApplicationUser entity)
        {
            _repository.Remove(entity);
        }
        public void Update(ApplicationUser entity)
        {
            _repository.Edit(entity);
        }
        public List<ApplicationUser> GetAll()
        {
            var list = _repository.Entities.ToList();

            return list;
        }
        public ApplicationUser GetById(string id)
        {
            return _repository.GetById(id);
        }
        public string AddUser(ApplicationUser entity)
        {
            ApplicationUserStore store = new ApplicationUserStore(_context);
            ApplicationUserManager manager = new ApplicationUserManager(store);
            var result = manager.CreateAsync(entity);
            if (!result.Result.Succeeded)
            {
                return result.Result.Errors.First();
            }
            return "";
        }
        public async Task<List<ApplicationUser>> FindByRole(string role)
        {
            ApplicationUserStore store = new ApplicationUserStore(_context);
            ApplicationUserManager manager = new ApplicationUserManager(store);

            var users = new List<ApplicationUser>();
            foreach (var item in manager.Users)
            {
                if (await manager.IsInRoleAsync(item.Id, role))
                {
                    users.Add(item);
                }
            }
            return users;
        }
        public List<ApplicationUser> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection)
       {
            var list = _repository.Entities.ToList();
            

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.UserName.Contains(search) || x.Email!=null && x.Email.Contains(search) || x.PersonnelCode != null && x.PersonnelCode.Contains(search)).ToList();
            }

            switch (sortColumn)
            {
                case 0:
                    list = sortDirection == "asc" ? list.OrderBy(x => x.Email).ToList() : list.OrderByDescending(x => x.UserName).ToList();
                    break;
                case 1:
                    list = sortDirection == "asc" ? list.OrderBy(x => x.UserName).ToList() : list.OrderByDescending(x => x.UserName).ToList();
                    break;
                default:
                    break;
            }
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).OrderByDescending(x => x.CreateDate).ToList();
        }
        public int UserCount()
        {
            var list = _repository.Entities.ToList();
         
            return list.Count();
        }
    }
}
