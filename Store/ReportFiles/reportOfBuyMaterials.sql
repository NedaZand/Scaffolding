USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfInputOutputWorkOrder]    Script Date: 1/12/2019 6:23:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfBuyMaterials]
    
	@equipmentId INT =null,
	@companyStoreRoomId INT=null,
	@fromDate DateTime=null,
	@toDate DateTime=null
AS

 SELECT buy.CompanyStoreRoomId,buy.Count,buy.Date,buy.EquipmentId,buy.Id,buy.Price,buy.UnitId,equipment.Title as equipmentTitle,equipment.EquipmentType ,company.Title as companyTitle,company.Phone,unit.Title as unitTitle  from (SELECT buy.CompanyStoreRoomId,buy.Count,buy.Date,buy.EquipmentId,buy.Id,buy.Price,buy.UnitId
FROM [dbo].[BuyMaterials] buy


where (@equipmentId is   null or buy.EquipmentId =@equipmentId)
and (@companyStoreRoomId is   null or buy.CompanyStoreRoomId =@companyStoreRoomId)
and (@fromDate is    null or  buy.Date>= @fromDate) 
and  (@toDate is   null or  buy.Date <= @toDate)

) as buy
left JOIN  [dbo].[Equipments] equipment ON buy.EquipmentId = equipment.Id
left JOIN  [dbo].[CompanyStoreRooms] company ON buy.CompanyStoreRoomId = company.Id
left JOIN  [dbo].[Units] unit ON buy.UnitId = unit.Id
  
-- SELECT buy.CompanyStoreRoomId,buy.Count,buy.Date,buy.EquipmentId,buy.Id,buy.Price,buy.Total,buy.UnitId,equipment.Title as equipmentTitle,equipment.EquipmentType ,company.Title as companyTitle,company.Phone,unit.Title as unitTitle  from (	SELECT buy.*,sum(buy.Price)  OVER (PARTITION by buy.EquipmentId) as Total
--FROM [dbo].[BuyMaterials] buy


--where (@equipmentId is   null or buy.EquipmentId =@equipmentId)
--and (@companyStoreRoomId is   null or buy.CompanyStoreRoomId =@companyStoreRoomId)
--and (@fromDate is    null or  buy.Date>= @fromDate) 
--and  (@toDate is   null or  buy.Date <= @toDate)

--) as buy
--left JOIN  [dbo].[Equipments] equipment ON buy.EquipmentId = equipment.Id
--left JOIN  [dbo].[CompanyStoreRooms] company ON buy.CompanyStoreRoomId = company.Id
--left JOIN  [dbo].[Units] unit ON buy.UnitId = unit.Id



--exec [dbo].[reportOfBuyMaterials]


