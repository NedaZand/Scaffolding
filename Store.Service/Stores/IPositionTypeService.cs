using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;

namespace Store.Service.Stores
{
    public interface IPositionTypeService
    {

        PositionType GetById(int id);
        void Insert(PositionType entity);
        void Remove(PositionType entity);
        void Update(PositionType entity);
        List<PositionType> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null);
        List<PositionType> GetAll(string title = null);
        int Count(string search);
    }
}