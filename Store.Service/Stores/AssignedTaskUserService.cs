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
    public class AssignedTaskUserService : IAssignedTaskUserService
    {
        private readonly IRepository<AssignedTaskUsers> _repository;
        private readonly StoreContext _context;
        public AssignedTaskUserService(IRepository<AssignedTaskUsers> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(AssignedTaskUsers entity)
        {
            _repository.Insert(entity);
        }

        public void Insert(IEnumerable<AssignedTaskUsers> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(AssignedTaskUsers entity)
        {
            _repository.Remove(entity);
        }
        public void Update(AssignedTaskUsers entity)
        {
            _repository.Edit(entity);
        }
        public void Update(IEnumerable<AssignedTaskUsers> entity)
        {
            _repository.Edit(entity);
        }

        public AssignedTaskUsers GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<AssignedTaskUsers> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null,int assignedTaskId=0)
        {
            var list = _repository.Entities.OrderByDescending(x=>x.CreatedDate).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }

            if (assignedTaskId != 0)
                list = list.Where(x => x.AssignedTaskId == assignedTaskId).ToList();
            //if (fromDate.HasValue)
            //{
            //    list = list.Where(x => x.DateEstablished>=fromDate).ToList();
            //}
            //if (toDate.HasValue)
            //{
            //    list = list.Where(x => x.DateEstablished <= toDate).ToList();
            //}
            //switch (sortColumn)
            //{
            //    case 1:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Title).ToList() : list.OrderByDescending(x => x.Title).ToList();
            //        break;
            //    case 2:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Description).ToList() : list.OrderByDescending(x => x.Description).ToList();
            //        break;
            //    default:
            //        break;
            //}
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<AssignedTaskUsers> GetAll(DateTime? date)
        {
            var list = _repository.Entities.ToList();
            
           
            return list.ToList();
        }
        public int Count()
        {
            return _repository.Table.Count(); 
        }
    }
}
