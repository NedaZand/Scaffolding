namespace Store.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Store.Core.Domain.StoreTables;
    using Store.Core.Domain.StoreTables.StoreRoom;
    using Store.Core.Domain.StoreTables.User;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Store.Data.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Store.Data.StoreContext context)
        {

            #region Insert PositionType


            AddPositionType(context);
            #endregion

            #region Insert Questions
            InsertQuestions(context);
            #endregion Insert Questions

            #region Roles
            RolesAndUsers(context);
            #endregion Roles
            InsertEquipment(context);
            InsertEquipmentSys(context);


            InsertScaffoldType(context);
            //#region Remove Permissions
            //RemovePermissions(context);
            //#endregion Remove Permissions

            //#region Insert Permission
            InsertPermissions(context);
            //#endregion Insert Permission

            //#region Update Permissions
            //UpdatePermissions(context);
            //#endregion Update Permissions

            //#region Remove Permissions of Admin
            //RemoveAdminPermissions(context);
            //#endregion Remove Permissions of Admin

            //#region Permissions for Admin
            InsertAdminPermissions(context);
            //#endregion Permissions for Admin
        }

        private static void InsertAdminPermissions(StoreContext context)
        {
            var allPermissions = context.Permission.ToList();
            var role = context.ApplicationRole.First(x => x.Name == "admin");
            role.Permissions = allPermissions;
            context.ApplicationRole.AddOrUpdate(role);
            context.SaveChanges();
        }


        private static void InsertPermissions(StoreContext context)
        {
            List<Permission> customePermissionList = new List<Permission>();


            customePermissionList.Add(new Permission { Category = "Company", PersianCategoryame = "مدیریت مشتری", SystemName = "CompanyList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Company", PersianCategoryame = "مدیریت مشتری", SystemName = "CompanyCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Company", PersianCategoryame = "مدیریت مشتری", SystemName = "CompanyEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Company", PersianCategoryame = "مدیریت مشتری", SystemName = "CompanyDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Company", PersianCategoryame = "مدیریت مشتری", SystemName = "CompanyPrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = false });

            #region BrowseDaily

            customePermissionList.Add(new Permission { Category = "BrowseDaily", PersianCategoryame = "مرور کارهای روزانه ", SystemName = "BrowseDailyList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = false });

            customePermissionList.Add(new Permission { Category = "BrowseDaily", PersianCategoryame = "مرور کارهای روزانه ", SystemName = "BrowseDailyCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = false });

            customePermissionList.Add(new Permission { Category = "BrowseDaily", PersianCategoryame = "مرور کارهای روزانه", SystemName = "BrowseDailyEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = false });

            customePermissionList.Add(new Permission { Category = "BrowseDaily", PersianCategoryame = "مرور کارهای روزانه", SystemName = "BrowseDailyDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = false });

            customePermissionList.Add(new Permission { Category = "BrowseDaily", PersianCategoryame = "مرور کارهای روزانه", SystemName = "BrowseDailyPrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = false });


            #endregion BrowseDaily

            #region AssignedTask

            customePermissionList.Add(new Permission { Category = "AssignedTask", PersianCategoryame = "مدیریت وظایف ", SystemName = "AssignedTaskList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "AssignedTask", PersianCategoryame = "مدیریت وظایف ", SystemName = "AssignedTaskCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "AssignedTask", PersianCategoryame = "مدیریت وظایف", SystemName = "AssignedTaskEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "AssignedTask", PersianCategoryame = "مدیریت وظایف", SystemName = "AssignedTaskDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "AssignedTask", PersianCategoryame = "مدیریت وظایف", SystemName = "AssignedTaskPrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = true });


            #endregion AssignedTask

            #region Attendance

            customePermissionList.Add(new Permission { Category = "Attendance", PersianCategoryame = "مدیریت حضور و غیاب ", SystemName = "AttendanceList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Attendance", PersianCategoryame = "مدیریت حضور و غیاب ", SystemName = "AttendanceCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Attendance", PersianCategoryame = "مدیریت حضور و غیاب", SystemName = "AttendanceEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Attendance", PersianCategoryame = "مدیریت حضور و غیاب", SystemName = "AttendanceDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Attendance", PersianCategoryame = "مدیریت حضور و غیاب", SystemName = "AttendancePrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = false });


            #endregion Attendance

            #region WorkOrder

            customePermissionList.Add(new Permission { Category = "WorkOrder", PersianCategoryame = "مدیریت دستور کار ", SystemName = "WorkOrderList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkOrder", PersianCategoryame = "مدیریت دستور کار ", SystemName = "WorkOrderCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkOrder", PersianCategoryame = "مدیریت دستور کار", SystemName = "WorkOrderEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkOrder", PersianCategoryame = "مدیریت دستور کار", SystemName = "WorkOrderDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkOrder", PersianCategoryame = "مدیریت دستور کار", SystemName = "WorkOrderPrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = true });


            #endregion WorkOrder

            #region Routin

            customePermissionList.Add(new Permission { Category = "Routin", PersianCategoryame = "مدیریت روتین ", SystemName = "RoutinList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Routin", PersianCategoryame = "مدیریت روتین  ", SystemName = "RoutinCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Routin", PersianCategoryame = "مدیریت روتین ", SystemName = "RoutinEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Routin", PersianCategoryame = "مدیریت روتین ", SystemName = "RoutinDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Routin", PersianCategoryame = "مدیریت روتین ", SystemName = "RoutinPrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = true });


            #endregion Routin

            #region PositionType

            customePermissionList.Add(new Permission { Category = "PositionType", PersianCategoryame = "مدیریت پست سازمانی ", SystemName = "PositionTypeList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "PositionType", PersianCategoryame = "مدیریت پست سازمانی  ", SystemName = "PositionTypeCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "PositionType", PersianCategoryame = "مدیریت پست سازمانی ", SystemName = "PositionTypeEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "PositionType", PersianCategoryame = "مدیریت پست سازمانی ", SystemName = "PositionTypeDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "PositionType", PersianCategoryame = "مدیریت پست سازمانی ", SystemName = "PositionTypePrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = false });


            #endregion PositionType

            #region EmployeeType

            customePermissionList.Add(new Permission { Category = "EmployeeType", PersianCategoryame = "مدیریت نوع همکاری  ", SystemName = "EmployeeTypeList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "EmployeeType", PersianCategoryame = "مدیریت  نوع همکاری   ", SystemName = "EmployeeTypeCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "EmployeeType", PersianCategoryame = "مدیریت  نوع همکاری  ", SystemName = "EmployeeTypeEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "EmployeeType", PersianCategoryame = "مدیریت  نوع همکاری  ", SystemName = "EmployeeTypeDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission
            {
                Category = "EmployeeType",
                PersianCategoryame = "مدیریت  نوع همکاری   ",
                SystemName = "EmployeeTypePrint",
                Title = "چاپ ",
                CreatedDate = DateTime.Now,
                Active = false
            });


            #endregion EmployeeType

            #region Personnel

            customePermissionList.Add(new Permission { Category = "Personnel", PersianCategoryame = "مدیریت پرسنل ", SystemName = "PersonnelList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Personnel", PersianCategoryame = "مدیریت پرسنل ", SystemName = "PersonnelCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Personnel", PersianCategoryame = "مدیریت پرسنل ", SystemName = "PersonnelEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Personnel", PersianCategoryame = "مدیریت پرسنل ", SystemName = "PersonnelDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Personnel", PersianCategoryame = "مدیریت پرسنل ", SystemName = "PersonnelPrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = true });

            #endregion Personnel

            #region User

            customePermissionList.Add(new Permission { Category = "User", PersianCategoryame = "مدیریت کاربران ", SystemName = "UserList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "User", PersianCategoryame = "مدیریت کاربران ", SystemName = "UserCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "User", PersianCategoryame = "مدیریت کاربران ", SystemName = "UserEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "User", PersianCategoryame = "مدیریت کاربران ", SystemName = "UserDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "User", PersianCategoryame = "مدیریت کاربران ", SystemName = "UserPrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = false });

            #endregion


            #region Role

            customePermissionList.Add(new Permission { Category = "Role", PersianCategoryame = "مدیریت نقش ها ", SystemName = "RoleList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Role", PersianCategoryame = "مدیریت نقش ها ", SystemName = "RoleCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Role", PersianCategoryame = "مدیریت نقش ها ", SystemName = "RoleEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Role", PersianCategoryame = "مدیریت نقش ها ", SystemName = "RoleDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Role", PersianCategoryame = "مدیریت نقش ها ", SystemName = "RolePrint", Title = "چاپ ", CreatedDate = DateTime.Now, Active = false });


            #endregion



            #region CompanyStoreRoom

            customePermissionList.Add(new Permission { Category = "CompanyStoreRoom", PersianCategoryame = "مدیریت فروشندگان ", SystemName = "CompanyStoreRoomList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "CompanyStoreRoom", PersianCategoryame = "مدیریت فروشندگان ", SystemName = "CompanyStoreRoomCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "CompanyStoreRoom", PersianCategoryame = "مدیریت فروشندگان ", SystemName = "CompanyStoreRoomEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "CompanyStoreRoom", PersianCategoryame = "مدیریت فروشندگان", SystemName = "CompanyStoreRoomDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "CompanyStoreRoom", PersianCategoryame = "مدیریت فروشندگان ", SystemName = "CompanyStoreRoomPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });


            #endregion CompanyStoreRoom

            #region Building

            customePermissionList.Add(new Permission { Category = "Building", PersianCategoryame = "مدیریت نوع بنا ", SystemName = "BuildingList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Building", PersianCategoryame = "مدیریت نوع بنا ", SystemName = "BuildingCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Building", PersianCategoryame = "مدیریت نوع بنا ", SystemName = "BuildingEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Building", PersianCategoryame = "مدیریت نوع بنا", SystemName = "BuildingDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Building", PersianCategoryame = "مدیریت نوع بنا ", SystemName = "BuildingPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion Building

            #region Earth

            customePermissionList.Add(new Permission { Category = "Earth", PersianCategoryame = "مدیریت نوع زمین ", SystemName = "EarthList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Earth", PersianCategoryame = "مدیریت نوع زمین ", SystemName = "EarthCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Earth", PersianCategoryame = "مدیریت نوع زمین ", SystemName = "EarthEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Earth", PersianCategoryame = "مدیریت نوع زمین", SystemName = "EarthDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Earth", PersianCategoryame = "مدیریت نوع زمین ", SystemName = "EarthPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });


            #endregion Earth

            #region Equipment

            customePermissionList.Add(new Permission { Category = "Equipment", PersianCategoryame = "مدیریت تجهیزات  ", SystemName = "EquipmentList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Equipment", PersianCategoryame = "مدیریت تجهیزات  ", SystemName = "EquipmentCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Equipment", PersianCategoryame = "مدیریت تجهیزات  ", SystemName = "EquipmentEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Equipment", PersianCategoryame = "مدیریت تجهیزات ", SystemName = "EquipmentDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Equipment", PersianCategoryame = "مدیریت تجهیزات  ", SystemName = "EquipmentPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion Equipment

            #region EquipmentHasProperty

            customePermissionList.Add(new Permission { Category = "EquipmentHasProperty", PersianCategoryame = "مدیریت اختصاص مشخصه به تجهیزات  ", SystemName = "EquipmentHasPropertyList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "EquipmentHasProperty", PersianCategoryame = "مدیریت اختصاص مشخصه به تجهیزات  ", SystemName = "EquipmentHasPropertyCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "EquipmentHasProperty", PersianCategoryame = "مدیریت اختصاص مشخصه به تجهیزات ", SystemName = "EquipmentHasPropertyEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "EquipmentHasProperty", PersianCategoryame = "مدیریت اختصاص مشخصه به تجهیزات   ", SystemName = "EquipmentHasPropertyDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "EquipmentHasProperty", PersianCategoryame = "مدیریت اختصاص مشخصه به تجهیزات    ", SystemName = "EquipmentHasPropertyPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });


            #endregion EquipmentHasProperty


            #region Property

            customePermissionList.Add(new Permission { Category = "Property", PersianCategoryame = "مدیریت مشخصه تجهیزات  ", SystemName = "PropertyList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Property", PersianCategoryame = "مدیریت مشخصه تجهیزات  ", SystemName = "PropertyCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Property", PersianCategoryame = "مدیریت مشخصه تجهیزات  ", SystemName = "PropertyEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Property", PersianCategoryame = " مدیریت مشخصه تجهیزات ", SystemName = "PropertyDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Property", PersianCategoryame = "مدیریت مشخصه تجهیزات  ", SystemName = "PropertyPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });


            #endregion Property


            #region ScaffoldType

            customePermissionList.Add(new Permission { Category = "ScaffoldType", PersianCategoryame = "مدیریت نوع داربست   ", SystemName = "ScaffoldTypeList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "ScaffoldType", PersianCategoryame = "مدیریت نوع داربست   ", SystemName = "ScaffoldTypeCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "ScaffoldType", PersianCategoryame = "مدیریت نوع داربست   ", SystemName = "ScaffoldTypeEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "ScaffoldType", PersianCategoryame = " مدیریت نوع داربست  ", SystemName = "ScaffoldTypeDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "ScaffoldType", PersianCategoryame = "مدیریت نوع داربست   ", SystemName = "ScaffoldTypePrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });


            #endregion ScaffoldType

            #region Scaffolding

            customePermissionList.Add(new Permission { Category = "Scaffolding", PersianCategoryame = "مدیریت داربست   ", SystemName = "ScaffoldingList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Scaffolding", PersianCategoryame = "مدیریت داربست   ", SystemName = "ScaffoldingCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Scaffolding", PersianCategoryame = "مدیریت داربست   ", SystemName = "ScaffoldingEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Scaffolding", PersianCategoryame = " مدیریت داربست  ", SystemName = "ScaffoldingDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Scaffolding", PersianCategoryame = "مدیریت داربست   ", SystemName = "ScaffoldingPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });


            #endregion Scaffolding

            #region Unit

            customePermissionList.Add(new Permission { Category = "Unit", PersianCategoryame = "مدیریت واحد   ", SystemName = "UnitList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Unit", PersianCategoryame = "مدیریت واحد   ", SystemName = "UnitCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Unit", PersianCategoryame = "مدیریت واحد   ", SystemName = "UnitEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Unit", PersianCategoryame = " مدیریت واحد  ", SystemName = "UnitDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "Unit", PersianCategoryame = "مدیریت واحد   ", SystemName = "UnitPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion Unit

            #region BuyMaterial

            customePermissionList.Add(new Permission { Category = "BuyMaterial", PersianCategoryame = "مدیریت خرید تجهیزات    ", SystemName = "BuyMaterialList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "BuyMaterial", PersianCategoryame = "مدیریت خرید تجهیزات   ", SystemName = "BuyMaterialCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "BuyMaterial", PersianCategoryame = "مدیریت خرید تجهیزات   ", SystemName = "BuyMaterialEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "BuyMaterial", PersianCategoryame = " مدیریت خرید تجهیزات  ", SystemName = "BuyMaterialDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "BuyMaterial", PersianCategoryame = "مدیریت خرید تجهیزات   ", SystemName = "BuyMaterialPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion BuyMaterial

            #region InputMaterial

            customePermissionList.Add(new Permission { Category = "InputMaterial", PersianCategoryame = "مدیریت ورودی انبار    ", SystemName = "InputMaterialList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "InputMaterial", PersianCategoryame = "مدیریت ورودی انبار   ", SystemName = "InputMaterialCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "InputMaterial", PersianCategoryame = "مدیریت ورودی انبار   ", SystemName = "InputMaterialEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "InputMaterial", PersianCategoryame = " مدیریت ورودی انبار  ", SystemName = "InputMaterialDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "InputMaterial", PersianCategoryame = "مدیریت ورودی انبار   ", SystemName = "InputMaterialPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion InputMaterial

            #region OutputMaterial

            customePermissionList.Add(new Permission { Category = "OutputMaterial", PersianCategoryame = "مدیریت خروجی انبار    ", SystemName = "OutputMaterialList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "OutputMaterial", PersianCategoryame = "مدیریت خروجی انبار   ", SystemName = "OutputMaterialCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "OutputMaterial", PersianCategoryame = "مدیریت خروجی انبار   ", SystemName = "OutputMaterialEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "OutputMaterial", PersianCategoryame = " مدیریت خروجی انبار  ", SystemName = "OutputMaterialDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "OutputMaterial", PersianCategoryame = "مدیریت خروجی انبار   ", SystemName = "OutputMaterialPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion OutputMaterial

            #region WorkingGroup

            customePermissionList.Add(new Permission { Category = "WorkingGroup", PersianCategoryame = "مدیریت گروه کاری ", SystemName = "WorkingGroupList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkingGroup", PersianCategoryame = "مدیریت گروه کاری", SystemName = "WorkingGroupCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkingGroup", PersianCategoryame = "مدیریت گروه کاری", SystemName = "WorkingGroupEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkingGroup", PersianCategoryame = " مدیریت گروه کاری", SystemName = "WorkingGroupDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "WorkingGroup", PersianCategoryame = "مدیریت گروه کاری ", SystemName = "WorkingGroupPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion WorkingGroup

            #region CheckList

            customePermissionList.Add(new Permission { Category = "SafetyChecklist", PersianCategoryame = "مدیریت چک لیست ایمنی ", SystemName = "SafetyCheckList", Title = "نمایش ", CreatedDate = DateTime.Now, Active = false });

            customePermissionList.Add(new Permission { Category = "SafetyChecklist", PersianCategoryame = "مدیریت چک لیست ایمنی", SystemName = "SafetyCheckCreate", Title = "ایجاد ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "SafetyChecklist", PersianCategoryame = "مدیریت چک لیست ایمنی", SystemName = "SafetyCheckEdit", Title = "ویرایش ", CreatedDate = DateTime.Now, Active = true });

            customePermissionList.Add(new Permission { Category = "SafetyChecklist", PersianCategoryame = " مدیریت چک لیست ایمنی", SystemName = "SafetyCheckDelete", Title = "حذف ", CreatedDate = DateTime.Now, Active = false });

            customePermissionList.Add(new Permission { Category = "SafetyChecklist", PersianCategoryame = "مدیریت چک لیست ایمنی ", SystemName = "SafetyCheckPrint", Title = "چاپ", CreatedDate = DateTime.Now, Active = false });

            #endregion CheckList

            foreach (var item in customePermissionList)
            {

                context.Permission.Add(item);
                context.SaveChanges();
            }
        }

        private static void RemoveAdminPermissions(StoreContext context)
        {
            var admin = context.Users.Where(x => x.UserName == "admin").FirstOrDefault();
            //arj.Permissions = new List<Permission>();
            context.Users.AddOrUpdate(admin);
            context.SaveChanges();
        }

        private static void RolesAndUsers(StoreContext context)
        {
            var userstoreadmin = new UserStore<ApplicationUser>(context);
            var userManageradmin = new UserManager<ApplicationUser>(userstoreadmin);
            var useradmin = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                CreateDate = DateTime.Now,
                UserStatus = true,
                ApplicationRoles = new System.Collections.Generic.List<ApplicationRole>
            {
                new ApplicationRole { Name = "admin", PersianName = "مدیریت ", IsActive = true,CreateDate=DateTime.Now}
            }
            };
            userManageradmin.Create(useradmin, "1234567");

            context.SaveChanges();
        }

        private static void AddPositionType(StoreContext context)
        {
            var positionType = new PositionType
            {
                Title = "استادکار",
                SystemName = PositionTypeEnum.MasterOfWork.ToString(),
                CreatedDate = DateTime.Now,

            };

            context.PositionType.Add(positionType);
            context.SaveChanges();
        }


        private static void RemovePermissions(StoreContext context)
        {
            var allperm = context.Permission.ToList();
            foreach (var item in allperm)
            {
                context.Permission.Remove(item);
                context.SaveChanges();
            }
        }
        private static void InsertScaffoldType(StoreContext context)
        {
            List<ScaffoldType> scaffoldTypeList = new List<ScaffoldType>();

            var scaffoldType = new ScaffoldType
            {
                Title = "داربست مهاری مستقل تک دیواره",
                SystemName = "SingleWallIndependentBlockingScaffold",
                CreatedDate = DateTime.Now,

            };
            scaffoldTypeList.Add(scaffoldType);

            scaffoldType = new ScaffoldType
            {
                Title = "داربست مهاری مستقل زاویه دار",
                SystemName = "IndependentAngularScaffolding",
                CreatedDate = DateTime.Now,

            };
            scaffoldTypeList.Add(scaffoldType);

            scaffoldType = new ScaffoldType
            {
                Title = "داربست پلی",
                SystemName = "PolyScaffolding",
                CreatedDate = DateTime.Now,

            };
            scaffoldTypeList.Add(scaffoldType);

            scaffoldType = new ScaffoldType
            {
                Title = "داربست متحرک",
                SystemName = "MovableScaffold",
                CreatedDate = DateTime.Now,

            };
            scaffoldTypeList.Add(scaffoldType);

            scaffoldType = new ScaffoldType
            {
                Title = "داربست مخزن استوانه ای",
                SystemName = "CylinderTankScaffold",
                CreatedDate = DateTime.Now,

            };
            scaffoldTypeList.Add(scaffoldType);

            scaffoldType = new ScaffoldType
            {
                Title = "داربست مخزن کروی",
                SystemName = "SphericalTankScaffold",
                CreatedDate = DateTime.Now,

            };

            scaffoldTypeList.Add(scaffoldType);

            scaffoldType = new ScaffoldType
            {
                Title = "داربست قفسی",
                SystemName = "CageScaffold",
                CreatedDate = DateTime.Now,


            };
            scaffoldTypeList.Add(scaffoldType);

            foreach (var item in scaffoldTypeList)
            {

                context.ScaffoldType.Add(item);

            }
            context.SaveChanges();
        }

        private static void InsertEquipment(StoreContext context)
        {
            List<Equipment> equipmentList = new List<Equipment>();

            var equipment = new Equipment
            {
                Title = "تعداد لوله چهار فوت",
                SystemName = "fourFoot",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله پنج فوت",
                SystemName = "fiveFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله شش فوت ",
                SystemName = "sixFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله هشت فوت",
                SystemName = "eightFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله ده فوت",
                SystemName = "tenFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله دوازده فوت",
                SystemName = "TwelveFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله چهارده فوت",
                SystemName = "fourteenFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله شانزده فوت",
                SystemName = "SixteenFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله هجده فوت",
                SystemName = "EighteenFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "تعداد لوله بیست فوت",
                SystemName = "twentyFeet",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            foreach (var item in equipmentList)
            {

                context.Equipment.Add(item);

            }
            context.SaveChanges();
        }
        // اینجا برای سنتی فقط یه لیست لازم داشتیم ولی برا سیستمی 3 تا لیست لازم داریم
        private static void InsertEquipmentSys(StoreContext context)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            // الان تو سیستمی 3 تا لیست لازم داریم لیست پایه لیست کشابی لست پلیت
            var equipment = new Equipment
            {
                Title = " پایه چهار متر",
                SystemName = "baseFour",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پایه سه متر",
                SystemName = "baseThree",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پایه دو متر ",
                SystemName = "baseTwo",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پایه یک متر",
                SystemName = "baseOne",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پایه نیم متر",
                SystemName = "baseHalf",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "کشابی سه متر",
                SystemName = "keshabiThree",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "کشابی دو و نیم متر",
                SystemName = "keshabitwoHalf",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "کشابی یک متر و سی سانت",
                SystemName = "keshabiOneThirty",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "کشابی یک متر",
                SystemName = "keshabiOne",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "کشابی هفتاد و پنج سانت",
                SystemName = "keshabiSeventyFive",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پلیت سه متر",
                SystemName = "plateThree",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پلیت دو و نیم متر",
                SystemName = "plateTwoHalf",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پلیت یک متر و سی سانت",
                SystemName = "plateOneThirty",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پلیت یک متر",
                SystemName = "plateOne",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);

            equipment = new Equipment
            {
                Title = "پلیت هفتاد و پنج سانت",
                SystemName = "plateSeventyFive",
                CreatedDate = DateTime.Now,

            };
            equipmentList.Add(equipment);



            foreach (var item in equipmentList)
            {

                context.Equipment.Add(item);

            }
            context.SaveChanges();
        }

        private static void UpdatePermissions(StoreContext context)
        {

            List<Permission> customePermissionList = new List<Permission>();

            var allPermissions = context.Permission.ToList();
            foreach (var entityPermission in customePermissionList)
            {
                var find = allPermissions.FirstOrDefault(x => x.SystemName == entityPermission.SystemName);
                find.Category = entityPermission.Category;
                context.Permission.AddOrUpdate(find);
            }

            context.SaveChanges();
        }

        private static void InsertQuestions(StoreContext context)
        {
            List<Question> questionList = new List<Question>();


            questionList.Add(new Question { Text = "آیا برای نصب داربست مجوز اخذ شده است؟", Score = 5 });
            questionList.Add(new Question { Text = "آیا اشخاص با تجربه و ماهر مسئول برپایی داربست بوده اند؟", Score = 5 });
            questionList.Add(new Question { Text = "آیا اجزاء تشکیل دهنده داربست در شرایط مطمئن و ایمنی برای استفاده قرار دارند؟", Score = 3 });
            questionList.Add(new Question { Text = "آیا داربست تراز افقی و عمودی شده است؟", Score = 3 });
            questionList.Add(new Question { Text = "آیا برای تراز شدن افقی و عمودی داربست به جای اشیاء نامطمئن و ناپایدار مثل بلوک ها، آجرهای لق و غیره، از جک های پیچی استفاده شده است؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا صفحات پایه و جک های پیچی اتصال محکمی با لوله های استاندارد و فریم ها دارند؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا همه ی پایه های داربست به خوبی با مهارها محکم شده اند؟", Score = 3 });
            questionList.Add(new Question { Text = "آیا نرده های حفاظتی در ارتفاع 0.5 و 1 متر بالای سکوی کار نصب شده اند؟", Score = 5 });
            questionList.Add(new Question { Text = "آیا لبه های پاخور حفاظتی قسمت پایین سکو(Toe boards) نصب شده اند؟", Score = 3 });
            questionList.Add(new Question { Text = "آیا برای دسترسی و ورود و خروج از داربست، نردبان تهیه شده است؟", Score = 2 });
            questionList.Add(new Question { Text = "آیا سطح کار با استفاده از الوار یا ورق های فلزی مشبک مناسب پوشانده و مهار شده است؟", Score = 2 });
            questionList.Add(new Question { Text = "آیا الوارها حداقل 30 سانتی متر در جهت طولی روی هم افتادگی دارند و به اندازه 7 تا 20 سانتی متر جلوتر از تکیه گاه امتداد یافته اند و انتهای الوار با سیم های گالوانیزه به ضخامت 3 میلی متر محکم بسته شده است؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا داربست برای تردد آسان وسایل نقلیه مزاحمت ایجاد کرده است؟", Score = 2 });
            questionList.Add(new Question { Text = "آیا شرایط مخاطره آمیز به لحاظ نزدیکی به ساختمان در حال تخریب و غیره وجود دارد؟", Score = 2 });

            questionList.Add(new Question { Text = "آیا داربست ها، حداقل هر 9 متر طول و 8 متر ارتفاع به سازه چفت و بست شده است؟", Score = 3 });
            questionList.Add(new Question { Text = "آیا فاصله مجاز با خطوط برق رعایت شده است؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا داربست متحرک مجهز به ترمز چرخ می باشد؟", Score = 5 });
            questionList.Add(new Question { Text = "آیا Tie به صورت محکم و قابل قبول سازه اصلی را به داربست متصل می کند؟", Score = 3 });
            questionList.Add(new Question { Text = "آیا از Ledger Bracing یا بادبند عرضی در در داربست از کف تا بالای داربست استفاده می شود؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا حداقل عرض طبقات Platforms برای شخص 60 سانتیمتر و سه تخته و برای مصالح 80 سانتیمتر و چهار تخته رعایت می شود؟", Score = 3 });
            questionList.Add(new Question { Text = "آیا ضخامت الوار و تخته های استفاده شده روی Transom یا Putlog بسته به نوع کار و ظرفیت باربری داربست بین 32 mm  تا 63 mm می باشد؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا فاصله Transom یا Putlog در هر حال نباید از 2.7  متر تجاوز کند و برای کارهای سنگین باید به 1.8 متر کاهش یابد.", Score = 4 });
            questionList.Add(new Question { Text = " آیا Base Plate و Sol Plate برای زمین های سخت 45 Cm * 22.5 Cm * 3.5 Cm برقرار می باشد ؟", Score = 2 });
            questionList.Add(new Question { Text = " آیا Base Plate و Sol Plate برای زمین های نرم 76 Cm * 22.5 Cm * 3.5 Cm برقرار می باشد ؟", Score = 2 });
            questionList.Add(new Question { Text = "حداقل سطح زیر Sole Plate برای زمین های سخت 1000 Cm2 و برای زمین های نرم 1700 Cm2 می باشد؟", Score = 2 });
            questionList.Add(new Question { Text = "Base Plate 15 Cm * 15 Cm", Score = 2 });
            questionList.Add(new Question { Text = "آیا علائم هشدار دهنده ایمنی بر روی داربست نصب شده اند؟ و آیا از سیستم Lock Out و Tag برای داربست ها استفاده می شود؟", Score = 5 });
            questionList.Add(new Question { Text = "آیا میزان بیرون زدگی  (Over Hang) تخته ها بین 5-15Cm است؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا زاویه کوپلینگ (جفت شدن دو عضو) با یکدیگر 90 درجه است؟ (به استثنای بادبندها)", Score = 3 });
            questionList.Add(new Question { Text = "آیا اعضاء داربست آسیب دیدگی، پوسیدگی، زنگ زدگی و دیگر عواملی که بر روی پایداری آنها تاثیر می گذارد هستند؟", Score = 4 });
            questionList.Add(new Question { Text = "آیا حفاظ های توری در صورت نیاز در بالای جایگاه و زیر آن نصب شده اند؟", Score = 3 });


            foreach (var item in questionList)
                context.Question.Add(item);

            context.SaveChanges();
        }


    }
}
