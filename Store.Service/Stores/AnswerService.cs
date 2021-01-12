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
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Answer> _repository;
        private readonly StoreContext _context;
        public AnswerService(IRepository<Answer> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Answer entity)
        {
            _repository.Insert(entity);
        }
        public bool Insert(IEnumerable<Answer> entities, int workOrderId, string expertName, int scaffoldingId, DateTime? registrationDate, string permitNumber, int personnelId, int realArea = 0, int score = 0)
        {

            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var scaffold = context.Scaffolding.Find(scaffoldingId);
                        var workorder = context.WorkOrder.Find(workOrderId);

                        if (scaffold != null)
                        {

                            scaffold.TotalPoints = score;
                            scaffold.ExpertName = expertName;
                            scaffold.PermitNumber = permitNumber;
                            scaffold.PersonnelCode = personnelId;
                            scaffold.RealArea = realArea;
                            scaffold.RegistrationDate = registrationDate;


                            if (scaffold.TotalPoints >= 96)
                                scaffold.confirmed = true;

                            context.Entry(scaffold).State = EntityState.Modified;

                            workorder.RealArea = realArea;
                            workorder.ScaffoldingId = scaffoldingId;
                            context.Entry(workorder).State = EntityState.Modified;

                            context.Answer.AddRange(entities);

                            context.SaveChanges();
                        }
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "InsertMethodInAnswerService");
                        return false;
                    }
                }
            }
            return true;

            // _repository.Insert(entities);
        }
        public void Remove(Answer entity)
        {
            
            _repository.Remove(entity);
        }

        public bool Update(IEnumerable<Answer> entities, int workOrderId, string expertName, int scaffoldingId, DateTime? registrationDate, string permitNumber, int personnelId,int realArea=0, int score = 0)
        {

            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var scaffold = _context.Scaffolding.Find(entities.FirstOrDefault().ScaffoldingId);
                        var workorder = _context.WorkOrder.Find(workOrderId);

                        if (scaffold != null)
                        {

                            scaffold.TotalPoints = score;
                            scaffold.ExpertName = expertName;
                            scaffold.PermitNumber = permitNumber;
                            scaffold.PersonnelCode = personnelId;
                            scaffold.RegistrationDate = registrationDate;
                          


                            if (scaffold.TotalPoints >= 96)
                                scaffold.confirmed = true;

                            context.Entry(scaffold).State = EntityState.Modified;
                            workorder.RealArea = realArea;
                            context.Entry(workorder).State = EntityState.Modified;
                            context.Answer.AddRange(entities);
                            context.SaveChanges();
                        }
                        dbcxtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        LogException.Write(ex, "InsertMethodInAnswerService");
                        return false;
                    }
                }
            }
            return true;

            // _repository.Insert(entities);
        }

        public Answer GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Answer> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, string title = null)
        {
            var query = _repository.Table;



            var list = query.OrderByDescending(x => x.CreatedDate).ToList();

            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<Answer> GetAll(string title = null)
        {
            var list = _repository.Entities.OrderByDescending(x => x.CreatedDate).ToList();

            return list;
        }
        public int Count(string search)
        {
            var list = _repository.Table;

            return list.ToList().Count();
        }
    }
}
