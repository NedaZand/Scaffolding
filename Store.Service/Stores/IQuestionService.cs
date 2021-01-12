using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IQuestionService
    {

        Question GetById(int id);
        void Insert(Question entity);
        void Remove(Question entity);
        void Update(Question entity);
        List<Question> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<Question> GetAll(string title = null);
        int Count(string search = null);
    }
}