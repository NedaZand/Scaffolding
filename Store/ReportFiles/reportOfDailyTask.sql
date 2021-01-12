USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[reportOfDailyTask]    Script Date: 7/31/2020 12:03:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[reportOfDailyTask]
    
    	@workorderId INT = null,
	    @date DATETIME = null
AS
   select p.UserNameFmaily, result.PersonnelCode,result.Date,w.Title,w.Id, c.Title as companyName,u.Title as unitName,s.Title as sectionName,et.Title as employeeType,pt.Title as positionType  from [dbo].[WorkOrders] as w Inner Join( select ad.WorkorderId,ad.Date,u.AssignedWorkorderDetailId,u.PersonnelCode from
  [dbo].[AssignedWorkorderDetails] ad
  inner join [dbo].[WorkorderAssignedUsers]  u on ad.Id=u.AssignedWorkorderDetailId where (@workorderId is null or ad.WorkOrderId =@workorderId)
  and (@date is    null or ad.Date = @date) 
  ) as result ON w.Id=result.WorkorderId inner join [dbo].[Companies] c ON  c.Id=w.CompanyId left join [dbo].[Companies] s ON s.Id=w.SectionId left join [dbo].[Companies] u ON u.Id=w.UnitId
  inner join [dbo].[Personnels] p ON  p.PersonnelCode=result.PersonnelCode   left join [dbo].[PositionTypes] pt ON  pt.Id=p.PositionTypeId   left join  [dbo].[EmployeeTypes] et ON  p.EmployeeTypeId=et.Id

 --exec [reportOfDailyTask] @workorderId=6
GO


