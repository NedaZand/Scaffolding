using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.User;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Service.DateTimeExtentions;
namespace Store.Service.Stores
{
    public class PesonnelHasDetailService : IPesonnelHasDetailService
    {
        private readonly IRepository<PesonnelHasDetail> _repository;
        private readonly StoreContext _context;
        public PesonnelHasDetailService(IRepository<PesonnelHasDetail> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(PesonnelHasDetail entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(PesonnelHasDetail entity)
        {
            _repository.Remove(entity);
        }
        public void Update(PesonnelHasDetail entity)
        {
            _repository.Edit(entity);
        }
        
        public PesonnelHasDetail GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<PesonnelHasDetail> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null)
        {
            var list = _repository.Table;

            //if (!string.IsNullOrEmpty(search))
            //{
            //    list = list.Where(x => x..Trim().ToLower().Contains(search.Trim().ToLower()));
            //}


           
            return list.ToList().GetRange(start, Math.Min(lenght, list.ToList().Count - start)).ToList();
        }
        public List<PesonnelHasDetail> GetAll(string search = null)
        {
            var list = _repository.Entities.ToList();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    list = list.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower()));
            //}

            return list.ToList();
        }
        public int Count(string search, DateTime? createDate = null, DateTime? editDate = null)
        {
            var list = _repository.Table;

            //if (!string.IsNullOrEmpty(search))
            //{
            //    list = list.Where(x => x.Value.Trim().ToLower().Contains(search.Trim().ToLower()));
            //}

            return list.Count(); 
        }
    }
}
