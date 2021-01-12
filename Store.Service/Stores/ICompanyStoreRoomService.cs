using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface ICompanyStoreRoomService
    {

        CompanyStoreRoom GetById(int id);
        void Insert(CompanyStoreRoom entity);
        void Remove(CompanyStoreRoom entity);
        void Update(CompanyStoreRoom entity);
        List<CompanyStoreRoom> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<CompanyStoreRoom> GetAll(string title = null);
        int Count(string search = null);
    }
}