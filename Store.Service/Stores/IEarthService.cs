using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IEarthService
    {

        Earth GetById(int id);
        void Insert(Earth entity);
        void Remove(Earth entity);
        void Update(Earth entity);
        List<Earth> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<Earth> GetAll(string title = null);
        int Count(string search = null);
    }
}