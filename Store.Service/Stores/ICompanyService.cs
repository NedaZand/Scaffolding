using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;

namespace Store.Service.Stores
{
    public interface ICompanyService
    {

        Company GetById(int id);
        void Insert(Company entity);
        void Remove(Company entity);
        void Update(Company entity);
        List<Company> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null);
        List<Company> GetAll(string title = null, int? parentId = null);
        int Count(string search);
        List<Company> GetAllCompaniesByParentCompanyId(int? parentCompanyId);
        }
}