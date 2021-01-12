USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfWorkOrderFunction]    Script Date: 12/25/2018 6:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfWorkOrderFunction]
    
   
	@routinId INT = null
	
AS
 select r.*,c.Title,result.* from  [dbo].[WorkOrders] r  
Inner join ( SELECT t.EndDate,t.StartDate,t.WorkOrderId,u.AssignedWorkorderId,u.Date,u.TotalArea,u.RealArea,p.AssignedWorkorderDetailId,p.Area,p.PersonnelCode
FROM [dbo].[AssignedWorkorders] t
INNER JOIN [dbo].[AssignedWorkorderDetails] u ON t.Id = u.AssignedWorkorderId INNER JOIN [dbo].[WorkorderAssignedUsers] p ON u.Id = p.AssignedWorkorderDetailId 
WHERE  (@routinId is   null or t.WorkOrderId =@routinId) 
 ) as result ON r.Id = result.WorkOrderId INNER JOIN [dbo].[Personnels] ps on result.PersonnelCode=ps.PersonnelCode  INNER JOIN [dbo].[Companies] as c on r.CompanyId=c.Id
--WHERE   (@personnelCode is   null or result.PersonnelCode =@personnelCode) 

--exec [dbo].[reportOfWorkOrderFunction] @date=N'2018-10-28 00:00:00.000',@toDate=N'2018-11-06 00:00:00.000',

--if (@companyId  IS  NOT NULL )

-- WITH cte AS 
-- (
--  SELECT a.Id, a.parentId, a.Title
--  FROM [dbo].[Companies]  a
--  WHERE parentid = @companyId
--  UNION ALL
--  SELECT a.Id, a.parentid, a.Title
--  FROM [dbo].[Companies]  a JOIN cte c ON a.parentId = c.id
--   and c.id != @companyId

--  ) 
--  SELECT parentId, Id, Title
--  FROM cte
