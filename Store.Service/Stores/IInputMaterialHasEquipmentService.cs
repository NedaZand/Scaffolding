using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IInputMaterialHasEquipmentService
    {

        List<inputMaterialHasEquipment> GetAllById(int id);
        bool Insert(inputMaterialHasEquipment entity, InputMaterial inputMaterial);
        void Remove(inputMaterialHasEquipment entity);
    }
}