using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Service.Stores
{
    public class InputMaterialService : IInputMaterialService
    {
        private readonly IRepository<InputMaterial> _repository;
        public InputMaterialService(IRepository<InputMaterial> repository)
        {
            _repository = repository;
        }
        public bool Insert(InputMaterial entity)
        {

            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.InputMaterial.Add(entity);
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "InsertMethodInInputMaterialService");
                        return false;
                    }
                }
            }
            return true;
            //  _repository.Insert(entity);
        }
        public bool Remove(InputMaterial entity)
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
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "RemoveMethodInInputMaterialService");
                        return false;
                    }
                }
            }
            return true;
            //_repository.Remove(entity);
        }
        public bool Update(InputMaterial entity)
        {


            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var stock = context.Stock.Find(entity.EquipmentId);
                        var inputInitialRecord = context.InputMaterial.SingleOrDefault(x => x.Id == entity.Id);

                        if (stock != null)
                        {
                            stock.StockReady = (stock.StockReady - inputInitialRecord.HealthyNumber) > 0 ? (stock.StockReady - inputInitialRecord.HealthyNumber) : 0;
                            stock.MissingNumberStock = (stock.MissingNumberStock - inputInitialRecord.MissingNumber) > 0 ? (stock.MissingNumberStock - inputInitialRecord.MissingNumber) : 0;
                            stock.DefectiveNumberStock = (stock.DefectiveNumberStock - inputInitialRecord.DefectiveNumber) > 0 ? (stock.DefectiveNumberStock - inputInitialRecord.DefectiveNumber) : 0;
                            stock.TotalStock += inputInitialRecord.MissingNumber;

                            stock.StockReady += entity.HealthyNumber;
                            stock.MissingNumberStock += entity.MissingNumber;
                            stock.DefectiveNumberStock += entity.DefectiveNumber;
                            stock.TotalStock = stock.TotalStock - entity.MissingNumber > 0 ? stock.TotalStock - entity.MissingNumber : 0;


                        }
                        context.Entry(inputInitialRecord).CurrentValues.SetValues(entity);
                        context.Entry(inputInitialRecord).State = EntityState.Modified;
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "UpdateMethodInInputMaterialService");
                        return false;
                    }
                }
            }
            return true;
            //_repository.Edit(entity);
        }

        public InputMaterial GetById(int id)
        {
            var query = _repository.Table;
            return query.SingleOrDefault(x => x.Id == id);

            //return _repository.GetById(id);
        }
        public List<InputMaterial> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null)
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                // query = query.Where(x => x.Equipment != null && x.Equipment.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Price.ToString().Contains(search) || x.Count.ToString().Contains(search) || x.Company != null && x.Company.Title.Trim().ToLower().Contains(search.Trim().ToLower()));
            }




            var list = query.ToList();

            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<InputMaterial> GetAll(Expression<Func<InputMaterial, bool>> condition = null)
        {
            var query = _repository.Table;
            if (condition != null)
                query = query.Where(condition);

            return query.ToList();
        }
        public int Count(string search, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null)
        {
            var query = _repository.Table;


            if (!string.IsNullOrEmpty(search))
            {
                // query = query.Where(x => x.Equipment != null && x.Equipment.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Price.ToString().Contains(search) || x.Count.ToString().Contains(search) || x.Company != null && x.Company.Title.Trim().ToLower().Contains(search.Trim().ToLower()));
            }


            var list = query.ToList();

            return query.Count();
        }
    }
}
