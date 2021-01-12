USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfPersonnelAttendance]    Script Date: 12/25/2018 6:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfPersonnelAttendance]
    
    @personnelCode INT = null,
	@status INT = null,
	@fromDate DATETIME = null,
	@toDate DATETIME = null
AS
  BEGIN
 SELECT p.UserNameFmaily, a.*
FROM [dbo].[Personnels] p
Inner JOIN [dbo].[Attendances] a ON a.PersonnelCode = p.PersonnelCode 
WHERE  (@personnelCode is   null or a.PersonnelCode =@personnelCode) 
 and (@status is   null or a.PresenceStatus =@status)
 and (@fromDate is    null or  a.Date>= @fromDate) 
 and  (@toDate is   null or  a.Date <= @toDate)
 
--exec [dbo].[reportOfPersonnelAttendance] @personnelCode=1000002
End