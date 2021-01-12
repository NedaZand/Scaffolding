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
    public class InputMaterialHasEquipmentService : IInputMaterialHasEquipmentService
    {
        private readonly IRepository<inputMaterialHasEquipment> _repository;
        public InputMaterialHasEquipmentService(IRepository<inputMaterialHasEquipment> repository)
        {
            _repository = repository;
        }
        public bool Insert(inputMaterialHasEquipment entity,InputMaterial inputMaterial)
        {

            using (var context = new Store.Data.StoreContext())
            {

                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var workorder = context.WorkOrder.Find(inputMaterial.WorkOrderId);
                        var stock = context.Stock.Find(entity.EquipmentId);

                        if (stock != null)
                        {
                            stock.StockReady += entity.HealthyNumber;
                            stock.MissingNumberStock += entity.MissingNumber;
                            stock.DefectiveNumberStock += entity.DefectiveNumber;
                            stock.TotalStock = stock.TotalStock - entity.MissingNumber > 0 ? stock.TotalStock - entity.MissingNumber : 0;

                        }

                        workorder.ScaffoldingId = inputMaterial.ScaffoldingId;
                        context.Entry(workorder).State = EntityState.Modified;
                        context.InputMaterialHasEquipment.Add(entity);
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "InsertMethodInInputMaterialHasEquipmentService");
                        return false;
                    }
                }
            }
            return true;

        }

        public List<inputMaterialHasEquipment> GetAllById(int id)
        {
            var query = _repository.Table.Where(d => d.InputMaterialId == id);
            return query.ToList();
        }
        public void Remove(inputMaterialHasEquipment entity)
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
                            stock.StockReady = (stock.StockReady - entity.HealthyNumber) > 0 ? (stock.StockReady - entity.HealthyNumber) : 0;
                            stock.MissingNumberStock = (stock.MissingNumberStock - entity.MissingNumber) > 0 ? (stock.MissingNumberStock - entity.MissingNumber) : 0;
                            stock.DefectiveNumberStock = (stock.DefectiveNumberStock - entity.DefectiveNumber) > 0 ? (stock.DefectiveNumberStock - entity.DefectiveNumber) : 0;
                            stock.TotalStock += entity.MissingNumber;
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
