CREATE PROCEDURE [dbo].[CheckForUser]
	@username nvarchar(250),
	@password nvarchar(250)
AS
BEGIN
	SET QUOTED_IDENTIFIER ON
	SET ANSI_NULLS ON
	SET NOCOUNT ON;
	SELECT username
	FROM Users
	WHERE username = @username 
	AND password = @password
END