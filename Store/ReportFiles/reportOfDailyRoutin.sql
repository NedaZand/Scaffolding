USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[reportOfDailyRoutin]    Script Date: 7/31/2020 12:03:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[reportOfDailyRoutin]
    
    	@workorderId INT = null,
	    @date DATETIME = null
AS
   

     select p.UserNameFmaily, result.PersonnelCode,result.Date,r.Title,r.Id,et.Title as employeeType,pt.Title as positionType  from dbo.[Routines] as r Inner Join( select a.RoutineId,a.Date,u.AssignedTaskId,u.PersonnelCode from
  [dbo].[AssignedTasks] a
  inner join  [dbo].[AssignedTaskUsers] u on a.Id=u.AssignedTaskId where (@workorderId is   null or a.RoutineId =@workorderId)
  and (@date is    null or a.Date = @date) 
  ) as result ON r.Id=result.RoutineId inner join
    [dbo].[Personnels] p ON  p.PersonnelCode=result.PersonnelCode   left join [dbo].[PositionTypes] pt ON  pt.Id=p.PositionTypeId   left join  [dbo].[EmployeeTypes] et ON  p.EmployeeTypeId=et.Id
 --exec [reportOfDailyTask] @workorderId=6
GO


