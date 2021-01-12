using Store.Core;
using Store.Core.Domain.StoreTables.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables;

namespace Store.Data
{
    public partial class StoreContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public StoreContext() : base(nameOrConnectionString: "DefaultConnection")
        {


        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public static StoreContext Create()
        {
            return new StoreContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<InputMaterial>().HasKey(p => new {p.EquipmentId,  p.WorkOrderId });
            modelBuilder.Entity<OutputMaterial>().HasKey(p => new { p.EquipmentId, p.WorkOrderId });

            base.OnModelCreating(modelBuilder);

        }

    }
}
