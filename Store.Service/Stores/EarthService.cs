using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class EarthService : IEarthService
    {
        private readonly IRepository<Earth> _repository;
        private readonly StoreContext _context;
        public EarthService(IRepository<Earth> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Earth entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(Earth entity)
        {
            //entity.IsDeletede = true;
            //this.Update(entity);
            _repository.Remove(entity);
        }
        public void Update(Earth entity)
        {
            _repository.Edit(entity);
        }
        
        public Earth GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Earth> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null,string title=null)
        {
            var list = _repository.Entities.OrderByDescending(x=>x.CreatedDate).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }


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
        public List<Earth> GetAll(string title=null)
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();
            if (!string.IsNullOrEmpty(title))
            {
               list = list.Where(x => x.Title.Trim().Equals(title.Trim())).ToList();
            }
           
            return list.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string search)
        {
            var list = _repository.Entities.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Trim().Equals(search.Trim())).ToList();
            }

            return list.Count(); 
        }
    }
}
