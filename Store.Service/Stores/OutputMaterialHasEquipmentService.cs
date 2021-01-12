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
    public class OutputMaterialHasEquipmentService : IOutputMaterialHasEquipmentService
    {
        private readonly IRepository<outputMaterialHasEquipment> _repository;
        public OutputMaterialHasEquipmentService(IRepository<outputMaterialHasEquipment> repository)
        {
            _repository = repository;
        }
        public bool Insert(outputMaterialHasEquipment entity)
        {

            using (var context = new Store.Data.StoreContext())
            {

                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var stock = context.Stock.Find(entity.EquipmentId);

                        if (stock != null)
                        {
                            stock.StockReady = (stock.StockReady - entity.Count) > 0 ? (stock.StockReady - entity.Count) : 0;

                        }
                        else
                        {
                            stock = new Stock();
                            stock.EquipmentId = entity.EquipmentId;
                            stock.StockReady = (stock.StockReady - entity.Count) > 0 ? (stock.StockReady - entity.Count) : 0;

                            context.Stock.Add(stock);
                        }
                        context.OutputMaterialHasEquipment.Add(entity);
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

        public List<outputMaterialHasEquipment> GetAllById(int id)
        {
            var query = _repository.Table.Where(d => d.OutputMaterialId == id);
            return query.ToList();
        }
        public void Remove(outputMaterialHasEquipment entity)
        {
            using (var context = new Store.Data.StoreContext())
            {

                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var stock = context.Stock.Find(entity.EquipmentId);

                        if (stock != null)
                        {
                            stock.StockReady += entity.Count;

                        }
                        else
                        {
                            stock = new Stock();
                            stock.EquipmentId = entity.EquipmentId;
                            stock.StockReady += entity.Count;

                            context.Stock.Add(stock);
                        }

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
        
    }
}
