using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.User;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class EquipmentHasPropertyService : IEquipmentHasPropertyService
    {
        private readonly IRepository<EquipmentHasProperty> _repository;
        private readonly StoreContext _context;
        public EquipmentHasPropertyService(IRepository<EquipmentHasProperty> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(EquipmentHasProperty entity)
        {
            _repository.Insert(entity);
        }

        public void Insert(IEnumerable<EquipmentHasProperty> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(EquipmentHasProperty entity)
        {
            _repository.Remove(entity);
        }
        public void Update(EquipmentHasProperty entity)
        {
            _repository.Edit(entity);
        }
        
        public EquipmentHasProperty GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<EquipmentHasProperty> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, int equipmentId = 0)
        {
            var list = _repository.Table;
            if (equipmentId != 0)
                list = list.Where(x => x.EquipmentId == equipmentId);

            return list.OrderByDescending(x=>x.CreatedDate).ToList().GetRange(start, Math.Min(lenght, list.ToList().Count - start)).ToList();
        }
        public List<EquipmentHasProperty> GetAll()
        {
            var list = _repository.Entities.ToList();
           
           
            return list.ToList();
        }
        public int Count(string search, int equipmentId = 0)
        {
            var list = _repository.Table;
            if (equipmentId != 0)
                list = list.Where(x => x.EquipmentId == equipmentId);

            return list.ToList().Count(); 
        }
    }
}
