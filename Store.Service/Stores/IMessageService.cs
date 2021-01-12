using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IMessageService
    {
        Message GetById(int id);
        void Insert(Message entity);
        void Remove(Message entity);
        void Update(Message entity);
        List<Message> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null);
        List<Message> GetAll();
        int Count(string search = null);
    }
}