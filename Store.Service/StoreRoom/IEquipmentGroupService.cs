using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.StoreRoom
{
   public interface IEquipmentGroupService
    {
        EquipmentGroup GetById(int id);
        void Insert(EquipmentGroup entity);
        void Remove(EquipmentGroup entity);
        void Update(EquipmentGroup entity);
    }
}
