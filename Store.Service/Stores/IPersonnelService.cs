using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;

namespace Store.Service.Stores
{
    public interface IPersonnelService
    {

        Personnel GetById(int id);
        Exception Insert(Personnel entity);
        void Insert(IEnumerable<Personnel> entities);
        void Remove(Personnel entity);
        void UpdateStatus(Personnel entity);
        Exception Update(Personnel entity);
        List<Personnel> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, DateTime? fromBirthday = null, DateTime? toBirthday = null, DateTime? fromDateEmployeement = null, DateTime? toDateEmployeement = null, MaritalStatus? maritalStatus = null, string nationalCode = null, string userNameFmaily = null, int? PersonnelCode = null, int? positionType = null, int? employeeType = null, int? company = null, PersonnelStatus? statusPresence = null);
        List<Personnel> GetAll(string search = null);
        int Count(string search, DateTime? createDate = null, DateTime? editDate = null, DateTime? fromBirthday = null, DateTime? toBirthday = null, DateTime? fromDateEmployeement = null, DateTime? toDateEmployeement = null, MaritalStatus? maritalStatus = null, string nationalCode = null, string userNameFmaily = null, int? PersonnelCode = null, int? positionType = null, int? employeeType = null, int? company = null, PersonnelStatus? statusPresence = null);
        
        }
}