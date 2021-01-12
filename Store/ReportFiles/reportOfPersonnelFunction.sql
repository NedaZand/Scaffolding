USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfPersonnelFunction]    Script Date: 12/28/2018 1:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[reportOfPersonnelFunction]
	 @fromDate DATETIME = null,
	@toDate DATETIME = null,
	@personnelCode INT = null
AS
BEGIN
--if(@personnelCode IS NULL)
BEGIN
select p.*,ISNULL(i.Total,0)  as Total,pts.Title as employeeType,pd.Title as positionType,pc.Title as company  from (	SELECT i.PersonnelCode,sum(i.Area) as Total
FROM [dbo].[WorkorderAssignedUsers] i

 INNER JOIN [dbo].[AssignedWorkorderDetails] ip ON i.AssignedWorkorderDetailId = ip.Id


where (@personnelCode is   null or i.PersonnelCode =@personnelCode)
and (@fromDate is    null or  ip.Date>= @fromDate) 
and  (@toDate is   null or  ip.Date <= @toDate)

GROUP BY i.PersonnelCode ) as i
right JOIN [dbo].[Personnels] p ON i.PersonnelCode = p.PersonnelCode   left JOIN [dbo].[EmployeeTypes] pts ON pts.Id = p.EmployeeTypeId 
left JOIN [dbo].[PositionTypes] pd ON p.PositionTypeId = pd.Id
left JOIN [dbo].[Companies] pc ON p.CompanyId = pc.Id
where (@personnelCode is   null or p.PersonnelCode =@personnelCode)
END

--ELSE 
--BEGIN
--select p.PersonnelCode ,i.Total from (	SELECT i.PersonnelCode,sum(i.Area) as Total
--FROM [dbo].[WorkorderAssignedUsers] i

-- INNER JOIN [dbo].[AssignedWorkorderDetails] ip ON i.AssignedWorkorderDetailId = ip.Id


--where (@personnelCode is   null or i.PersonnelCode =@personnelCode)
--and (@fromDate is    null or  ip.Date>= @fromDate) 
--and  (@toDate is   null or  ip.Date <= @toDate)

--GROUP BY i.PersonnelCode ) as i
--Inner JOIN [dbo].[Personnels] p ON i.PersonnelCode = p.PersonnelCode  
--where (@personnelCode is   null or i.PersonnelCode =@personnelCode)

--END
END
--exec [reportOfPersonnelFunction]