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
    public class AssignedWorkorderDetailService : IAssignedWorkorderDetailService
    {
        private readonly IRepository<AssignedWorkorderDetail> _repository;
        private readonly StoreContext _context;

        public AssignedWorkorderDetailService(IRepository<AssignedWorkorderDetail> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public bool Insert(AssignedWorkorderDetail entity)
        {
            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ///آپدیت کردن وضعیت WorkOrder

                        var getWorkOrder = context.WorkOrder.Find(entity.WorkorderId);
                        getWorkOrder.Status = WorkOrderStatus.InProcess;
                        getWorkOrder.StartDate = entity.StartDate;
                        getWorkOrder.EndDate = entity.EndDate;

                        //context.Entry(getWorkOrder).CurrentValues.SetValues(getWorkOrder);
                        context.Entry(getWorkOrder).State = EntityState.Modified;
                        //entity.WorkorderAssignedUsers = new List<WorkorderAssignedUsers>();
                        context.AssignedWorkorderDetail.Add(entity);
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "Inser Method In AssignedWorkorderDetailService");
                        return false;
                    }
                }
            }
            return true;
            // _repository.Insert(entity);
        }

        public void Insert(IEnumerable<AssignedWorkorderDetail> entities)
        {

            _repository.Insert(entities);
        }
        public bool Remove(AssignedWorkorderDetail entity)
        {
            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var getEntity = context.AssignedWorkorderDetail.Find(entity.Id);

                        foreach (var item in entity.WorkorderAssignedUsers)
                        {
                            var getUser = context.WorkorderAssignedUser.Find(item.Id);
                            context.WorkorderAssignedUser.Remove(getUser);
                        }

                        context.AssignedWorkorderDetail.Remove(getEntity);
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "RemoveMethodInAssignedWorkorderDetailServiceService");
                        return false;
                    }
                }
            }
            return true;
            // _repository.Remove(entity);
        }
        public bool Update(AssignedWorkorderDetail entity)
        {

            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ///آپدیت کردن وضعیت WorkOrder

                        int getArea = 0;
                        var detail = context.AssignedWorkorderDetail.Find(entity.Id);
                        var getWorkOrder = context.WorkOrder.Find(detail.WorkorderId);
                        if (entity.Status != WorkOrderStatus.Select && entity.Status != WorkOrderStatus.Unassigned)
                            getWorkOrder.Status = entity.Status;
                        getWorkOrder.StartDate = entity.StartDate;
                        getWorkOrder.EndDate = entity.EndDate;



                        context.Entry(getWorkOrder).State = EntityState.Modified;
                        detail.TotalArea = entity.TotalArea;

                        foreach (var per in detail.WorkorderAssignedUsers.ToList())
                        {
                            var perFind = context.WorkorderAssignedUser.Find(per.Id);
                            if (perFind != null)
                                context.WorkorderAssignedUser.Remove(perFind);
                        }


                        detail.WorkorderAssignedUsers = new List<WorkorderAssignedUsers>();
                        detail.WorkorderAssignedUsers = entity.WorkorderAssignedUsers;
                        try
                        {

                            getArea = ((entity.TotalArea) / (detail.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId).Count())) / detail.WorkorderAssignedUsers.Count();

                        }
                        catch (Exception)
                        {

                            getArea = 0;
                        }
                        foreach (var user in detail.WorkorderAssignedUsers.ToList())
                        {
                            user.Area = getArea;



                        }


                        //detail.WorkorderAssignedUsers = new List<WorkorderAssignedUsers>();
                        detail.Date = entity.Date;
                        context.Entry(detail).State = EntityState.Modified;


                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "Update Method In AssignedWorkorderDetailService");
                        return false;
                    }
                }
            }
            return true;

            //_repository.Edit(entity);
        }

        public AssignedWorkorderDetail GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<AssignedWorkorderDetail> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, int workorderId = 0)
        {
            var list = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Description.Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            if (workorderId != 0)
                list = list.Where(x => x.WorkorderId == workorderId);

            return list.OrderByDescending(x => x.CreatedDate).ToList().GetRange(start, Math.Min(lenght, list.ToList().Count - start)).ToList();
        }
        public IEnumerable<AssignedWorkorderDetail> GetAll(DateTime? fromDate = null)
        {
            //var list = _repository.Entities.ToList().OrderByDescending(x => x.Date.Date).GroupBy(x =>x.Date.Date).ToList();

            var query = _repository.Entities.ToList();


            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date.Date == fromDate.Value.Date).ToList();
            }

            return query;
        }
        public int Count(int workorderId = 0, int skip = 0)
        {
            var list = _repository.Table;

            if (workorderId != 0)
                list = list.Where(x => x.WorkorderId == workorderId);


            return list.ToList().Count();
        }
    }
}
