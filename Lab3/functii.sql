USE [Dealership_Auto_Final]
GO

--creare functii


CREATE FUNCTION checkFormatNumber(@number varchar(MAX))
RETURNS BIT
AS
BEGIN
	IF @number IS NULL
		RETURN 0
	IF LTRIM(@number) = ''
		return 0

	declare @lungime int
	set @lungime = LEN(@number)

	declare @contor int
	set @contor = 1

	declare @substrin varchar(MAX)
	declare @car char

	while @contor <= @lungime
	begin
		select @car = SUBSTRING(@number, @contor, 1)
		if ISNUMERIC(@car) != 1
		begin
			return 0
		end

		set @contor = @contor + 1
	end
	return 1

END


GO
PRINT dbo.checkFormatNumber('23 A')

GO
CREATE FUNCTION checkFormatCNP( @cnp varchar(100))
RETURNS BIT
AS 
BEGIN
	if dbo.checkFormatNumber(@cnp) = 0
		return 0
	if len(@cnp) != 13
		return 0
	return 1
END

GO
PRINT dbo.checkFormatCNP('6030321090030')


GO
CREATE or ALTER FUNCTION checkFormatName(@name varchar(50))
RETURNS BIT
AS
BEGIN
	IF @name IS NULL
		RETURN 0
	IF LTRIM(@name) = ''
		return 0
	IF LEN(@name) < 3 
		RETURN 0

	declare @lungime int
	set @lungime = LEN(@name)

	declare @contor int
	set @contor = 1

	declare @substrin varchar(MAX)
	declare @car char

	while @contor <= @lungime
	begin
		if not SUBSTRING(@name, @contor, 1) like '%[a-zA-Z ]'
			return 0

		set @contor = @contor + 1
	end

	RETURN 1

END

GO
PRINT dbo.checkFormatName('Ana Varga')

GO
CREATE FUNCTION checkFormatSerieSasiu(@serie_sasiu varchar(50))
RETURNS BIT
AS
BEGIN
	IF @serie_sasiu IS NULL
		RETURN 1
	IF LTRIM(@serie_sasiu) = ''
		return 0
	IF LEN(@serie_sasiu) != 17
		RETURN 0

	declare @lungime int
	set @lungime = 17

	declare @contor int
	set @contor = 1

	declare @substrin varchar(MAX)
	declare @car char

	while @contor <= @lungime
	begin
		if not SUBSTRING(@serie_sasiu, @contor, 1) like '%[A-Z0-9]'
			return 0
		set @contor = @contor + 1
	end
	RETURN 1
END

GO
DROP FUNCTION DBO.checkFormatSerieSasiu
GO
PRINT dbo.checkFormatSerieSasiu('ZARL1R207YYWT5312')

