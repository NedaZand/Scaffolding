USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfWorkOrder]    Script Date: 1/1/1980 1:31:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[reportOfStock]
    
	@equipmentId INT =null
AS
  
 SELECT e.EquipmentType,e.Weight,e.Title, ISNULL(result.StockReady, 0) as StockReady ,ISNULL(result.TotalStock,0) as TotalStock,ISNULL(result.MissingNumberStock,0) as MissingNumberStock,ISNULL(result.DefectiveNumberStock,0) as DefectiveNumberStock
FROM [dbo].[Equipments] e   left JOIN  (SELECT * From [dbo].[Stocks] s WHERE  (@equipmentId is   null or s.EquipmentId =@equipmentId) ) as result
ON result.EquipmentId = e.Id

--exec [dbo].[reportOfStock]


