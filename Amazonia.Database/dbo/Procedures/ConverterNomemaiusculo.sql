CREATE PROCEDURE [dbo].[ConverterNomemaiusculo]
	@param1 varchar(50)
AS
	SELECT UPPER(@param1)
RETURN 0
