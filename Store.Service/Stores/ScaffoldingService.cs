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
    public class ScaffoldingService : IScaffoldingService
    {
        private readonly IRepository<Scaffolding> _repository;
        private readonly StoreContext _context;
        public ScaffoldingService(IRepository<Scaffolding> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public bool Insert(Scaffolding entity,out int id)
        {

            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    id = 0;
                    try
                    {
                      
                        var workorder = context.WorkOrder.Find(entity.WorkOrderId);

                        if (workorder != null)
                        {

                            workorder.ScaffoldingId = entity.Id;

                            context.Entry(workorder).State = EntityState.Modified;
                            context.Scaffolding.Add(entity);
                            context.SaveChanges();
                            id = entity.Id;
                        }
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "InsertMethodInScaffoldingService");
                        return false;
                    }
                }
            }
            return true;
            // _repository.Insert(entity);
        }
        public void Remove(Scaffolding entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Scaffolding entity)
        {
            _repository.Edit(entity);
        }

        public Scaffolding GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Scaffolding> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, int? width = null, int? height = null, int? lengthh = null, DateTime? fromSafetyTagExpire = null, DateTime? toSafetyTagExpire = null, int? buildingId = null, int? earthId = null, int? workOrderId = null, int? scaffoldTypeId = null, string title = null, string tag = null, bool alertExpire = false,int scaffoldId=0,bool notTag = false)
        {
            var query = _repository.Table.OrderByDescending(x=>x.CreatedDate).AsQueryable();
          //var h=  _context.Equipment.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Tag.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Width.ToString().Trim().ToLower().Contains(search.Trim().ToLower()) || x.Height.ToString().Trim().ToLower().Contains(search.Trim().ToLower()) || x.Length.ToString().Trim().ToLower().Contains(search.Trim().ToLower()) || x.Building != null && x.Building.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Earth != null && x.Earth.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.ScaffoldType != null && x.ScaffoldType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Building != null && x.Building.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Description.Trim().ToLower().Contains(search.Trim().ToLower()));
            }
            if(scaffoldId!=0)
            {
                query = query.Where(x => x.Id ==scaffoldId);
            }

            if(notTag)
            {
                query = query.Where(x => x.ExpertName == null);
            }
            if (alertExpire)
            {
                query = (from a in query where (System.Data.Entity.DbFunctions.DiffDays(DateTime.Now ,a.ExpireDate.Value ) <= 0 || System.Data.Entity.DbFunctions.DiffDays(DateTime.Now,a.RegistrationDate.Value) <= 0 && a.ScaffoldTypeId == 1) 
                         select a);
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
            if (fromSafetyTagExpire.HasValue)
            {
                query = query.Where(x => x.SafetyTagExpire >= fromSafetyTagExpire);
            }
            if (toSafetyTagExpire.HasValue)
            {
                query = query.Where(x => x.SafetyTagExpire <= toSafetyTagExpire);
            }
            if (scaffoldTypeId.HasValue)
            {
                query = query.Where(x => x.ScaffoldTypeId == scaffoldTypeId);
            }
            if (earthId.HasValue)
            {
                query = query.Where(x => x.EarthId == earthId);
            }
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >= fromDate);
            }
            if (buildingId.HasValue)
            {
                query = query.Where(x => x.BuildingId == buildingId);
            }
            if (lengthh.HasValue)
            {
                query = query.Where(x => x.Length == lengthh);
            }
            if (width.HasValue)
            {
                query = query.Where(x => x.Width == width);
            }
            if (height.HasValue)
            {
                query = query.Where(x => x.Height == height);
            }
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(tag))
            {
                query = query.Where(x => x.Tag.Contains(tag));
            }
            var list = query.OrderByDescending(x=>x.CreatedDate).ToList();
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<Scaffolding> GetAll(string title = null)
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();
            if (!string.IsNullOrEmpty(title))
            {
                list = list.Where(x => x.Title.Trim().Equals(title.Trim())).ToList();
            }
          
            return list.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string search, DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromExpireDate = null, DateTime? toExpireDate = null, int? width = null, int? height = null, int? lengthh = null, DateTime? fromSafetyTagExpire = null, DateTime? toSafetyTagExpire = null, int? buildingId = null, int? earthId = null, int? workOrderId = null, int? scaffoldTypeId = null, string title = null, string tag = null,bool alertExpire=false,int scaffoldId=0,bool notTag=false)
        {
            var query = _repository.Table;

            if(scaffoldId!=0)

                query = query.Where(x => x.Id==scaffoldId);

            if (notTag)
            {
                query = query.Where(x => x.ExpertName == null);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Tag.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Width.ToString().Trim().ToLower().Contains(search.Trim().ToLower()) || x.Height.ToString().Trim().ToLower().Contains(search.Trim().ToLower()) || x.Length.ToString().Trim().ToLower().Contains(search.Trim().ToLower()) || x.Building != null && x.Building.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Earth != null && x.Earth.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.ScaffoldType != null && x.ScaffoldType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Building != null && x.Building.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Description.Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            if (alertExpire)
            {
                query = (from a in query
                         where (System.Data.Entity.DbFunctions.DiffDays(a.ExpireDate.Value, DateTime.Now) > 0 && System.Data.Entity.DbFunctions.DiffDays(a.ExpireDate.Value, DateTime.Now) <= 15 || System.Data.Entity.DbFunctions.DiffDays(a.ExpireDate.Value, DateTime.Now) <= 0)
                         select a);
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
            if (fromSafetyTagExpire.HasValue)
            {
                query = query.Where(x => x.SafetyTagExpire >= fromSafetyTagExpire);
            }
            if (toSafetyTagExpire.HasValue)
            {
                query = query.Where(x => x.SafetyTagExpire <= toSafetyTagExpire);
            }
            if (scaffoldTypeId.HasValue)
            {
                query = query.Where(x => x.ScaffoldTypeId == scaffoldTypeId);
            }
            if (earthId.HasValue)
            {
                query = query.Where(x => x.EarthId == earthId);
            }
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.Date >= fromDate);
            }

            if (buildingId.HasValue)
            {
                query = query.Where(x => x.BuildingId == buildingId);
            }
            if (lengthh.HasValue)
            {
                query = query.Where(x => x.Length == lengthh);
            }
            if (width.HasValue)
            {
                query = query.Where(x => x.Width == width);
            }
            if (height.HasValue)
            {
                query = query.Where(x => x.Height == height);
            }
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(tag))
            {
                query = query.Where(x => x.Tag.Contains(tag));
            }
            return query.Count();
        }
    }
}
