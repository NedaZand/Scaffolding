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
    public class PersonnelDetailService : IPersonnelDetailService
    {
        private readonly IRepository<PersonnelDetail> _repository;
        private readonly StoreContext _context;
        public PersonnelDetailService(IRepository<PersonnelDetail> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(PersonnelDetail entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(PersonnelDetail entity)
        {
            _repository.Remove(entity);
        }
        public void Update(PersonnelDetail entity)
        {
            _repository.Edit(entity);
        }
        
        public PersonnelDetail GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<PersonnelDetail> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null)
        {
            var list = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower()));
            }


           
            return list.ToList().GetRange(start, Math.Min(lenght, list.ToList().Count - start)).ToList();
        }
        public List<PersonnelDetail> GetAll(string search = null)
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

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            return list.Count(); 
        }
    }
}
