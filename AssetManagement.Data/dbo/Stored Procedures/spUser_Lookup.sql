﻿CREATE PROCEDURE [dbo].[spUser_Lookup]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT IDENT_CURRENT('dbo.Users');
END