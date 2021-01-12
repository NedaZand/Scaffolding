using System.Data.Entity;
using Store.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Collections.Generic;

namespace Store.Data
{
    public interface IRepository<T> where T : class
    {
        IDbSet<T> Entities { get; }
        void Edit(T entity);
        void Edit(IEnumerable<T> entities);
        T GetById(object id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Remove(T entity);
        IQueryable<T> Table { get; }
        void Remove(IEnumerable<T> entities);
    }
}