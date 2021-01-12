using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Service.Stores
{
    public interface IAnswerService
    {

        Answer GetById(int id);
        void Insert(Answer entity);
        bool Insert(IEnumerable<Answer> entities, int workOrderId, string expertName, int scaffoldingId, DateTime? registrationDate, string permitNumber, int personnelId, int realArea = 0, int score = 0);
        void Remove(Answer entity);
        bool Update(IEnumerable<Answer> entities, int workOrderId, string expertName, int scaffoldingId, DateTime? registrationDate, string permitNumber, int personnelId, int realArea = 0, int score = 0);
        List<Answer> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<Answer> GetAll(string title = null);
        int Count(string search = null);
    }
}