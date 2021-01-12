USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfInputOutputWorkOrder]    Script Date: 1/12/2019 6:23:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfMaterialUsedByCompanies]
    
	@companyId INT =null,
	@fromDate DateTime=null,
	@toDate DateTime=null
AS
  
 SELECT comp.Address,comp.Title,comp.Id,result.*
FROM   [dbo].[Companies] as comp inner join (SELECT out.*, eq.Title,eq.MinimumInventory from (SELECT out.Count,out.Date,out.EquipmentId,out.Id From [dbo].[OutputMaterials] out WHERE  (@companyId is   null or out.CompanyId = @companyId)   and (@fromDate is    null or out.Date>= @fromDate) 
  and (@toDate is    null or out.Date<= @toDate) ) as out Inner JOIN  [dbo].[Equipments] eq ON eq.Id= out.EquipmentId ) as result
ON result.CompanyId= comp.Id 

--exec [dbo].[reportOfMaterialUsedByCompanies]


