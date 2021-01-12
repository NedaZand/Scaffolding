using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IPropertyService
    {

        Property GetById(int id);
        void Insert(Property entity);
        void Remove(Property entity);
        void Update(Property entity);
        List<Property> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<Property> GetAll(string title = null);
        int Count(string search = null);
    }
}