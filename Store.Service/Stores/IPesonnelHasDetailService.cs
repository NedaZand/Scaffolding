using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;

namespace Store.Service.Stores
{
    public interface IPesonnelHasDetailService
    {

        PesonnelHasDetail GetById(int id);
        void Insert(PesonnelHasDetail entity);
        void Remove(PesonnelHasDetail entity);
        void Update(PesonnelHasDetail entity);
        List<PesonnelHasDetail> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null);
        List<PesonnelHasDetail> GetAll(string search = null);
        int Count(string search, DateTime? createDate = null, DateTime? editDate = null);
    }
}