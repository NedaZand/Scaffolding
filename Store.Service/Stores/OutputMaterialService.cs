using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class OutputMaterialService : IOutputMaterialService
    {
        private readonly IRepository<OutputMaterial> _repository;
        public OutputMaterialService(IRepository<OutputMaterial> repository)
        {
            _repository = repository;
        }
        public bool Insert(OutputMaterial entity)
        {

            using (var context = new Store.Data.StoreContext())
            {
                var workoreder = context.WorkOrder.Find(entity.WorkOrderId);

                //var scaffold = context.Scaffolding.FirstOrDefault(x=>x.WorkOrderId==entity.WorkOrderId);

                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.OutputMaterial.Add(entity);
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogException.Write(ex, "Insert Method In OutputMaterialService");
                        dbcxtransaction.Rollback();
                        return false;
                    }
                }
            }
            return true;

        }
        public void Remove(OutputMaterial entity)
        {
            using (var context = new Store.Data.StoreContext())
            {

                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Entry(entity).State = EntityState.Deleted;
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch
                    {
                        dbcxtransaction.Rollback();
                    }
                }
            }
            //_repository.Remove(entity);
        }
        public bool Update(OutputMaterial entity)
        {

            using (var context = new Store.Data.StoreContext())
            {
                var initialRecord = context.OutputMaterial.SingleOrDefault(x => x.Id == entity.Id);

                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Entry(initialRecord).CurrentValues.SetValues(entity);
                        context.Entry(initialRecord).State = EntityState.Modified;
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        return false;
                    }
                }
            }
            return true;

        }

        public OutputMaterial GetById(int id)
        {
            var query = _repository.Table;

            return query.SingleOrDefault(m => m.Id == id);
        }
        public List<OutputMaterial> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, int workorderId = 0)
        {
            var query = _repository.Table;

            if (workorderId != 0)
            {
                query = query.Where(x => x.WorkOrderId == workorderId);
            }

            var list = query.ToList();

            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<OutputMaterial> GetAll(Expression<Func<OutputMaterial, bool>> condition = null)
        {
            var query = _repository.Table;
            if (condition != null)
            {
                query = query.Where(condition);
            }
            return query.OrderByDescending(x => x.CreatedDate).ToList();
        }

        public int Count(int workorderId = 0)
        {
            var query = _repository.Table;

            if (workorderId > 0)
            {
                query = query.Where(x => x.WorkOrderId == workorderId);
            }

            var list = query.ToList();

            return query.Count();
        }
    }
}
