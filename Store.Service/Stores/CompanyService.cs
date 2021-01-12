using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.User;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _repository;
        private readonly StoreContext _context;
        public CompanyService(IRepository<Company> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Company entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(Company entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Company entity)
        {
            _repository.Edit(entity);
        }

        public Company GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Company> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || !string.IsNullOrEmpty(x.Address) && x.Address.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }


            //if (fromDate.HasValue)
            //{
            //    list = list.Where(x => x.DateEstablished>=fromDate).ToList();
            //}
            //if (toDate.HasValue)
            //{
            //    list = list.Where(x => x.DateEstablished <= toDate).ToList();
            //}
            //switch (sortColumn)
            //{
            //    case 1:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Title).ToList() : list.OrderByDescending(x => x.Title).ToList();
            //        break;
            //    case 2:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Description).ToList() : list.OrderByDescending(x => x.Description).ToList();
            //        break;
            //    default:
            //        break;
            //}
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<Company> GetAll(string title = null, int? parentId = null)
        {
            var query = _repository.Table.ToList();

            if (parentId!=0)
            {
                query = query.Where(x => x.ParentID == parentId).ToList();
            }


            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title.Trim().ToLower().Equals(title.Trim().ToLower())).ToList();
            }

            return query.OrderByDescending(x=>x.CreatedDate).ToList();
        }
        public int Count(string search)
        {
            var list = _repository.Entities.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || !string.IsNullOrEmpty(x.Address) && x.Address.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }

            return list.Count();
        }
        public virtual List<Company> GetAllCompaniesByParentCompanyId(int? parentCompanyId)
        {

            var query = _repository.Table;
            
            query = query.Where(c => c.ParentID == parentCompanyId);


            var categories = query.ToList();

            var childCategories = new List<Company>();
            //add child levels
            foreach (var category in categories)
            {
                childCategories.AddRange(GetAllCompaniesByParentCompanyId(category.Id));
            }
            categories.AddRange(childCategories);

            return categories;

        }

    }
}
