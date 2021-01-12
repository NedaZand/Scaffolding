using Store.Core.Domain.StoreTables.User;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Store.Service.User
{
    public class PermissionService : IPermissionService
    {

        #region Fields
        private readonly IRepository<Permission> _repository;
        private readonly StoreContext _context;
        private readonly IRoleService _roleService;
        public PermissionService(IRepository<Permission> repository, IRoleService roleService)
        {
            _repository = repository;
            _context = new StoreContext();
            _roleService = roleService;
        }
        #endregion Fields


        #region Methods

        public List<Permission> GetAll()
        {
            return _repository.Entities.ToList();
        }
        public Permission GetById(int id)
        {
            return _repository.GetById(id);
        }
        public bool HasAccess(Permission permission, ApplicationUser user)
        {
            foreach (var item in user.ApplicationRoles)
            {
                if (item.Name == "admin")
                    return true;
            }

            

            //if (user.Permissions.Where(x=>x.SystemName == permission.SystemName).Count() > 0)
            //{
            //    //var StoreId = user.HotelStoreId;
            //    //var allowPermissions = this.GetAll().Where(d => d.HotelAgencies.Where(z => z.Id == StoreId).Count() > 0);
            //    //if (allowPermissions.Where(s => s.SystemName == permission.SystemName).Count() > 0)
            //    //{
            //    //    return true;
            //    //}
            //}
            return false;
        }
        public void Insert(Permission entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(Permission entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Permission entity)
        {
            _repository.Edit(entity);
        }
        public List<Permission> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection)
        {
            var list = _repository.Entities.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Category.Contains(search) || x.Title.Contains(search)).ToList();
            }
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).OrderByDescending(x => x.Category).ToList();
        }
        #endregion Methods
    }
}
