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
    public class BuyMaterialService : IBuyMaterialService
    {
        private readonly IRepository<BuyMaterial> _repository;
        private readonly StoreContext _context;
        public BuyMaterialService(IRepository<BuyMaterial> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public bool Insert(BuyMaterial entity)
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
                            stock.TotalStock += entity.Count;
                            stock.MainStock += entity.Count;

                            context.Entry(stock).State = EntityState.Modified;

                        }
                        else
                        {
                            stock = new Stock();
                            stock.EquipmentId = entity.EquipmentId;
                            stock.StockReady = entity.Count;
                            stock.TotalStock = entity.Count;
                            stock.MainStock  = entity.Count;

                            context.Stock.Add(stock);
                        }

                        context.BuyMaterial.Add(entity);
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "InsertMethodInBuyService");
                        return false;
                    }
                }
            }
            return true;
            //_repository.Insert(entity);
        }
        public bool Remove(BuyMaterial entity)
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
                            stock.StockReady = (stock.StockReady- entity.Count)>0 ? (stock.StockReady - entity.Count) : 0 ;
                            stock.TotalStock = (stock.TotalStock - entity.Count) > 0 ? (stock.TotalStock - entity.Count) : 0;
                            stock.MainStock = (stock.MainStock - entity.Count) > 0 ? (stock.MainStock - entity.Count) : 0;

                            context.Entry(stock).State = EntityState.Modified;

                        }


                        context.Entry(entity).State = EntityState.Deleted;
                        context.SaveChanges();
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "RemoveMethodInBuyService");
                        return false;
                    }
                }
            }
            return true;
          
        }
        public bool Update(BuyMaterial entity)
        {
          
            using (var context = new Store.Data.StoreContext())
            {
                var initialEntity = context.BuyMaterial.Find(entity.Id);

                initialEntity.Count = entity.Count;
                initialEntity.Date = entity.Date;
                initialEntity.CompanyStoreRoomId = entity.CompanyStoreRoomId;
                initialEntity.Price = entity.Price;
                initialEntity.UnitId = entity.UnitId;
                initialEntity.ModifiedDate = DateTime.Now;
                initialEntity.LastActionUserId = entity.LastActionUserId;

                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if(entity.Count!= initialEntity.Count)
                        {
                            var stock = context.Stock.Find(entity.EquipmentId);

                            if (stock != null)
                            {
                                stock.StockReady = (stock.StockReady - initialEntity.Count) > 0 ? (stock.StockReady - initialEntity.Count) : 0;
                                stock.TotalStock = (stock.StockReady - initialEntity.Count) > 0 ? (stock.StockReady - initialEntity.Count) : 0;
                                stock.MainStock = (stock.MainStock - initialEntity.Count) > 0 ? (stock.MainStock - initialEntity.Count) : 0;

                                stock.StockReady += entity.Count;
                                stock.TotalStock += entity.Count;
                                stock.MainStock += entity.Count;

                                context.Entry(stock).State = EntityState.Modified;

                            }
                            else
                            {
                                stock = new Stock();
                                stock.EquipmentId = entity.EquipmentId;
                                stock.StockReady = entity.Count;
                                stock.TotalStock = entity.Count;
                                stock.MainStock = entity.Count;


                                context.Stock.Add(stock);
                            }


                        }
                        context.Entry(initialEntity).State = EntityState.Modified;
                        context.SaveChanges();

                        dbcxtransaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "UpdateMethodInBuyService");
                        return false;
                    }
                }
            }
            return true;
           //_repository.Edit(entity);
        }

        public BuyMaterial GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                LogException.Write(ex, "GetByIdMethodInBuyService");
                throw;
            }
         
          
        }
        public List<BuyMaterial> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null)
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Price.ToString().Contains(search) || x.Count.ToString().Contains(search));
            }


            if (fromdate.HasValue)
            {
                query = query.Where(x => x.Date >= fromdate);
            }

            if (todate.HasValue)
            {
                query = query.Where(x => x.Date <= todate);
            }

            if (companyId.HasValue)

                query = query.Where(x => x.CompanyStoreRoomId ==companyId);

            if (equipmentId.HasValue)

                query = query.Where(x => x.EquipmentId == equipmentId);

           

            var list = query.ToList();

            return list.OrderByDescending(x => x.CreatedDate).ToList().GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<BuyMaterial> GetAll(string title = null)
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();

            return list.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string search, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null)
        {
            var query = _repository.Table;


            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Price.ToString().Contains(search) || x.Count.ToString().Contains(search));
            }


            if (fromdate.HasValue)
            {
                query = query.Where(x => x.Date >= fromdate);
            }

            if (todate.HasValue)
            {
                query = query.Where(x => x.Date <= todate);
            }

            if (companyId.HasValue)

                query = query.Where(x => x.CompanyStoreRoomId == companyId);

            if (equipmentId.HasValue)

                query = query.Where(x => x.EquipmentId == equipmentId);

            if (price.HasValue)

                query = query.Where(x => x.Price == price);


            var list = query.ToList();

            return query.Count();
        }
    }
}
