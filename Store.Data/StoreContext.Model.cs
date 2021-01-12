using Store.Core.Domain.StoreTables.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.Work;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.Media;
using Store.Core.Domain.Setting;
using Store.Core.Domain.StoreTables;

namespace Store.Data
{
    public partial class StoreContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<AllowedRole> AllowedRole { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<AssignedWorkorder> AssignedWorkorder { get; set; }
        public DbSet<Routine> Routine { get; set; }
        public DbSet<WorkOrder> WorkOrder { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<WorkorderAssignedUsers> WorkorderAssignedUser { get; set; }
        public DbSet<AssignedWorkorderDetail> AssignedWorkorderDetail { get; set; }
        public DbSet<AssignedTask> AssignedTask { get; set; }
        public DbSet<AssignedTaskUsers> AssignedTaskUser { get; set; }
        public DbSet<Earth> Earth { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<ScaffoldType> ScaffoldType { get; set; }
        public DbSet<Scaffolding> Scaffolding { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<CompanyStoreRoom> CompanyStoreRoom { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<EquipmentHasProperty> EquipmentProperty { get; set; }
        public DbSet<ScaffoldHasEquipment> ScaffoldEquipment { get; set; }
        public DbSet<BuyMaterial> BuyMaterial { get; set; }
        public DbSet<InputMaterial> InputMaterial { get; set; }
        public DbSet<OutputMaterial> OutputMaterial { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Workgroup> Workgroup { get; set; }
        public DbSet<WorkingGroupPersonnel> WorkingGroupPersonnel { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<PositionType> PositionType { get; set; }
        public DbSet<outputMaterialHasEquipment> OutputMaterialHasEquipment { get; set; }
        public DbSet<inputMaterialHasEquipment> InputMaterialHasEquipment { get; set; }
    }
}
