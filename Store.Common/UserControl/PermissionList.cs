using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.WebEssential.UserControl
{
    public static class PermissionList
    {


        #region BrowseDaily
        public static Permission BrowseDailyList { get { return new Permission() { Category = "BrowseDaily", SystemName = "BrowseDailyList" }; } }
        public static Permission BrowseDailyEdit { get { return new Permission() { Category = "BrowseDaily", SystemName = "BrowseDailyEdit" }; } }
        public static Permission BrowseDailyDelete { get { return new Permission() { Category = "BrowseDaily", SystemName = "BrowseDailyDelete" }; } }
        public static Permission BrowseDailyCreate { get { return new Permission() { Category = "BrowseDaily", SystemName = "BrowseDailyCreate" }; } }
        public static Permission BrowseDailyPrint { get { return new Permission() { Category = "BrowseDaily", SystemName = "BrowseDailyPrint" }; } }

        #endregion BrowseDaily

        #region AssignedTask
        public static Permission AssignedTaskList { get { return new Permission() { Category = "AssignedTask", SystemName = "AssignedTaskList" }; } }
        public static Permission AssignedTaskEdit { get { return new Permission() { Category = "AssignedTask", SystemName = "AssignedTaskEdit" }; } }
        public static Permission AssignedTaskDelete { get { return new Permission() { Category = "AssignedTask", SystemName = "AssignedTaskDelete" }; } }
        public static Permission AssignedTaskCreate { get { return new Permission() { Category = "AssignedTask", SystemName = "AssignedTaskCreate" }; } }

        #endregion AssignedTask

        #region Attendance
        public static Permission AttendanceList { get { return new Permission() { Category = "Attendance", SystemName = "AttendanceList" }; } }
        public static Permission AttendanceEdit { get { return new Permission() { Category = "Attendance", SystemName = "AttendanceEdit" }; } }
        public static Permission AttendanceDelete { get { return new Permission() { Category = "Attendance", SystemName = "AttendanceDelete" }; } }
        public static Permission AttendanceCreate { get { return new Permission() { Category = "Attendance", SystemName = "AttendanceCreate" }; } }
        public static Permission AttendancePrint { get { return new Permission() { Category = "Attendance", SystemName = "AttendancePrint" }; } }

        #endregion Attendance

        #region Company
        public static Permission CompanyList { get { return new Permission() { Category = "Company", SystemName = "CompanyList" }; } }
        public static Permission CompanyEdit { get { return new Permission() { Category = "Company", SystemName = "CompanyEdit" }; } }
        public static Permission CompanyDelete { get { return new Permission() { Category = "Company", SystemName = "CompanyDelete" }; } }
        public static Permission CompanyCreate { get { return new Permission() { Category = "Company", SystemName = "CompanyCreate" }; } }
        public static Permission CompanyPrint { get { return new Permission() { Category = "Company", SystemName = "CompanyPrint" }; } }

        #endregion Company

        #region WorkOrder
        public static Permission WorkOrderList { get { return new Permission() { Category = "WorkOrder", SystemName = "WorkOrderList" }; } }
        public static Permission WorkOrderEdit { get { return new Permission() { Category = "WorkOrder", SystemName = "WorkOrderEdit" }; } }
        public static Permission WorkOrderDelete { get { return new Permission() { Category = "WorkOrder", SystemName = "WorkOrderDelete" }; } }
        public static Permission WorkOrderCreate { get { return new Permission() { Category = "WorkOrder", SystemName = "WorkOrderCreate" }; } }
        public static Permission WorkOrderPrint { get { return new Permission() { Category = "WorkOrder", SystemName = "WorkOrderPrint" }; } }

        #endregion WorkOrder

        #region Routin
        public static Permission RoutinList { get { return new Permission() { Category = "Routin", SystemName = "RoutinList" }; } }
        public static Permission RoutinEdit { get { return new Permission() { Category = "Routin", SystemName = "RoutinEdit" }; } }
        public static Permission RoutinDelete { get { return new Permission() { Category = "Routin", SystemName = "RoutinDelete" }; } }
        public static Permission RoutinCreate { get { return new Permission() { Category = "Routin", SystemName = "RoutinCreate" }; } }
        public static Permission RoutinPrint { get { return new Permission() { Category = "Routin", SystemName = "RoutinPrint" }; } }

        #endregion Routin

        #region PositionType
        public static Permission PositionTypeList { get { return new Permission() { Category = "PositionType", SystemName = "PositionTypeList" }; } }
        public static Permission PositionTypeEdit { get { return new Permission() { Category = "PositionType", SystemName = "PositionTypeEdit" }; } }
        public static Permission PositionTypeDelete { get { return new Permission() { Category = "PositionType", SystemName = "PositionTypeDelete" }; } }
        public static Permission PositionTypeCreate { get { return new Permission() { Category = "PositionType", SystemName = "PositionTypeCreate" }; } }
        public static Permission PositionTypePrint { get { return new Permission() { Category = "PositionType", SystemName = "PositionTypePrint" }; } }

        #endregion PositionType

        #region EmployeeType
        public static Permission EmployeeTypeList { get { return new Permission() { Category = "EmployeeType", SystemName = "EmployeeTypeList" }; } }
        public static Permission EmployeeTypeEdit { get { return new Permission() { Category = "EmployeeType", SystemName = "EmployeeTypeEdit" }; } }
        public static Permission EmployeeTypeDelete { get { return new Permission() { Category = "EmployeeType", SystemName = "EmployeeTypeDelete" }; } }
        public static Permission EmployeeTypeCreate { get { return new Permission() { Category = "EmployeeType", SystemName = "EmployeeTypeCreate" }; } }
        public static Permission EmployeeTypePrint { get { return new Permission() { Category = "EmployeeType", SystemName = "EmployeeTypePrint" }; } }

        #endregion EmployeeType

        #region Personnel
        public static Permission PersonnelList { get { return new Permission() { Category = "Personnel", SystemName = "PersonnelList" }; } }
        public static Permission PersonnelEdit { get { return new Permission() { Category = "Personnel", SystemName = "PersonnelEdit" }; } }
        public static Permission PersonnelDelete { get { return new Permission() { Category = "Personnel", SystemName = "PersonnelDelete" }; } }
        public static Permission PersonnelCreate { get { return new Permission() { Category = "Personnel", SystemName = "PersonnelCreate" }; } }
        public static Permission PersonnelPrint { get { return new Permission() { Category = "Personnel", SystemName = "PersonnelPrint" }; } }

        #endregion Personnel

        #region User
        public static Permission UserList { get { return new Permission() { Category = "User", SystemName = "UserList" }; } }
        public static Permission UserEdit { get { return new Permission() { Category = "User", SystemName = "UserEdit" }; } }
        public static Permission UserDelete { get { return new Permission() { Category = "User", SystemName = "UserDelete" }; } }
        public static Permission UserCreate { get { return new Permission() { Category = "User", SystemName = "UserCreate" }; } }
        public static Permission UserPrint { get { return new Permission() { Category = "User", SystemName = "UserPrint" }; } }


        #endregion User


        #region Role
        public static Permission RoleList { get { return new Permission() { Category = "Role", SystemName = "RoleList" }; } }
        public static Permission RoleEdit { get { return new Permission() { Category = "Role", SystemName = "RoleEdit" }; } }
        public static Permission RoleDelete { get { return new Permission() { Category = "Role", SystemName = "RoleDelete" }; } }
        public static Permission RoleCreate { get { return new Permission() { Category = "Role", SystemName = "RoleCreate" }; } }
        public static Permission RolePrint { get { return new Permission() { Category = "Role", SystemName = "RolePrint" }; } }

        #endregion Role

        #region Message
        public static Permission MessageList { get { return new Permission() { Category = "Message", SystemName = "MessageList" }; } }
        public static Permission MessageEdit { get { return new Permission() { Category = "Message", SystemName = "MessageEdit" }; } }
        public static Permission MessageDelete { get { return new Permission() { Category = "Message", SystemName = "MessageDelete" }; } }
        public static Permission MessageCreate { get { return new Permission() { Category = "Message", SystemName = "MessageCreate" }; } }
        public static Permission MessagePrint { get { return new Permission() { Category = "Message", SystemName = "MessagePrint" }; } }

        #endregion Message

        #region CompanyStoreRoom
        public static Permission CompanyStoreRoomList { get { return new Permission() { Category = "CompanyStoreRoom", SystemName = "CompanyStoreRoomList" }; } }
        public static Permission CompanyStoreRoomEdit { get { return new Permission() { Category = "CompanyStoreRoom", SystemName = "CompanyStoreRoomEdit" }; } }
        public static Permission CompanyStoreRoomDelete { get { return new Permission() { Category = "CompanyStoreRoom", SystemName = "CompanyStoreRoomDelete" }; } }
        public static Permission CompanyStoreRoomCreate { get { return new Permission() { Category = "CompanyStoreRoom", SystemName = "CompanyStoreRoomCreate" }; } }
        public static Permission CompanyStoreRoomPrint { get { return new Permission() { Category = "CompanyStoreRoom", SystemName = "CompanyStoreRoomPrint" }; } }

        #endregion CompanyStoreRoom

        #region Building
        public static Permission BuildingList { get { return new Permission() { Category = "Building", SystemName = "BuildingList" }; } }
        public static Permission BuildingEdit { get { return new Permission() { Category = "Building", SystemName = "BuildingEdit" }; } }
        public static Permission BuildingDelete { get { return new Permission() { Category = "Building", SystemName = "BuildingDelete" }; } }
        public static Permission BuildingCreate { get { return new Permission() { Category = "Building", SystemName = "BuildingCreate" }; } }
        public static Permission BuildingPrint { get { return new Permission() { Category = "Building", SystemName = "BuildingPrint" }; } }

        #endregion Building

        #region Earth
        public static Permission EarthList { get { return new Permission() { Category = "Earth", SystemName = "EarthList" }; } }
        public static Permission EarthEdit { get { return new Permission() { Category = "Earth", SystemName = "EarthEdit" }; } }
        public static Permission EarthDelete { get { return new Permission() { Category = "Earth", SystemName = "EarthDelete" }; } }
        public static Permission EarthCreate { get { return new Permission() { Category = "Earth", SystemName = "EarthCreate" }; } }
        public static Permission EarthPrint { get { return new Permission() { Category = "Earth", SystemName = "EarthPrint" }; } }

        #endregion Earth

        #region Equipment
        public static Permission EquipmentList { get { return new Permission() { Category = "Equipment", SystemName = "EquipmentList" }; } }
        public static Permission EquipmentEdit { get { return new Permission() { Category = "Equipment", SystemName = "EquipmentEdit" }; } }
        public static Permission EquipmentDelete { get { return new Permission() { Category = "Equipment", SystemName = "EquipmentDelete" }; } }
        public static Permission EquipmentCreate { get { return new Permission() { Category = "Equipment", SystemName = "EquipmentCreate" }; } }
        public static Permission EquipmentPrint { get { return new Permission() { Category = "Equipment", SystemName = "EquipmentPrint" }; } }

        #endregion Equipment

        #region EquipmentHasProperty
        public static Permission EquipmentHasPropertyList { get { return new Permission() { Category = "EquipmentHasProperty", SystemName = "EquipmentHasPropertyList" }; } }
        public static Permission EquipmentHasPropertyEdit { get { return new Permission() { Category = "EquipmentHasProperty", SystemName = "EquipmentHasPropertyEdit" }; } }
        public static Permission EquipmentHasPropertyDelete { get { return new Permission() { Category = "EquipmentHasProperty", SystemName = "EquipmentHasPropertyDelete" }; } }
        public static Permission EquipmentHasPropertyCreate { get { return new Permission() { Category = "EquipmentHasProperty", SystemName = "EquipmentHasPropertyCreate" }; } }
        public static Permission EquipmentHasPropertyPrint { get { return new Permission() { Category = "EquipmentHasProperty", SystemName = "EquipmentHasPropertyPrint" }; } }

        #endregion EquipmentHasProperty

        #region Property
        public static Permission PropertyList { get { return new Permission() { Category = "Property", SystemName = "PropertyList" }; } }
        public static Permission PropertyEdit { get { return new Permission() { Category = "Property", SystemName = "PropertyEdit" }; } }
        public static Permission PropertyDelete { get { return new Permission() { Category = "Property", SystemName = "PropertyDelete" }; } }
        public static Permission PropertyCreate { get { return new Permission() { Category = "Property", SystemName = "PropertyCreate" }; } }
        public static Permission PropertyPrint { get { return new Permission() { Category = "Property", SystemName = "PropertyPrint" }; } }

        #endregion Property

        #region ScaffoldHasEquipment
        public static Permission ScaffoldHasEquipmentList { get { return new Permission() { Category = "ScaffoldHasEquipment", SystemName = "ScaffoldHasEquipmentList" }; } }
        public static Permission ScaffoldHasEquipmentEdit { get { return new Permission() { Category = "ScaffoldHasEquipment", SystemName = "ScaffoldHasEquipmentEdit" }; } }
        public static Permission ScaffoldHasEquipmentDelete { get { return new Permission() { Category = "ScaffoldHasEquipment", SystemName = "ScaffoldHasEquipmentDelete" }; } }
        public static Permission ScaffoldHasEquipmentCreate { get { return new Permission() { Category = "ScaffoldHasEquipment", SystemName = "ScaffoldHasEquipmentCreate" }; } }
        public static Permission ScaffoldHasEquipmentPrint { get { return new Permission() { Category = "ScaffoldHasEquipment", SystemName = "ScaffoldHasEquipmentPrint" }; } }

        #endregion ScaffoldHasEquipment


        #region ScaffoldType
        public static Permission ScaffoldTypeList { get { return new Permission() { Category = "ScaffoldType", SystemName = "ScaffoldTypeList" }; } }
        public static Permission ScaffoldTypeEdit { get { return new Permission() { Category = "ScaffoldType", SystemName = "ScaffoldTypeEdit" }; } }
        public static Permission ScaffoldTypeDelete { get { return new Permission() { Category = "ScaffoldType", SystemName = "ScaffoldTypeDelete" }; } }
        public static Permission ScaffoldTypeCreate { get { return new Permission() { Category = "ScaffoldType", SystemName = "ScaffoldTypeCreate" }; } }
        public static Permission ScaffoldTypePrint { get { return new Permission() { Category = "ScaffoldType", SystemName = "ScaffoldTypePrint" }; } }

        #endregion ScaffoldType

        #region Scaffolding
        public static Permission ScaffoldingList { get { return new Permission() { Category = "Scaffolding", SystemName = "ScaffoldingList" }; } }
        public static Permission ScaffoldingEdit { get { return new Permission() { Category = "Scaffolding", SystemName = "ScaffoldingEdit" }; } }
        public static Permission ScaffoldingDelete { get { return new Permission() { Category = "Scaffolding", SystemName = "ScaffoldingDelete" }; } }
        public static Permission ScaffoldingCreate { get { return new Permission() { Category = "Scaffolding", SystemName = "ScaffoldingCreate" }; } }
        public static Permission ScaffoldingPrint { get { return new Permission() { Category = "Scaffolding", SystemName = "ScaffoldingPrint" }; } }

        #endregion Scaffolding

        #region Unit
        public static Permission UnitList { get { return new Permission() { Category = "Unit", SystemName = "UnitList" }; } }
        public static Permission UnitEdit { get { return new Permission() { Category = "Unit", SystemName = "UnitEdit" }; } }
        public static Permission UnitDelete { get { return new Permission() { Category = "Unit", SystemName = "UnitDelete" }; } }
        public static Permission UnitCreate { get { return new Permission() { Category = "Unit", SystemName = "UnitCreate" }; } }
        public static Permission UnitPrint { get { return new Permission() { Category = "Unit", SystemName = "UnitPrint" }; } }

        #endregion Unit

        #region BuyMaterial
        public static Permission BuyMaterialList { get { return new Permission() { Category = "BuyMaterial", SystemName = "BuyMaterialList" }; } }
        public static Permission BuyMaterialEdit { get { return new Permission() { Category = "BuyMaterial", SystemName = "BuyMaterialEdit" }; } }
        public static Permission BuyMaterialDelete { get { return new Permission() { Category = "BuyMaterial", SystemName = "BuyMaterialDelete" }; } }
        public static Permission BuyMaterialCreate { get { return new Permission() { Category = "BuyMaterial", SystemName = "BuyMaterialCreate" }; } }
        public static Permission BuyMaterialPrint { get { return new Permission() { Category = "BuyMaterial", SystemName = "BuyMaterialPrint" }; } }

        #endregion BuyMaterial

        #region BuyMaterialReport
        public static Permission BuyMaterialReportList { get { return new Permission() { Category = "BuyMaterialReport", SystemName = "BuyMaterialReportList" }; } }
        public static Permission BuyMaterialReportEdit { get { return new Permission() { Category = "BuyMaterialReport", SystemName = "BuyMaterialReportEdit" }; } }
        public static Permission BuyMaterialReportDelete { get { return new Permission() { Category = "BuyMaterialReport", SystemName = "BuyMaterialReportDelete" }; } }
        public static Permission BuyMaterialReportCreate { get { return new Permission() { Category = "BuyMaterialReport", SystemName = "BuyMaterialReportCreate" }; } }
        public static Permission BuyMaterialReportPrint { get { return new Permission() { Category = "BuyMaterialReport", SystemName = "BuyMaterialReportPrint" }; } }

        #endregion BuyMaterialReport

        #region InputMaterial
        public static Permission InputMateriaList { get { return new Permission() { Category = "InputMaterial", SystemName = "InputMaterialList" }; } }
        public static Permission InputMaterialEdit { get { return new Permission() { Category = "InputMaterial", SystemName = "InputMaterialEdit" }; } }
        public static Permission InputMaterialDelete { get { return new Permission() { Category = "InputMaterial", SystemName = "InputMaterialDelete" }; } }
        public static Permission InputMaterialCreate { get { return new Permission() { Category = "InputMaterial", SystemName = "InputMaterialCreate" }; } }
        public static Permission InputMaterialPrint { get { return new Permission() { Category = "InputMaterial", SystemName = "InputMaterialPrint" }; } }

        #endregion InputMaterial

        #region OutputMaterial
        public static Permission OutputMaterialList { get { return new Permission() { Category = "OutputMaterial", SystemName = "OutputMaterialList" }; } }
        public static Permission OutputMaterialEdit { get { return new Permission() { Category = "OutputMaterial", SystemName = "OutputMaterialEdit" }; } }
        public static Permission OutputMaterialDelete { get { return new Permission() { Category = "OutputMaterial", SystemName = "OutputMaterialDelete" }; } }
        public static Permission OutputMaterialCreate { get { return new Permission() { Category = "OutputMaterial", SystemName = "OutputMaterialCreate" }; } }
        public static Permission OutputMaterialPrint { get { return new Permission() { Category = "OutputMaterial", SystemName = "OutputMaterialPrint" }; } }

        #endregion OutputMaterial

        #region ReportStock
        public static Permission ReportStockList { get { return new Permission() { Category = "ReportStock", SystemName = "ReportStockList" }; } }
        public static Permission ReportStockEdit { get { return new Permission() { Category = "ReportStock", SystemName = "ReportStockEdit" }; } }
        public static Permission ReportStockDelete { get { return new Permission() { Category = "ReportStock", SystemName = "ReportStockDelete" }; } }
        public static Permission ReportStockCreate { get { return new Permission() { Category = "ReportStock", SystemName = "ReportStockCreate" }; } }
        public static Permission ReportStockPrint { get { return new Permission() { Category = "ReportStock", SystemName = "ReportStockPrint" }; } }

        #endregion ReportStock

        #region Stock
        public static Permission StockList { get { return new Permission() { Category = "Stock", SystemName = "StockList" }; } }
        public static Permission StockEdit { get { return new Permission() { Category = "Stock", SystemName = "StockEdit" }; } }
        public static Permission StockDelete { get { return new Permission() { Category = "Stock", SystemName = "StockDelete" }; } }
        public static Permission StockCreate { get { return new Permission() { Category = "Stock", SystemName = "StockCreate" }; } }
        public static Permission StockPrint { get { return new Permission() { Category = "Stock", SystemName = "StockPrint" }; } }

        #endregion Stock

        #region WorkingGroup
        public static Permission WorkingGroupList { get { return new Permission() { Category = "WorkingGroup", SystemName = "WorkingGroupList" }; } }
        public static Permission WorkingGroupEdit { get { return new Permission() { Category = "WorkingGroup", SystemName = "WorkingGroupEdit" }; } }
        public static Permission WorkingGroupDelete { get { return new Permission() { Category = "WorkingGroup", SystemName = "WorkingGroupDelete" }; } }
        public static Permission WorkingGroupCreate { get { return new Permission() { Category = "WorkingGroup", SystemName = "WorkingGroupCreate" }; } }
        public static Permission WorkingGroupPrint { get { return new Permission() { Category = "WorkingGroup", SystemName = "WorkingGroupPrint" }; } }

        #endregion WorkingGroup

        #region SafetyChecklist
        public static Permission SafetyCheckList { get { return new Permission() { Category = "SafetyChecklist", SystemName = "SafetyCheckList" }; } }
        public static Permission SafetyCheckCreate { get { return new Permission() { Category = "SafetyChecklist", SystemName = "SafetyCheckCreate" }; } }
        public static Permission SafetyCheckEdit { get { return new Permission() { Category = "SafetyChecklist", SystemName = "SafetyCheckEdit" }; } }
        public static Permission SafetyCheckDelete { get { return new Permission() { Category = "SafetyChecklist", SystemName = "SafetyCheckDelete" }; } }
        public static Permission SafetyCheckPrint { get { return new Permission() { Category = "SafetyChecklist", SystemName = "SafetyCheckPrint" }; } }

        #endregion SafetyChecklist

      
    }
}