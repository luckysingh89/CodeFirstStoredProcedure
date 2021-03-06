/****** Object:  StoredProcedure [dbo].[Sp_GetPeople]    Script Date: 21-Aug-2015 3:18:20 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_GetPeople]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_GetPeople]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetPeople]    Script Date: 21-Aug-2015 3:18:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_GetPeople]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Sp_GetPeople] AS' 
END
GO
-- =============================================
-- Author:		Manpreet Singh Sahota	
-- Create date: 21-Aug-2015
-- Description:	Gets all the data from people table.
-- =============================================
ALTER PROCEDURE [dbo].[Sp_GetPeople] 
@MatchCase Varchar(2000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	

    -- Insert statements for procedure here
	SELECT * from tbl_People where @MatchCase is null or Name like '%'+@MatchCase+'%';
END

GO
