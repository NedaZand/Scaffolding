using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IScaffoldingService
    {

        Scaffolding GetById(int id);
        bool Insert(Scaffolding entity, out int id);
        void Remove(Scaffolding entity);
        void Update(Scaffolding entity);
        List<Scaffolding> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, int? width = null, int? height = null, int? Length = null, DateTime? fromSafetyTagExpire = null, DateTime? toSafetyTagExpire = null, int? buildingId = null, int? earthId = null, int? workOrderId = null, int? scaffoldTypeId = null, string title = null, string tag = null,bool alertExpire=false, int scaffoldId = 0, bool notTag = false);
        List<Scaffolding> GetAll(string title = null);
        int Count(string search, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, int? width = null, int? height = null, int? Length = null, DateTime? fromSafetyTagExpire = null, DateTime? toSafetyTagExpire = null, int? buildingId = null, int? earthId = null, int? workOrderId = null, int? scaffoldTypeId = null, string title = null, string tag = null,bool alertExpire=false, int scaffoldId = 0, bool notTag = false);

    }
}