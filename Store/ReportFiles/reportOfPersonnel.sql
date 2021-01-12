USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfPersonnel]    Script Date: 12/25/2018 6:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfPersonnel]
    
    @positionId INT = null,
	@employeeId INT = null,
	@companyId INT = null,
	@userNameFmaily nvarchar(100) = null,
	@nationalCode char(10) = null,
	@personnelCode INT = null,
	@maritalStatus INT = null,
	 @birthDate DATETIME = null,
    @toBirthDate DATETIME = null,
	 @dateEmployeement DATETIME = null,
    @toDateEmployeement DATETIME = null
AS
  
 SELECT pts.Title as employeeTypeTitle, pd.Title as positionTitle,ptc.*,pc.Title as companyName
FROM [dbo].[Personnels] ptc
Left JOIN [dbo].[EmployeeTypes] pts ON pts.Id = ptc.EmployeeTypeId 
Left JOIN [dbo].[PositionTypes] pd ON ptc.PositionTypeId = pd.Id
Left JOIN [dbo].[Companies] pc ON ptc.CompanyId = pc.Id
WHERE  (@positionId is   null or ptc.PositionTypeId =@positionId) 
and (@employeeId is   null or ptc.EmployeeTypeId =@employeeId)
and  (@userNameFmaily is   null or ptc.UserNameFmaily = @userNameFmaily) 
and (@personnelCode is null or ptc.PersonnelCode=@personnelCode)
and (@nationalCode is null or ptc.NationalCode=@nationalCode)
and (@maritalStatus is null or ptc.MaritalStatus=@maritalStatus)
and (@birthDate is    null or ptc.BirthDate>= @birthDate) 
and (@toBirthDate is    null or ptc.BirthDate<= @toBirthDate) 
and (@dateEmployeement is    null or ptc.DateEmployeement>= @dateEmployeement) 
and (@toDateEmployeement is    null or ptc.DateEmployeement<= @toDateEmployeement) 
and (@companyId is    null or ptc.CompanyId = @companyId) 
--exec [dbo].[reportOfPersonnel] @birthDate=N'2018-12-18 00:00:00.000'

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
