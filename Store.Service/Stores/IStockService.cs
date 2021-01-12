using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IStockService
    {

        Stock GetById(int id);
        void Insert(Stock entity);
        void Remove(Stock entity);
        void Update(Stock entity);
        List<Stock> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, int? equipmentId = null);
        List<Stock> GetAll(int? equipmentId = null);
        int Count(string search, int? equipmentId = null);

    }
}
