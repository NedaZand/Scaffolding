using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.User;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Service.DateTimeExtentions;
using System.Data.Entity;

namespace Store.Service.Stores
{
    public class PersonnelService : IPersonnelService
    {
        private readonly IRepository<Personnel> _repository;
        private readonly StoreContext _context;
        public PersonnelService(IRepository<Personnel> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public Exception Insert(Personnel entity)
        {
            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Personnel.Add(entity);
                        context.WorkingGroupPersonnel.AddRange(entity.WorkingGroupPersonnels);
                        context.SaveChanges();

                        dbcxtransaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        LogException.Write(ex, "Insert Method In PersonnelService");
                        dbcxtransaction.Rollback();
                        return ex;
                    }
                }
            }

            return null;
           // _repository.Insert(entity);
        }
        public void Insert(IEnumerable<Personnel> entities)
        {

            _repository.Insert(entities);
        }
        public void Remove(Personnel entity)
        {
            _repository.Remove(entity);
        }
        public Exception Update(Personnel entity)
        {
            using (var context = new Store.Data.StoreContext())
            {
                using (var dbcxtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var personnel = context.Personnel.Find(entity.PersonnelCode);

                        personnel.UserNameFmaily = entity.UserNameFmaily;
                        personnel.PositionTypeId = entity.PositionTypeId;
                        personnel.EmployeeTypeId = entity.EmployeeTypeId;
                        if(entity.MaritalStatus.HasValue)
                        personnel.MaritalStatus = entity.MaritalStatus.Value;
                        personnel.NationalCode = entity.NationalCode;
                        personnel.BirthDate = entity.BirthDate;
                        personnel.DateEmployeement = entity.DateEmployeement;
                        personnel.Description = entity.Description;
                        if(entity.StatusPresence==PersonnelStatus.NonSuspended)
                           personnel.StatusPresence = null;
                        else
                           personnel.StatusPresence = entity.StatusPresence;
                        personnel.CompanyId = entity.CompanyId;
                        

                            
                            if (personnel.WorkingGroupPersonnels.Count > 0)
                                context.WorkingGroupPersonnel.RemoveRange(personnel.WorkingGroupPersonnels);
                           
                                context.WorkingGroupPersonnel.AddRange(entity.WorkingGroupPersonnels);

                            personnel.WorkingGroupPersonnels = null;

                            personnel.WorkingGroupPersonnels = entity.WorkingGroupPersonnels;

                        

                        context.Entry(personnel).State = EntityState.Modified;
                        context.SaveChanges();

                        dbcxtransaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        LogException.Write(ex, "Update Method In PersonnelService");
                        dbcxtransaction.Rollback();
                        return ex;
                    }
                }
            }
            return null;
            //_repository.Edit(entity);
        }

        public void UpdateStatus(Personnel entity)
        {
           
            _repository.Edit(entity);
        }

        public Personnel GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Personnel> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null,DateTime? fromBirthday=null, DateTime? toBirthday = null, DateTime? fromDateEmployeement = null, DateTime? toDateEmployeement = null, MaritalStatus? maritalStatus=null,string nationalCode=null, string userNameFmaily=null,int? PersonnelCode=null,int? positionType=null,int? employeeType=null,int? company=null,PersonnelStatus? statusPresence=null)
        {
            var list = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Company!=null && x.Company.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Description != null && x.Description.Trim().ToLower().Contains(search.Trim().ToLower()) || x.PositionType != null && x.PositionType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.EmployeeType != null && x.EmployeeType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.NationalCode.Trim().ToLower().Contains(search.Trim().ToLower()) || x.UserNameFmaily.Trim().ToLower().Contains(search.Trim().ToLower()) ||  x.PersonnelCode.ToString().Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            if (statusPresence.HasValue)
            {
                if(statusPresence.Value==PersonnelStatus.NonSuspended)

                    list = list.Where(x => x.StatusPresence!=PersonnelStatus.Suspended);
                else
                    list = list.Where(x => x.StatusPresence == statusPresence);
            }

            if (fromBirthday.HasValue)
            {
                list = list.Where(x => x.BirthDate >= fromBirthday);
            }
            if (toBirthday.HasValue)
            {
                list = list.Where(x => x.BirthDate <= toBirthday);
            }
            if (fromDateEmployeement.HasValue)
            {
                list = list.Where(x => x.DateEmployeement >= fromDateEmployeement);
            }
            if (toDateEmployeement.HasValue)
            {
                list = list.Where(x => x.DateEmployeement <= toDateEmployeement);
            }
            if (maritalStatus.HasValue && maritalStatus != MaritalStatus.Unknown)
                list = list.Where(x => x.MaritalStatus == maritalStatus);

            if (employeeType.HasValue)
                list = list.Where(x => x.EmployeeTypeId == employeeType);

            if (company.HasValue)
                list = list.Where(x => x.CompanyId == company);

            if (positionType.HasValue && positionType!=0)
                list = list.Where(x => x.PositionTypeId == positionType);

            if (PersonnelCode.HasValue)
                list = list.Where(x => x.PersonnelCode == PersonnelCode);

            if (!string.IsNullOrEmpty(nationalCode))
                list = list.Where(x => x.NationalCode.Contains(nationalCode));

            if (!string.IsNullOrEmpty(userNameFmaily))
                list = list.Where(x => x.UserNameFmaily.Contains(userNameFmaily));


            //switch (sortColumn)
            //{
            //    case 1:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Title).ToList() : list.OrderByDescending(x => x.Title).ToList();
            //        break;
            //    case 2:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Description).ToList() : list.OrderByDescending(x => x.Description).ToList();
            //        break;
            //    default:
            //        break;
            //}
            return list.OrderByDescending(x=>x.CreatedDate).ToList().GetRange(start, Math.Min(lenght, list.ToList().Count - start)).ToList();
        }
        public List<Personnel> GetAll(string search = null)
        {
            var list = _repository.Entities.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Company != null && x.Company.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Description!=null && x.Description.Trim().ToLower().Contains(search.Trim().ToLower()) || x.PositionType != null && x.PositionType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.EmployeeType != null && x.EmployeeType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.NationalCode.Trim().ToLower().Contains(search.Trim().ToLower()) || x.UserNameFmaily.Trim().ToLower().Contains(search.Trim().ToLower()) || x.PersonnelCode.ToString().Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }

            return list.ToList();
        }
        public int Count(string search, DateTime? createDate = null, DateTime? editDate = null, DateTime? fromBirthday = null, DateTime? toBirthday = null, DateTime? fromDateEmployeement = null, DateTime? toDateEmployeement = null, MaritalStatus? maritalStatus = null, string nationalCode = null, string userNameFmaily = null, int? PersonnelCode = null, int? positionType = null, int? employeeType = null, int? company = null, PersonnelStatus? statusPresence = null)
        {
            var list = _repository.Table;

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Company != null && x.Company.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.Description != null && x.Description.Trim().ToLower().Contains(search.Trim().ToLower()) || x.PositionType != null && x.PositionType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.EmployeeType != null && x.EmployeeType.Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.NationalCode.Trim().ToLower().Contains(search.Trim().ToLower()) || x.UserNameFmaily.Trim().ToLower().Contains(search.Trim().ToLower()) || x.PersonnelCode.ToString().Trim().ToLower().Contains(search.Trim().ToLower()));
            }

            if (statusPresence.HasValue)
            {
                if (statusPresence.Value == PersonnelStatus.NonSuspended)

                    list = list.Where(x => x.StatusPresence != PersonnelStatus.Suspended);
                else
                    list = list.Where(x => x.StatusPresence == statusPresence);
            }

            if (fromBirthday.HasValue)
            {
                list = list.Where(x => x.BirthDate >= fromBirthday);
            }
            if (toBirthday.HasValue)
            {
                list = list.Where(x => x.BirthDate <= toBirthday);
            }
            if (fromDateEmployeement.HasValue)
            {
                list = list.Where(x => x.DateEmployeement >= fromDateEmployeement);
            }
            if (toDateEmployeement.HasValue)
            {
                list = list.Where(x => x.DateEmployeement <= toDateEmployeement);
            }
            if (maritalStatus.HasValue && maritalStatus != MaritalStatus.Unknown)
                list = list.Where(x => x.MaritalStatus == maritalStatus);

            if (employeeType.HasValue)
                list = list.Where(x => x.EmployeeTypeId == employeeType);

            if (company.HasValue)
                list = list.Where(x => x.CompanyId == company);

            if (positionType.HasValue && positionType != 0)
                list = list.Where(x => x.PositionTypeId == positionType);

            if (PersonnelCode.HasValue)
                list = list.Where(x => x.PersonnelCode == PersonnelCode);

            if (!string.IsNullOrEmpty(nationalCode))
                list = list.Where(x => x.NationalCode.Contains(nationalCode));

            if (!string.IsNullOrEmpty(userNameFmaily))
                list = list.Where(x => x.UserNameFmaily.Contains(userNameFmaily));


            //switch (sortColumn)
            //{
            //    case 1:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Title).ToList() : list.OrderByDescending(x => x.Title).ToList();
            //        break;
            //    case 2:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Description).ToList() : list.OrderByDescending(x => x.Description).ToList();
            //        break;
            //    default:
            //        break;
            //}
            return list.Count();
         }
    }
}
