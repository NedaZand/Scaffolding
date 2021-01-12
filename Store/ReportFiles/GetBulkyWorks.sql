USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[GetBulkyWorks]    Script Date: 7/31/2020 12:02:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBulkyWorks]
	@date DateTime = null
AS
BEGIN
	SELECT SUM(NewData.EmployeCount) AS EmployeCount FROM
(
	select Count(EmployeeTypes.Title) AS EmployeCount from AssignedWorkorderDetails Inner join WorkOrders ON AssignedWorkorderDetails.WorkorderId = WorkOrders.Id 
	inner join WorkorderAssignedUsers on WorkorderAssignedUsers.WorkorderId = WorkOrders.Id
	inner join Personnels on WorkorderAssignedUsers.PersonnelCode = Personnels.PersonnelCode
	inner join EmployeeTypes on Personnels.EmployeeTypeId = EmployeeTypes.Id
	WHERE (AssignedWorkorderDetails.Date = @date OR @date IS NULL) AND (dbo.EmployeeTypes.Id = 4) 

	UNION ALL
	
	select Count(EmployeeTypes.Title) AS EmployeCount from AssignedTaskUsers
	inner join Personnels on AssignedTaskUsers.PersonnelCode = Personnels.PersonnelCode
	inner join EmployeeTypes on AssignedTaskUsers.EmployeeTypeId = EmployeeTypes.Id
	inner join AssignedTasks on AssignedTasks.Id = AssignedTaskUsers.AssignedTaskId
	WHERE (AssignedTasks.Date = @date OR @date IS NULL) AND (dbo.EmployeeTypes.Id = 4) 
) AS NewData
END
GO


