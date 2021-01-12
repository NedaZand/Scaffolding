using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IBuyMaterialService
    {

        BuyMaterial GetById(int id);
        bool Insert(BuyMaterial entity);
        bool Remove(BuyMaterial entity);
        bool Update(BuyMaterial entity);
        List<BuyMaterial> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null);
        List<BuyMaterial> GetAll(string title = null);
        int Count(string search, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null);
    }
}