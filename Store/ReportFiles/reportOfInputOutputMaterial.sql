USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfPersonnelFunction]    Script Date: 2/22/2019 12:04:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfInputOutputMaterial]

	@workorderId INT = null,
	@equipmentId INT = null
	
AS
BEGIN

select equipment.Title as equipmentTitle,equipment.EquipmentType, output.*,ISNULL(input.Count,0) as inputCount,input.Date as inputDate,ISNULL(input.DefectiveNumber,0) as DefectiveNumber,ISNULL(input.HealthyNumber,0) as HealthyNumber,ISNULL(input.MissingNumber,0) as MissingNumber,workorder.Title as workorderTitle,workorder.Date as workorderDate ,workorder.RealArea,workorder.Status,workorder.Tag,workorder.TypeId,scaffolding.confirmed,scaffolding.BuildingId,scaffolding.Date,scaffolding.Title as scaffoldingTitle ,company.Title as companyTitle from (SELECT output.Count,output.Date as outputDate ,output.EquipmentId,output.Id,output.ScaffoldingId,output.WorkOrderId
FROM  [dbo].[OutputMaterials] output

where (@workorderId is   null or output.WorkOrderId =@workorderId)
and (@equipmentId is    null or  output.EquipmentId =@equipmentId) 

) as output

inner JOIN [dbo].[WorkOrders] workorder ON output.WorkOrderId = workorder.Id 
Inner JOIN [dbo].[Equipments] equipment ON equipment.Id = output.EquipmentId
left JOIN [dbo].[InputMaterials] input ON output.Id = input.OutputMaterialId 
left JOIN  [dbo].[Scaffoldings] scaffolding ON scaffolding.Id = workorder.ScaffoldingId
left JOIN  [dbo].[Companies] company ON company.Id = workorder.CompanyId
END


--exec [reportOfInputOutputMaterial]