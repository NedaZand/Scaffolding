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
    public class AssignedTaskService : IAssignedTaskService
    {
        private readonly IRepository<AssignedTask> _repository;
        private readonly StoreContext _context;
        public AssignedTaskService(IRepository<AssignedTask> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(AssignedTask entity)
        {
            _repository.Insert(entity);
        }

        public void Insert(IEnumerable<AssignedTask> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(AssignedTask entity)
        {
            _repository.Remove(entity);
        }
        public void Update(AssignedTask entity)
        {
            _repository.Edit(entity);
        }
        public void Update(IEnumerable<AssignedTask> entity)
        {
            _repository.Edit(entity);
        }

        public AssignedTask GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<AssignedTask> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, int? routinId = null, int? personnelCode = null)
        {
            var query = _repository.Table.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }

            if (routinId.HasValue && routinId != 0 && routinId != null)
            {
                query = query.Where(x => x.RoutineId == routinId).ToList();
            }
            if (personnelCode.HasValue)
            {
                query = query.Where(x => x.Users.Where(u => u.PersonnelCode == personnelCode).Count() > 0).ToList();
            }
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >= fromDate).ToList();
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.Date <= toDate).ToList();
            }

            var list = query.OrderByDescending(x => x.CreatedDate).ToList();

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

        public IEnumerable<AssignedTask> GetAll(DateTime? fromDate = null)
        {
            var query = _repository.Entities.ToList();

            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date.Date == fromDate.Value.Date).ToList();
            }
            return query;
        }
        public int Count(string search, DateTime? fromDate = null, DateTime? toDate = null, int? routinId = null, int? personnelCode = null)
        {
            var query = _repository.Table.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }
            if (routinId.HasValue && routinId != 0 && routinId != null)
            {
                query = query.Where(x => x.RoutineId == routinId).ToList();
            }
            if (routinId.HasValue)
            {
                query = query.Where(x => x.RoutineId == routinId).ToList();
            }
            if (personnelCode.HasValue)
            {
                query = query.Where(x => x.Users.Where(u => u.PersonnelCode == personnelCode).Count() > 0).ToList();
            }
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >= fromDate).ToList();
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.Date <= toDate).ToList();
            }

            return query.ToList().Count;
        }
    }
}
