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
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Attendance> _repository;
        private readonly StoreContext _context;
        public AttendanceService(IRepository<Attendance> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Attendance entity)
        {
            _repository.Insert(entity);
        }

        public void Insert(IEnumerable<Attendance> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(Attendance entity)
        {
            //entity.IsDeletede = true;
            //this.Update(entity);
            _repository.Remove(entity);
        }
        public void Update(Attendance entity)
        {
            _repository.Edit(entity);
        }
        public void Update(IEnumerable<Attendance> entity)
        {
            _repository.Edit(entity);
        }

        public Attendance GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Attendance> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null,int? persoonelCode=null,PresenceStatus? status=null)
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x =>x.Personnel!=null && x.Personnel.UserNameFmaily.Trim().ToLower().Contains(search.Trim().ToLower()) ||  x.PersonnelCode.ToString().Trim().Contains(search.Trim().ToLower()) || x.Description.Trim().ToLower().Contains(search.Trim().ToLower()) );
            }


            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >= fromDate);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.Date <= toDate);
            }
            if (persoonelCode.HasValue && persoonelCode!=0)
            {
                query = query.Where(x => x.PersonnelCode==persoonelCode);
            }
            if (status.HasValue && status!=PresenceStatus.Unknown)
            {
                query = query.Where(x => x.PresenceStatus==status);
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
        public List<Attendance> GetAll(DateTime? date,PresenceStatus? status)
        {
            var query = _repository.Table.ToList();

            if (date.Value!=null)
            {
               query = query.Where(x => x.Date.Date==date.Value.Date).ToList();
            }
            if (status.HasValue)
            {
                query = query.Where(x => x.PresenceStatus == status).ToList();
            }

            return query.ToList();
        }
        public int Count(string search=null,DateTime? fromDate=null,DateTime? toDate=null, int? persoonelCode = null, PresenceStatus? status = null)
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Personnel != null && x.Personnel.UserNameFmaily.Trim().ToLower().Contains(search.Trim().ToLower()) || x.PersonnelCode.ToString().Trim().Contains(search.Trim().ToLower()) || x.Description.Trim().ToLower().Contains(search.Trim().ToLower()));
            }



            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >= fromDate);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.Date <= toDate);
            }
            if (persoonelCode.HasValue && persoonelCode != 0)
            {
                query = query.Where(x => x.PersonnelCode == persoonelCode);
            }
            if (status.HasValue && status != PresenceStatus.Unknown)
            {
                query = query.Where(x => x.PresenceStatus == status);
            }
            
            return query.ToList().Count(); 
        }
    }
}
