using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;

namespace Store.Service.Stores
{
    public interface IAttendanceService
    {

        Attendance GetById(int id);
        void Insert(Attendance entity);
        void Insert(IEnumerable<Attendance> entities);
        void Remove(Attendance entity);
        void Update(Attendance entity);
        void Update(IEnumerable<Attendance> entities);
        List<Attendance> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection,DateTime? fromDate=null,DateTime? toDate=null, int? persoonelCode = null, PresenceStatus? status = null);
        List<Attendance> GetAll(DateTime? date, PresenceStatus? status);
        int Count(string search=null, DateTime? fromDate = null, DateTime? toDate = null, int? persoonelCode = null, PresenceStatus? status = null);
    }
}