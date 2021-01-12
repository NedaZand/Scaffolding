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
    public class ScaffoldHasEquipmentService : IScaffoldHasEquipmentService
    {
        private readonly IRepository<ScaffoldHasEquipment> _repository;
        private readonly StoreContext _context;

        public ScaffoldHasEquipmentService(IRepository<ScaffoldHasEquipment> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(ScaffoldHasEquipment entity)
        {
            _repository.Insert(entity);
        }
        public void Insert(IEnumerable<ScaffoldHasEquipment> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(ScaffoldHasEquipment entity)
        {
            _repository.Remove(entity);
        }
        public void Update(ScaffoldHasEquipment entity)
        {
            _repository.Edit(entity);
        }
        
        public ScaffoldHasEquipment GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<ScaffoldHasEquipment> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null)
        {
            var list = _repository.Entities.OrderByDescending(x=>x.CreatedDate).ToList();

            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<ScaffoldHasEquipment> GetAll()
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();
           
            return list.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string search)
        {
            var list = _repository.Entities.ToList();
          
            return list.Count(); 
        }
    }
}
