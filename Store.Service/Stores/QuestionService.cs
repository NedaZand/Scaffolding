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
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _repository;
        private readonly StoreContext _context;
        public QuestionService(IRepository<Question> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Question entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(Question entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Question entity)
        {
            _repository.Edit(entity);
        }
        
        public Question GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Question> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null,string title=null)
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Text.Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            var list = query.OrderByDescending(x => x.CreatedDate).ToList();
            
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<Question> GetAll(string title=null)
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();
            if (!string.IsNullOrEmpty(title))
            {
               list = list.Where(x => x.Text.Trim().Equals(title.Trim())).ToList();
            }
           
            return list.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string search)
        {
            var list = _repository.Table;
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Text.Trim().Equals(search.Trim()));
            }

            return list.ToList().Count(); 
        }
    }
}
