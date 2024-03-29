USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfRoutin]    Script Date: 12/25/2018 5:27:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfRoutin]
    
   
	@routinId INT = null,
	 @date DATETIME = null,
    @toDate DATETIME = null,
	  @personnelCode INT = null
	
AS
 select * from  [dbo].[Routines] r  
Inner join ( SELECT t.*,p.UserNameFmaily,u.AssignedTaskId,u.PersonnelCode
FROM [dbo].[AssignedTasks] t
INNER JOIN [dbo].[AssignedTaskUsers] u ON t.Id = u.AssignedTaskId INNER JOIN [dbo].[Personnels] p ON u.PersonnelCode = p.PersonnelCode 
WHERE   (@personnelCode is   null or u.PersonnelCode =@personnelCode) 
 and (@routinId is   null or t.RoutineId =@routinId) 
and (@date is    null or t.Date>= @date) 
and (@toDate is    null or t.Date<= @toDate) ) as result ON r.Id = result.RoutineId 
--WHERE   (@personnelCode is   null or result.PersonnelCode =@personnelCode) 

--exec [dbo].[reportOfRoutin] @date=N'2018-10-28 00:00:00.000',@toDate=N'2018-11-06 00:00:00.000',

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
