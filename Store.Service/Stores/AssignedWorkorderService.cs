using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class AssignedWorkorderService : IAssignedWorkorderService
    {
        private readonly IRepository<AssignedWorkorder> _repository;
        private readonly StoreContext _context;
        public AssignedWorkorderService(IRepository<AssignedWorkorder> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(AssignedWorkorder entity)
        {
            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ///آپدیت کردن وضعیت WorkOrder

                        var getWorkOrder = context.WorkOrder.Find(entity.WorkOrderId);
                        getWorkOrder.Status = WorkOrderStatus.InProcess;
                        
                        context.Entry(getWorkOrder).State = EntityState.Modified;
                        context.AssignedWorkorder.Add(entity);
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch
                    {
                        dbcxtransaction.Rollback();
                    }
                }
            }
            // _repository.Insert(entity);
        }
        public void Insert(IEnumerable<AssignedWorkorder> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(AssignedWorkorder entity)
        {
            _repository.Remove(entity);
        }
        public void Update(AssignedWorkorder entity)
        {
            _repository.Edit(entity);
        }
        
        public AssignedWorkorder GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<AssignedWorkorder> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var list = _repository.Entities.OrderByDescending(x=>x.CreatedDate).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }
           
            
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<AssignedWorkorder> GetAll(DateTime? date)
        {
            var list = _repository.Entities.ToList();
            if (date.HasValue)
            {
                list = list.Where(x => x.Details.Where(z => z.Date.Date == date.Value.Date).Count() > 0).ToList();

            }

            return list.ToList();
        }
        public int Count()
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();

          
            return list.Count(); 
        }
    }
}
