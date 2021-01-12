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
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _repository;
        private readonly StoreContext _context;
        public MessageService(IRepository<Message> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Message entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(Message entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Message entity)
        {
            _repository.Edit(entity);
        }
        
        public Message GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Message> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null)
        {
            var list = _repository.Entities.OrderByDescending(x=>x.CreatedDate).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Subject.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Content.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
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
        public List<Message> GetAll()
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();
           
            return list.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string search)
        {
            var list = _repository.Entities.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Subject.Trim().Equals(search.Trim()) || x.Content.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }

            return list.Count(); 
        }
    }
}
