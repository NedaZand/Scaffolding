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
using Store.Core.Domain.StoreTables;

namespace Store.Service
{
    public class WorkingGroupPersonnelService : IWorkgroupPersonnelService
    {
        private readonly IRepository<WorkingGroupPersonnel> _repository;
        private readonly StoreContext _context;

        public WorkingGroupPersonnelService(IRepository<WorkingGroupPersonnel> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(WorkingGroupPersonnel entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(WorkingGroupPersonnel entity)
        {
            _repository.Remove(entity);
        }
        public void Remove(IEnumerable<WorkingGroupPersonnel> entities)
        {
            _repository.Remove(entities);
        }
        public void Update(WorkingGroupPersonnel entity)
        {
            _repository.Edit(entity);
        }
        public List<WorkingGroupPersonnel> GetAll()
        {
            var list = _repository.Entities.ToList();

            return list;
        }
        public WorkingGroupPersonnel GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<WorkingGroupPersonnel> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection)
       {
            var list = _repository.Entities.ToList();
            

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Workgroup!=null && x.Workgroup.Title.Contains(search)).ToList();
            }
            
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string title)
        {
            var list = _repository.Entities.ToList();
         
            return list.Count();
        }
    }
}
