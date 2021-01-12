namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllowedRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        IdentityRoleId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.AspNetRoles", t => t.IdentityRoleId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.IdentityRoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonnelCode = c.String(),
                        UserStatus = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        DateExpire = c.DateTime(),
                        Description = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        PositionType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PositionTypes", t => t.PositionType_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.PositionType_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        IsActive = c.Boolean(),
                        PersianName = c.String(),
                        CreateDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SystemName = c.String(),
                        Category = c.String(),
                        PersianCategoryame = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desirable = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        ScaffoldingId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: false)
                .ForeignKey("dbo.Scaffoldings", t => t.ScaffoldingId, cascadeDelete: false)
                .Index(t => t.QuestionId)
                .Index(t => t.ScaffoldingId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Score = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scaffoldings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        ExpertName = c.String(),
                        PermitNumber = c.String(),
                        RegistrationDate = c.DateTime(),
                        Tag = c.String(),
                        Date = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        SafetyTagExpire = c.DateTime(),
                        Image = c.Int(),
                        confirmed = c.Boolean(nullable: false),
                        TotalPoints = c.Int(nullable: false),
                        RealArea = c.Int(nullable: false),
                        ScaffoldStates = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        EarthId = c.Int(nullable: false),
                        ScaffoldTypeId = c.Int(nullable: false),
                        PersonnelCode = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: false)
                .ForeignKey("dbo.Earths", t => t.EarthId, cascadeDelete: false)
                .ForeignKey("dbo.Personnels", t => t.PersonnelCode)
                .ForeignKey("dbo.ScaffoldTypes", t => t.ScaffoldTypeId, cascadeDelete: false)
                .Index(t => t.Title, unique: true)
                .Index(t => t.BuildingId)
                .Index(t => t.EarthId)
                .Index(t => t.ScaffoldTypeId)
                .Index(t => t.PersonnelCode);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Earths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        PersonnelCode = c.Int(nullable: false),
                        UserNameFmaily = c.String(nullable: false),
                        BirthDate = c.DateTime(),
                        DateEmployeement = c.DateTime(),
                        MaritalStatus = c.Int(),
                        StatusPresence = c.Int(),
                        NationalCode = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastEditUserId = c.String(),
                        PositionTypeId = c.Int(),
                        EmployeeTypeId = c.Int(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonnelCode)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmployeeTypeId)
                .ForeignKey("dbo.PositionTypes", t => t.PositionTypeId)
                .Index(t => t.PositionTypeId)
                .Index(t => t.EmployeeTypeId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        PresenceStatus = c.Int(nullable: false),
                        PersonnelCode = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnels", t => t.PersonnelCode, cascadeDelete: false)
                .Index(t => t.PersonnelCode);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 4000),
                        Address = c.String(),
                        ParentID = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PositionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        SystemName = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.WorkingGroupPersonnels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkgroupId = c.Int(nullable: false),
                        PersonnelCode = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnels", t => t.PersonnelCode, cascadeDelete: false)
                .ForeignKey("dbo.Workgroups", t => t.WorkgroupId, cascadeDelete: false)
                .Index(t => t.WorkgroupId)
                .Index(t => t.PersonnelCode);
            
            CreateTable(
                "dbo.Workgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScaffoldTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        SystemName = c.String(),
                        Image = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignedTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        RoutineId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routines", t => t.RoutineId, cascadeDelete: false)
                .Index(t => t.RoutineId);
            
            CreateTable(
                "dbo.Routines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignedTaskUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonnelCode = c.Int(nullable: false),
                        AssignedTaskId = c.Int(nullable: false),
                        PositionTypeId = c.Int(),
                        EmployeeTypeId = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnels", t => t.PersonnelCode, cascadeDelete: false)
                .ForeignKey("dbo.AssignedTasks", t => t.AssignedTaskId, cascadeDelete: false)
                .Index(t => t.PersonnelCode)
                .Index(t => t.AssignedTaskId);
            
            CreateTable(
                "dbo.AssignedWorkorders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        RealArea = c.Int(nullable: false),
                        WorkOrderId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrderId, cascadeDelete: false)
                .Index(t => t.WorkOrderId);
            
            CreateTable(
                "dbo.AssignedWorkorderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalArea = c.Int(nullable: false),
                        WorkorderId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        SectionId = c.Int(),
                        UnitId = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                        AssignedWorkorder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrders", t => t.WorkorderId, cascadeDelete: false)
                .ForeignKey("dbo.AssignedWorkorders", t => t.AssignedWorkorder_Id)
                .Index(t => t.WorkorderId)
                .Index(t => t.AssignedWorkorder_Id);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 4000),
                        Tag = c.String(),
                        Date = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        RealArea = c.Int(nullable: false),
                        ScaffoldingId = c.Int(),
                        CompanyId = c.Int(nullable: false),
                        SectionId = c.Int(),
                        UnitId = c.Int(),
                        Priority = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.Scaffoldings", t => t.ScaffoldingId)
                .ForeignKey("dbo.Companies", t => t.SectionId)
                .ForeignKey("dbo.Companies", t => t.UnitId)
                .Index(t => t.ScaffoldingId)
                .Index(t => t.CompanyId)
                .Index(t => t.SectionId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.WorkorderAssignedUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.Int(nullable: false),
                        PersonnelCode = c.Int(nullable: false),
                        AssignedWorkorderDetailId = c.Int(nullable: false),
                        WorkorderId = c.Int(nullable: false),
                        WorkgroupId = c.Int(nullable: false),
                        PositionTypeId = c.Int(),
                        IsMasterOfWork = c.Boolean(nullable: false),
                        EmployeeTypeId = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssignedWorkorderDetails", t => t.AssignedWorkorderDetailId, cascadeDelete: false)
                .ForeignKey("dbo.Personnels", t => t.PersonnelCode, cascadeDelete: false)
                .Index(t => t.PersonnelCode)
                .Index(t => t.AssignedWorkorderDetailId);
            
            CreateTable(
                "dbo.BuyMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(),
                        EquipmentId = c.Int(nullable: false),
                        CompanyStoreRoomId = c.Int(),
                        UnitId = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyStoreRooms", t => t.CompanyStoreRoomId)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .Index(t => t.EquipmentId)
                .Index(t => t.CompanyStoreRoomId);
            
            CreateTable(
                "dbo.CompanyStoreRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        SystemName = c.String(),
                        Image = c.Int(),
                        Weight = c.Int(nullable: false),
                        MinimumInventoryPercentage = c.Int(nullable: false),
                        MinimumInventory = c.Int(nullable: false),
                        EquipmentType = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentHasProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EquipmentId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        UnitId = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: false)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .Index(t => t.EquipmentId)
                .Index(t => t.PropertyId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InputMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        OutputMaterialId = c.Int(nullable: false),
                        WorkOrderId = c.Int(nullable: false),
                        ScaffoldingId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DefectiveNumber = c.Int(nullable: false),
                        MissingNumber = c.Int(nullable: false),
                        HealthyNumber = c.Int(nullable: false),
                        Date = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                        OutputMaterial_EquipmentId = c.Int(),
                        OutputMaterial_WorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => new { t.EquipmentId, t.WorkOrderId })
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .ForeignKey("dbo.OutputMaterials", t => new { t.OutputMaterial_EquipmentId, t.OutputMaterial_WorkOrderId })
                .ForeignKey("dbo.Scaffoldings", t => t.ScaffoldingId, cascadeDelete: false)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrderId, cascadeDelete: false)
                .Index(t => t.EquipmentId)
                .Index(t => t.WorkOrderId)
                .Index(t => t.ScaffoldingId)
                .Index(t => new { t.OutputMaterial_EquipmentId, t.OutputMaterial_WorkOrderId });
            
            CreateTable(
                "dbo.OutputMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        WorkOrderId = c.Int(nullable: false),
                        ScaffoldingId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Date = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.EquipmentId, t.WorkOrderId })
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrderId, cascadeDelete: false)
                .ForeignKey("dbo.Scaffoldings", t => t.ScaffoldingId, cascadeDelete: false)
                .Index(t => t.EquipmentId)
                .Index(t => t.WorkOrderId)
                .Index(t => t.ScaffoldingId);
            
            CreateTable(
                "dbo.inputMaterialHasEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InputMaterialId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DefectiveNumber = c.Int(nullable: false),
                        MissingNumber = c.Int(nullable: false),
                        HealthyNumber = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                        InputMaterial_EquipmentId = c.Int(),
                        InputMaterial_WorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .ForeignKey("dbo.InputMaterials", t => new { t.InputMaterial_EquipmentId, t.InputMaterial_WorkOrderId })
                .Index(t => t.EquipmentId)
                .Index(t => new { t.InputMaterial_EquipmentId, t.InputMaterial_WorkOrderId });
            
            CreateTable(
                "dbo.outputMaterialHasEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OutputMaterialId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                        OutputMaterial_EquipmentId = c.Int(),
                        OutputMaterial_WorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .ForeignKey("dbo.OutputMaterials", t => new { t.OutputMaterial_EquipmentId, t.OutputMaterial_WorkOrderId })
                .Index(t => t.EquipmentId)
                .Index(t => new { t.OutputMaterial_EquipmentId, t.OutputMaterial_WorkOrderId });
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureBinary = c.Binary(),
                        MimeType = c.String(),
                        SeoFilename = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        AltAttribute = c.String(),
                        TitleAttribute = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScaffoldHasEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        ScaffoldingId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ActionUserId = c.String(),
                        LastActionUserId = c.String(),
                        IsDeletede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .ForeignKey("dbo.Scaffoldings", t => t.ScaffoldingId, cascadeDelete: false)
                .Index(t => t.EquipmentId)
                .Index(t => t.ScaffoldingId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false),
                        StockReady = c.Int(nullable: false),
                        TotalStock = c.Int(nullable: false),
                        DefectiveNumberStock = c.Int(nullable: false),
                        MissingNumberStock = c.Int(nullable: false),
                        MainStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            CreateTable(
                "dbo.ApplicationRoleApplicationUsers",
                c => new
                    {
                        ApplicationRole_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationRole_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .Index(t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PermissionApplicationRoles",
                c => new
                    {
                        Permission_Id = c.Int(nullable: false),
                        ApplicationRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Permission_Id, t.ApplicationRole_Id })
                .ForeignKey("dbo.Permissions", t => t.Permission_Id, cascadeDelete: false)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id, cascadeDelete: false)
                .Index(t => t.Permission_Id)
                .Index(t => t.ApplicationRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScaffoldHasEquipments", "ScaffoldingId", "dbo.Scaffoldings");
            DropForeignKey("dbo.ScaffoldHasEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.outputMaterialHasEquipments", new[] { "OutputMaterial_EquipmentId", "OutputMaterial_WorkOrderId" }, "dbo.OutputMaterials");
            DropForeignKey("dbo.outputMaterialHasEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.inputMaterialHasEquipments", new[] { "InputMaterial_EquipmentId", "InputMaterial_WorkOrderId" }, "dbo.InputMaterials");
            DropForeignKey("dbo.inputMaterialHasEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.InputMaterials", "WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.InputMaterials", "ScaffoldingId", "dbo.Scaffoldings");
            DropForeignKey("dbo.InputMaterials", new[] { "OutputMaterial_EquipmentId", "OutputMaterial_WorkOrderId" }, "dbo.OutputMaterials");
            DropForeignKey("dbo.OutputMaterials", "ScaffoldingId", "dbo.Scaffoldings");
            DropForeignKey("dbo.OutputMaterials", "WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.OutputMaterials", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.InputMaterials", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.BuyMaterials", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.EquipmentHasProperties", "UnitId", "dbo.Units");
            DropForeignKey("dbo.EquipmentHasProperties", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.EquipmentHasProperties", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.BuyMaterials", "CompanyStoreRoomId", "dbo.CompanyStoreRooms");
            DropForeignKey("dbo.AssignedWorkorders", "WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.AssignedWorkorderDetails", "AssignedWorkorder_Id", "dbo.AssignedWorkorders");
            DropForeignKey("dbo.WorkorderAssignedUsers", "PersonnelCode", "dbo.Personnels");
            DropForeignKey("dbo.WorkorderAssignedUsers", "AssignedWorkorderDetailId", "dbo.AssignedWorkorderDetails");
            DropForeignKey("dbo.AssignedWorkorderDetails", "WorkorderId", "dbo.WorkOrders");
            DropForeignKey("dbo.WorkOrders", "UnitId", "dbo.Companies");
            DropForeignKey("dbo.WorkOrders", "SectionId", "dbo.Companies");
            DropForeignKey("dbo.WorkOrders", "ScaffoldingId", "dbo.Scaffoldings");
            DropForeignKey("dbo.WorkOrders", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AssignedTaskUsers", "AssignedTaskId", "dbo.AssignedTasks");
            DropForeignKey("dbo.AssignedTaskUsers", "PersonnelCode", "dbo.Personnels");
            DropForeignKey("dbo.AssignedTasks", "RoutineId", "dbo.Routines");
            DropForeignKey("dbo.Answers", "ScaffoldingId", "dbo.Scaffoldings");
            DropForeignKey("dbo.Scaffoldings", "ScaffoldTypeId", "dbo.ScaffoldTypes");
            DropForeignKey("dbo.Scaffoldings", "PersonnelCode", "dbo.Personnels");
            DropForeignKey("dbo.WorkingGroupPersonnels", "WorkgroupId", "dbo.Workgroups");
            DropForeignKey("dbo.WorkingGroupPersonnels", "PersonnelCode", "dbo.Personnels");
            DropForeignKey("dbo.Personnels", "PositionTypeId", "dbo.PositionTypes");
            DropForeignKey("dbo.AspNetUsers", "PositionType_Id", "dbo.PositionTypes");
            DropForeignKey("dbo.Personnels", "EmployeeTypeId", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Personnels", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "ParentID", "dbo.Companies");
            DropForeignKey("dbo.Attendances", "PersonnelCode", "dbo.Personnels");
            DropForeignKey("dbo.Scaffoldings", "EarthId", "dbo.Earths");
            DropForeignKey("dbo.Scaffoldings", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.AllowedRoles", "IdentityRoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AllowedRoles", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PermissionApplicationRoles", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.PermissionApplicationRoles", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.ApplicationRoleApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationRoleApplicationUsers", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.PermissionApplicationRoles", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.PermissionApplicationRoles", new[] { "Permission_Id" });
            DropIndex("dbo.ApplicationRoleApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationRoleApplicationUsers", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.ScaffoldHasEquipments", new[] { "ScaffoldingId" });
            DropIndex("dbo.ScaffoldHasEquipments", new[] { "EquipmentId" });
            DropIndex("dbo.outputMaterialHasEquipments", new[] { "OutputMaterial_EquipmentId", "OutputMaterial_WorkOrderId" });
            DropIndex("dbo.outputMaterialHasEquipments", new[] { "EquipmentId" });
            DropIndex("dbo.inputMaterialHasEquipments", new[] { "InputMaterial_EquipmentId", "InputMaterial_WorkOrderId" });
            DropIndex("dbo.inputMaterialHasEquipments", new[] { "EquipmentId" });
            DropIndex("dbo.OutputMaterials", new[] { "ScaffoldingId" });
            DropIndex("dbo.OutputMaterials", new[] { "WorkOrderId" });
            DropIndex("dbo.OutputMaterials", new[] { "EquipmentId" });
            DropIndex("dbo.InputMaterials", new[] { "OutputMaterial_EquipmentId", "OutputMaterial_WorkOrderId" });
            DropIndex("dbo.InputMaterials", new[] { "ScaffoldingId" });
            DropIndex("dbo.InputMaterials", new[] { "WorkOrderId" });
            DropIndex("dbo.InputMaterials", new[] { "EquipmentId" });
            DropIndex("dbo.EquipmentHasProperties", new[] { "UnitId" });
            DropIndex("dbo.EquipmentHasProperties", new[] { "PropertyId" });
            DropIndex("dbo.EquipmentHasProperties", new[] { "EquipmentId" });
            DropIndex("dbo.BuyMaterials", new[] { "CompanyStoreRoomId" });
            DropIndex("dbo.BuyMaterials", new[] { "EquipmentId" });
            DropIndex("dbo.WorkorderAssignedUsers", new[] { "AssignedWorkorderDetailId" });
            DropIndex("dbo.WorkorderAssignedUsers", new[] { "PersonnelCode" });
            DropIndex("dbo.WorkOrders", new[] { "UnitId" });
            DropIndex("dbo.WorkOrders", new[] { "SectionId" });
            DropIndex("dbo.WorkOrders", new[] { "CompanyId" });
            DropIndex("dbo.WorkOrders", new[] { "ScaffoldingId" });
            DropIndex("dbo.AssignedWorkorderDetails", new[] { "AssignedWorkorder_Id" });
            DropIndex("dbo.AssignedWorkorderDetails", new[] { "WorkorderId" });
            DropIndex("dbo.AssignedWorkorders", new[] { "WorkOrderId" });
            DropIndex("dbo.AssignedTaskUsers", new[] { "AssignedTaskId" });
            DropIndex("dbo.AssignedTaskUsers", new[] { "PersonnelCode" });
            DropIndex("dbo.AssignedTasks", new[] { "RoutineId" });
            DropIndex("dbo.WorkingGroupPersonnels", new[] { "PersonnelCode" });
            DropIndex("dbo.WorkingGroupPersonnels", new[] { "WorkgroupId" });
            DropIndex("dbo.PositionTypes", new[] { "Title" });
            DropIndex("dbo.Companies", new[] { "ParentID" });
            DropIndex("dbo.Attendances", new[] { "PersonnelCode" });
            DropIndex("dbo.Personnels", new[] { "CompanyId" });
            DropIndex("dbo.Personnels", new[] { "EmployeeTypeId" });
            DropIndex("dbo.Personnels", new[] { "PositionTypeId" });
            DropIndex("dbo.Scaffoldings", new[] { "PersonnelCode" });
            DropIndex("dbo.Scaffoldings", new[] { "ScaffoldTypeId" });
            DropIndex("dbo.Scaffoldings", new[] { "EarthId" });
            DropIndex("dbo.Scaffoldings", new[] { "BuildingId" });
            DropIndex("dbo.Scaffoldings", new[] { "Title" });
            DropIndex("dbo.Answers", new[] { "ScaffoldingId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "PositionType_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AllowedRoles", new[] { "IdentityRoleId" });
            DropIndex("dbo.AllowedRoles", new[] { "ApplicationUserId" });
            DropTable("dbo.PermissionApplicationRoles");
            DropTable("dbo.ApplicationRoleApplicationUsers");
            DropTable("dbo.Stocks");
            DropTable("dbo.Settings");
            DropTable("dbo.ScaffoldHasEquipments");
            DropTable("dbo.Pictures");
            DropTable("dbo.outputMaterialHasEquipments");
            DropTable("dbo.inputMaterialHasEquipments");
            DropTable("dbo.OutputMaterials");
            DropTable("dbo.InputMaterials");
            DropTable("dbo.Units");
            DropTable("dbo.Properties");
            DropTable("dbo.EquipmentHasProperties");
            DropTable("dbo.Equipments");
            DropTable("dbo.CompanyStoreRooms");
            DropTable("dbo.BuyMaterials");
            DropTable("dbo.WorkorderAssignedUsers");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.AssignedWorkorderDetails");
            DropTable("dbo.AssignedWorkorders");
            DropTable("dbo.AssignedTaskUsers");
            DropTable("dbo.Routines");
            DropTable("dbo.AssignedTasks");
            DropTable("dbo.ScaffoldTypes");
            DropTable("dbo.Workgroups");
            DropTable("dbo.WorkingGroupPersonnels");
            DropTable("dbo.PositionTypes");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.Attendances");
            DropTable("dbo.Personnels");
            DropTable("dbo.Earths");
            DropTable("dbo.Buildings");
            DropTable("dbo.Scaffoldings");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Permissions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AllowedRoles");
        }
    }
}
