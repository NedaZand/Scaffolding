USE [StoreDB]
GO
/****** Object:  StoredProcedure [dbo].[reportOfWorkOrder]    Script Date: 12/25/2018 6:17:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[reportOfWorkOrder]
    
    @type INT = null,
	@priority INT = null,
	@companyId INT = null,
	@description nvarchar(max) = null,
	@title nvarchar(max) = null,
	@tag nvarchar(max) = null,
	@status INT = null,
	 @date DATETIME = null,
    @toDate DATETIME = null,
	 @expireDate DATETIME = null,
    @toExpireDate DATETIME = null
AS
  
 SELECT w.*,c.Title as companyName
FROM [dbo].[WorkOrders] w
Left JOIN [dbo].[Companies] c ON w.CompanyId = c.Id
WHERE  (@priority is   null or w.Priority =@priority) 
and (@type is   null or w.TypeId =@type)
and  (@status is   null or w.Status = @status) 
and (@title is null or w.Title=@title)
and (@tag is null or w.Tag=@tag)
and (@date is    null or w.Date>= @date) 
and (@toDate is    null or w.Date<= @toDate) 
and (@expireDate is    null or w.ExpireDate>= @expireDate) 
and (@toExpireDate is    null or w.ExpireDate<= @toExpireDate) 
and (@companyId is    null or w.CompanyId = @companyId) 
--exec [dbo].[reportOfWorkOrder] @date=N'2018-10-28 00:00:00.000',@toDate=N'2018-11-06 00:00:00.000',

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
