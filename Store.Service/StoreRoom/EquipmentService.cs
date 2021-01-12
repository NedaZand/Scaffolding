using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Data;

namespace Store.Service.StoreRoom
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IRepository<Equipment> _repository;
        private readonly StoreContext _Context;

        public Equipment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Equipment entity)
        {
            _repository.Insert(entity);
        }

        public void Remove(Equipment entity)
        {
            _repository.Remove(entity);
        }

        public void Update(Equipment entity)
        {
            _repository.Edit(entity);
        }
    }
}
