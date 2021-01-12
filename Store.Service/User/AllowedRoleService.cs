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
    public class AllowedRoleService : IAllowedRoleService
    {
        private readonly IRepository<AllowedRole> _repository;
        private readonly StoreContext _context;

        public AllowedRoleService(IRepository<AllowedRole> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(AllowedRole entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(AllowedRole entity)
        {
            _repository.Remove(entity);
        }
        public void Update(AllowedRole entity)
        {
            _repository.Edit(entity);
        }
        public List<AllowedRole> GetAll()
        {
            return _repository.Entities.ToList();
        }
        public AllowedRole GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<AllowedRole> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection)
        {
            var list = _repository.Entities.ToList();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    list = list.Where(x => x.UserName.Contains(search) || x.Email.Contains(search)).ToList();
            //}
            //switch (sortColumn)
            //{
            //    case 0:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Email).ToList() : list.OrderByDescending(x => x.UserName).ToList();
            //        break;
            //    case 1:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.UserName).ToList() : list.OrderByDescending(x => x.UserName).ToList();
            //        break;
            //    default:
            //        break;
            //}
            return list.GetRange(start, Math.Min(lenght, list.Count - start));
        }
        public void RemoveAll(List<AllowedRole> allowedRoles)
        {
            _repository.Remove(allowedRoles);
        }
    }
}
