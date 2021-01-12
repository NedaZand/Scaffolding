using Store.Core.Domain.StoreTables.User;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.User
{
    public class ApplicationRoleService : IApplicationRoleService
    {
        private readonly IRepository<ApplicationRole> _repository;
        private readonly StoreContext _context;


        public ApplicationRoleService(IRepository<ApplicationRole> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(ApplicationRole entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(ApplicationRole entity)
        {
            _repository.Remove(entity);
        }
        public void Update(ApplicationRole entity)
        {
            _repository.Edit(entity);
        }
        public List<ApplicationRole> GetAll()
        {
            return _repository.Entities.ToList();
            //var roleStore = new RoleStore<IdentityRole>(_context);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);

            //return roleManager.Roles.ToList();
        }
        public ApplicationRole GetById(string id)
        {
            var f = _repository.GetById(id);
            return _repository.GetById(id);
        }
        public int Count()
        {
            return _repository.Entities.Count();
        }
        public List<ApplicationRole> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection)
        {
            var list = _repository.Entities.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Name.Contains(search) || x.Name.Contains(search)).ToList();
            }
            switch (sortColumn)
            {
                case 0:
                    list = sortDirection == "asc" ? list.OrderBy(x => x.Name).ToList() : list.OrderByDescending(x => x.Name).ToList();
                    break;

                default:
                    break;
            }
            return list.GetRange(start, Math.Min(lenght, list.Count - start));
        }
    }
}
