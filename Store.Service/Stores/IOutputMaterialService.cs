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
    public interface IOutputMaterialService
    {

        OutputMaterial GetById(int id);
        bool Insert(OutputMaterial entity);
        void Remove(OutputMaterial entity);
        bool Update(OutputMaterial entity);
        List<OutputMaterial> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, int workorderId = 0);
        List<OutputMaterial> GetAll(Expression<Func<OutputMaterial, bool>> condition = null);
        int Count(int workorderId = 0);
    }
}