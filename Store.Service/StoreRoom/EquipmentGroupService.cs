using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Data;

namespace Store.Service.StoreRoom
{
    public class EquipmentGroupService : IEquipmentGroupService
    {
        private readonly IRepository<EquipmentGroup> _repository;
        private readonly StoreContext _Context;
        public EquipmentGroup GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(EquipmentGroup entity)
        {
            _repository.Insert(entity);
        }

        public void Remove(EquipmentGroup entity)
        {
            _repository.Remove(entity);
        }

        public void Update(EquipmentGroup entity)
        {
            _repository.Edit(entity);
        }
    }
}
