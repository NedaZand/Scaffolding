using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IRepository<WorkOrder> _repository;
        private readonly IRepository<AssignedWorkorderDetail> _assignedWorkorderDetailRepository;
        private readonly StoreContext _context;
        public WorkOrderService(IRepository<WorkOrder> repository, IRepository<AssignedWorkorderDetail> assignedWorkorderDetailRepository)
        {
            _repository = repository;
            _assignedWorkorderDetailRepository = assignedWorkorderDetailRepository;
            _context = new StoreContext();
        }
        public void Insert(WorkOrder entity)
        {
            _repository.Insert(entity);
        }
        public void Insert(IEnumerable<WorkOrder> entities)
        {
            _repository.Insert(entities);
        }
        public void Remove(WorkOrder entity)
        {
            _repository.Remove(entity);
        }
        public void Update(WorkOrder entity)
        {
            _repository.Edit(entity);
        }
        
        public WorkOrder GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<WorkOrder> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, WorkOrderStatus? status = null,WorkOrderType?type=null, WorkOrderPriority? priority=null , string title = null, string tag = null, string description = null, int? company = null, int? scaffoldingId =null)
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Tag.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Title.Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >=fromDate);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.Date <= toDate);
            }
            if (fromExpireDate.HasValue)
            {
                query = query.Where(x => x.ExpireDate >= fromExpireDate);
            }
            if (toExpireDate.HasValue)
            {
                query = query.Where(x => x.ExpireDate <= toExpireDate);
            }
            if (status.HasValue && status != WorkOrderStatus.Select)
                query = query.Where(x => x.Status == status);

            if (company.HasValue && company!=0)
                query = query.Where(x => x.CompanyId == company);

            if (priority.HasValue && priority!= WorkOrderPriority.Unassigned)
                query = query.Where(x => x.Priority == priority);

            if (type.HasValue && type != WorkOrderType.Unassigned)
                query = query.Where(x => x.TypeId == type);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(x => x.Title.Contains(title));

            if (!string.IsNullOrEmpty(tag))
                query = query.Where(x => x.Tag.Contains(tag));

            //if (!string.IsNullOrEmpty(description))
            //    query = query.Where(x => x.Description.Contains(description));

            if (scaffoldingId.HasValue)
            {
                query = query.Where(x => x.ScaffoldingId == scaffoldingId.Value);
            }

            var list = query.OrderByDescending(x => x.CreatedDate).ToList();

            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<WorkOrder> GetAll(int companyId = 0, List<Company> companies = null, string search = null, DateTime? date = null, WorkOrderStatus[] status = null, WorkOrderType? type = null, int scaffoldingId = 0,bool showTodayAssigned=false)
        {
            var list = _repository.Table.ToList();

            if(showTodayAssigned)
            {
                var detailList = _assignedWorkorderDetailRepository.Table.ToList().Where(x => x.Date.Date == DateTime.Now.Date);

                //list = list.Where(x => detailList.Where(y => x.Id != y.WorkorderId).Count() > 0).ToList();
                if(detailList.Count()>0)
                list = list.Where(x => !detailList.Any(y => x.Id == y.WorkorderId)).ToList();
            }

            if (status != null)
                list = list.Where(x => status.Contains(x.Status)).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Description.Trim().ToLower().Equals(search.Trim().ToLower())).ToList();
            }

         

            if (companies != null)
            {
                list = list.Where(x => companies.Select(c => c.Id).Contains(x.CompanyId)
                || x.UnitId != null && companies.Select(c => c.Id).Contains(x.UnitId.Value) || x.SectionId != null && companies.Select(c => c.Id).Contains(x.SectionId.Value)).ToList();
            }
            if (companyId != 0)
            {
                list = list.Where(x => x.CompanyId == companyId).ToList();
            }
            if (type != null)
            {
                list = list.Where(x => x.TypeId == type).ToList();
            }

            if (scaffoldingId != 0)
            {
                list = list.Where(x => x.ScaffoldingId == scaffoldingId).ToList();
            }
           
            return list.ToList();
        }

        public int Count(string search = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, WorkOrderStatus? status = null, WorkOrderType? type = null, WorkOrderPriority? priority = null, string title = null, string tag = null, string description = null, int? company = null,int? scaffoldingId=null)
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Tag.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Title.Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >= fromDate);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.Date <= toDate);
            }
            if (fromExpireDate.HasValue)
            {
                query = query.Where(x => x.ExpireDate >= fromExpireDate);
            }
            if (toExpireDate.HasValue)
            {
                query = query.Where(x => x.ExpireDate <= toExpireDate);
            }
            if (status.HasValue && status != WorkOrderStatus.Select)
                query = query.Where(x => x.Status == status);

            if (company.HasValue)
                query = query.Where(x => x.CompanyId == company);

            if (priority.HasValue && priority != WorkOrderPriority.Unassigned)
                query = query.Where(x => x.Priority == priority);

            if (type.HasValue && type != WorkOrderType.Unassigned)
                query = query.Where(x => x.TypeId == type);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(x => x.Title.Contains(title));

            if (!string.IsNullOrEmpty(tag))
                query = query.Where(x => x.Tag.Contains(tag));

            //if (!string.IsNullOrEmpty(description))
            //    query = query.Where(x => x.Description.Contains(description));

            if (scaffoldingId.HasValue)
            {
                query = query.Where(x => x.ScaffoldingId == scaffoldingId);
            }

            var list = query.OrderByDescending(x => x.CreatedDate).ToList();


            return list.Count();
        }
       
    }
}
