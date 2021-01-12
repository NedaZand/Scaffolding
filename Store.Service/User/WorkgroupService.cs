using Store.Core.Domain.StoreTables.User;
using Store.Data;
using Store.Service.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Store.Core.Domain.StoreTables;
using System.Data.Entity;

namespace Store.Service
{
    public class WorkgroupService : IWorkgroupService
    {
        private readonly IRepository<Workgroup> _repository;
        private readonly StoreContext _context;

        public WorkgroupService(IRepository<Workgroup> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Workgroup entity)
        {
            //using (var context = new Store.Data.StoreContext())
            //{
            //    using (var dbcxtransaction = context.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            context.Workgroup.Add(entity);
            //            //context.WorkingGroupPersonnel.AddRange(entity.WorkingGroupPersonnels);
            //            context.SaveChanges();

            //            dbcxtransaction.Commit();
            //        }
            //        catch
            //        {
            //            dbcxtransaction.Rollback();
            //        }
            //    }
            //}
            _repository.Insert(entity);
        }
        public void Remove(Workgroup entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Workgroup entity)
        {
            _repository.Edit(entity);
        }

        //public void Insert(Workgroup entity)
        //{
        //    using (var context = new Store.Data.StoreContext())
        //    {
        //        using (var dbcxtransaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                foreach (var item in entity.WorkingGroupPersonnels)
        //                {

        //                    if (context.PositionType.Find(item.Personnel.PositionTypeId).SystemName != PositionTypeEnum.MasterOfWork.ToString())
        //                    {
        //                        context.WorkingGroupPersonnel.Remove(item);
        //                    }
        //                }
        //                context.Workgroup.Add(entity);
        //                //context.WorkingGroupPersonnel.AddRange(entity.WorkingGroupPersonnels);
        //                context.SaveChanges();

        //                dbcxtransaction.Commit();
        //            }
        //            catch
        //            {
        //                dbcxtransaction.Rollback();
        //            }
        //        }
        //    }
         
        //}
      
        //public void Update(Workgroup entity)
        //{
        //    using (var context = new Store.Data.StoreContext())
        //    {
        //        using (var dbcxtransaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                foreach (var item in entity.WorkingGroupPersonnels)
        //                {
        //                    var g = context.Personnel.Find(item.PersonnelCode);
        //                    var h = context.PositionType.Find(g.PositionTypeId);

        //                    if (context.PositionType.Find(context.Personnel.Find(item.PersonnelCode).PositionTypeId).SystemName != null && context.PositionType.Find(context.Personnel.Find(item.PersonnelCode).PositionTypeId).SystemName != PositionTypeEnum.MasterOfWork.ToString())
        //                    {
        //                        context.WorkingGroupPersonnel.Remove(item);
        //                    }
        //                }
        //                context.Entry(entity).State = EntityState.Modified;
        //                //context.WorkingGroupPersonnel.AddRange(entity.WorkingGroupPersonnels);
        //                context.SaveChanges();

        //                dbcxtransaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                dbcxtransaction.Rollback();
        //            }
        //        }
        //    }
        //    // _repository.Edit(entity);
        //}
        public List<Workgroup> GetAll(string title = null)
        {
            var list = _repository.Entities.ToList();

            if (!string.IsNullOrEmpty(title))
            {
                list = list.Where(x => x.Title.Trim().ToLower().Equals(title.Trim().ToLower())).ToList();
            }

            return list.ToList();
        }
        public Workgroup GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Workgroup> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection)
       {
            var list = _repository.Entities.ToList();
            

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Contains(search)).ToList();
            }
            
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int Count(string title)
        {
            var list = _repository.Entities.ToList();
         
            return list.Count();
        }
    }
}
