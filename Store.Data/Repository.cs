using Store.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        public Repository(IDbContext context)
        {
            _context = context;
        }
        public void Insert(T entity)
        {
           
            Entities.Add(entity);
            _context.SaveChanges();
        }
        public virtual void Insert(IEnumerable<T> entities)
        {

            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
                this.Entities.Add(entity);

            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
            _context.SaveChanges();
        }
        public virtual void Remove(IEnumerable<T> entities)
        {
           
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Remove(entity);
            _context.SaveChanges();
         
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }
        public void Edit(T entity)
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Edit(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                
            }
        }
        public T GetById(object id)
        {
           
            return _context.Set<T>().Find(id);
        }
        public IDbSet<T> Entities { get { return _context.Set<T>(); } }
    }
}
