using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IOutputMaterialHasEquipmentService
    {
        List<outputMaterialHasEquipment> GetAllById(int id);
        bool Insert(outputMaterialHasEquipment entity);
        void Remove(outputMaterialHasEquipment entity);
    }
}