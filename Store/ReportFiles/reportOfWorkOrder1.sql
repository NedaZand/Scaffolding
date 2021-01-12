USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfWorkOrder1]    Script Date: 12/28/2018 6:47:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[reportOfWorkOrder1]
    
     @workorderId INT = null,
     @date DATETIME = null,
        @toDate DATETIME = null
AS
   select  *,c.Title as companyName,et.Title as employeeType,pt.Title as positionType  from [dbo].[WorkOrders] as w Inner Join( select aw.EndDate,aw.StartDate,aw.WorkOrderId,aw.RealArea,ad.AssignedWorkorder_Id,ad.Date,ad.TotalArea,u.Area,u.AssignedWorkorderDetailId,u.PersonnelCode from
  [dbo].[AssignedWorkorders] aw inner join [dbo].[AssignedWorkorderDetails] ad on aw.Id=ad.AssignedWorkorder_Id 
  inner join [dbo].[WorkorderAssignedUsers]  u on ad.Id=u.AssignedWorkorderDetailId where (@workorderId is   null or aw.WorkOrderId =@workorderId)
  and (@date is    null or ad.Date>= @date) 
  and (@toDate is    null or ad.Date<= @toDate) 
  ) as result ON w.Id=result.WorkorderId inner join [dbo].[Companies] c ON  c.Id=w.CompanyId
  inner join [dbo].[Personnels] p ON  p.PersonnelCode=result.PersonnelCode   inner join [dbo].[PositionTypes] pt ON  pt.Id=p.PositionTypeId   inner join  [dbo].[EmployeeTypes] et ON  p.EmployeeTypeId=et.Id
 exec [reportOfWorkOrder1] @workorderId=6