using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.StoreRoom;
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
    public class OutPutMaterialEquipmentsEquipmentService : IOutPutMaterialEquipmentsService
    {
        //private readonly IRepository<OutPutMaterialEquipments> _repository;
        //public OutPutMaterialEquipmentsEquipmentService(IRepository<OutPutMaterialEquipments> repository)
        //{
        //    _repository = repository;
        //}
        //public bool Insert(OutPutMaterialEquipments entity)
        //{

        //    using (var context = new Store.Data.StoreContext())
        //    {

        //        using (var dbcxtransaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {                        
        //                context.OutPutMaterialEquipments.Add(entity);
        //                context.SaveChanges();
        //                dbcxtransaction.Commit();
        //            }
        //            catch(Exception ex)
        //            {
        //                LogException.Write(ex, "Insert Method In OutPutMaterialEquipmentsService");
        //                dbcxtransaction.Rollback();
        //                return false;
        //            }
        //        }
        //    }
        //    return true;

        //}
        //public void Remove(OutPutMaterialEquipments entity)
        //{
        //    using (var context = new Store.Data.StoreContext())
        //    {
               
        //        using (var dbcxtransaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {                        
        //                context.Entry(entity).State = EntityState.Deleted;
        //                context.SaveChanges();
        //                dbcxtransaction.Commit();
        //            }
        //            catch
        //            {
        //                dbcxtransaction.Rollback();
        //            }
        //        }
        //    }
        //    //_repository.Remove(entity);
        //}
        //public OutPutMaterialEquipments GetById(int id)
        //{
        //    var query = _repository.Table;

        //    return query.SingleOrDefault(m => m.Id == id);
        //}
        //public List<OutPutMaterialEquipments> FilterData(int outPutMaterialId)
        //{
        //    var query = _repository.Table;
        //    query = query.Where(d => d.OutputMaterialId == outPutMaterialId);
        //    return query.ToList();            
        //}

        //public bool Update(OutPutMaterialEquipments entity)
        //{

        //    using (var context = new Store.Data.StoreContext())
        //    {
        //        var initialRecord = context.OutPutMaterialEquipments.SingleOrDefault(x => x.Id == entity.Id);

        //        using (var dbcxtransaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var stock = context.Stock.Find(entity.EquipmentId);

        //                if (stock != null)
        //                {
        //                    stock.StockReady += initialRecord.Count;
        //                    stock.StockReady = (stock.StockReady - entity.Count) > 0 ? (stock.StockReady - entity.Count) : 0;

        //                }
        //                else
        //                {
        //                    stock = new Stock();
        //                    stock.EquipmentId = entity.EquipmentId;
        //                    stock.StockReady = (stock.StockReady - entity.Count) > 0 ? (stock.StockReady - entity.Count) : 0;

        //                    context.Stock.Add(stock);
        //                }
        //                context.Entry(initialRecord).CurrentValues.SetValues(entity);
        //                context.Entry(initialRecord).State = EntityState.Modified;
        //                context.SaveChanges();
        //                dbcxtransaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                dbcxtransaction.Rollback();
        //                return false;
        //            }
        //        }
        //    }
        //    return true;

        //}


        //public List<OutPutMaterialEquipments> GetAll(int workorderId = 0)
        //{
        //    var query = _repository.Table;
        //    if(workorderId > 0)
        //    {
        //        query = query.Where(x => x.WorkOrderId == workorderId);
        //    }
        //    return query.OrderByDescending(x => x.CreatedDate).ToList();
        //}
        //public int Count(int workorderId=0)
        //{
        //    var query = _repository.Table;

        //    if (workorderId > 0)
        //    {
        //        query = query.Where(x => x.WorkOrderId == workorderId);
        //    }

        //    var list = query.ToList();

        //    return query.Count();
        //}
    }
}
