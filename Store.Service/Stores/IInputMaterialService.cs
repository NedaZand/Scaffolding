using System.Collections.Generic;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using System;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;
using System.Linq.Expressions;

namespace Store.Service.Stores
{
    public interface IInputMaterialService
    {

        InputMaterial GetById(int id);
        bool Insert(InputMaterial entity);
        bool Remove(InputMaterial entity);
        bool Update(InputMaterial entity);
        List<InputMaterial> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null);
        List<InputMaterial> GetAll(Expression<Func<InputMaterial, bool>> condition = null);
        int Count(string search, DateTime? createDate = null, DateTime? editDate = null, int? equipmentId = null, int? companyId = null, decimal? price = null, DateTime? fromdate = null, DateTime? todate = null);
    }
}