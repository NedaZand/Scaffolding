using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;

namespace Store.Service.Stores
{
    public interface IEmployeeTypeService
    {

        EmployeeType GetById(int id);
        void Insert(EmployeeType entity);
        void Remove(EmployeeType entity);
        void Update(EmployeeType entity);
        List<EmployeeType> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null);
        List<EmployeeType> GetAll(string title = null);
        int Count(string search);
    }
}