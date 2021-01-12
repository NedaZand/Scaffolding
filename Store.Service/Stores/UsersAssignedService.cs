using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.User;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class WorkorderAssignedUsersService : IWorkorderAssignedUsersService
    {
        private readonly IRepository<WorkorderAssignedUsers> _repository;
        private readonly StoreContext _context;
        public WorkorderAssignedUsersService(IRepository<WorkorderAssignedUsers> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(WorkorderAssignedUsers entity)
        {
            
            _repository.Insert(entity);
        }
        public void Insert(IEnumerable<WorkorderAssignedUsers> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(WorkorderAssignedUsers entity)
        {
            _repository.Remove(entity);
        }
        public void Update(WorkorderAssignedUsers entity)
        {
            _repository.Edit(entity);
        }
        
        public WorkorderAssignedUsers GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<WorkorderAssignedUsers> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,int detailId = 0,int workorderId = 0)
        {
            var list = _repository.Table;

            if (workorderId != 0)
            {
                list = list.Where(x => x.WorkorderId == workorderId);
            }
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower()));
            }
          
            if(detailId != 0)
                list = list.Where(x => x.AssignedWorkorderDetailId==detailId);
           
            
            return list.ToList().GetRange(start, Math.Min(lenght, list.ToList().Count - start)).ToList();
        }
        public List<WorkorderAssignedUsers> GetAll(string search=null,int workorderId=0)
        {
            var list = _repository.Table;

            if (workorderId!=0)
            {
                list = list.Where(x => x.WorkorderId==workorderId);
            }
            if (!string.IsNullOrEmpty(search))
            {
               list = list.Where(x => x.Description.Trim().ToLower().Equals(search.Trim().ToLower()));
            }
           
            return list.ToList();
        }
        public int Count(int detailId = 0, int workorderId = 0)
        {
            var list = _repository.Table;

            if (workorderId != 0)
            {
                list = list.Where(x => x.WorkorderId == workorderId);
            }

            if (detailId != 0)
                list = list.Where(x => x.AssignedWorkorderDetailId == detailId);

            return list.ToList().Count();
            
        }
    }
}
