USE [Dealership_Auto_Final]
GO

DROP TABLE IF EXISTS LogTable 
CREATE TABLE LogTable(
	Lid INT IDENTITY PRIMARY KEY,
	TypeOperation VARCHAR(50),
	TableOperation VARCHAR(50),
	ExecutionDate DATETIME
);

GO
CREATE OR ALTER PROCEDURE addAngajat (@angajat_nume VARCHAR(30),@angajat_cnp VARCHAR(14),@angajat_codF INT)
AS
	SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM Angajat WHERE cnp_a = @angajat_cnp)
	BEGIN 
		RAISERROR('Angajatul exista deja!',14,1)
	END

	if not exists (SELECT * FROM Funcție WHERE cod_f = @angajat_codF) 
	begin
		RAISERROR('Cod functie nu exista!',14,1)
	end

	if dbo.checkFormatName(@angajat_nume) = 0
	begin
		RAISERROR('Nume invalid!',14,1)
	end

	if dbo.checkFormatCNP(@angajat_cnp) = 0
	begin
		RAISERROR('CNP invalid!',14,1)
	end

	INSERT INTO Angajat(nume_a,cnp_a,cod_f) VALUES (@angajat_nume,@angajat_cnp,@angajat_codF)
	INSERT INTO LogTable VALUES('add','angajat',GETDATE())
	
GO

CREATE OR ALTER PROCEDURE addMasina (@masina_serie_sasiu VARCHAR(30),@masina_codMM INT)
AS
	SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM Mașină WHERE serie_sasiu_m = @masina_serie_sasiu)
	BEGIN 
		RAISERROR('Masina exista deja!',14,1)
	END

	if not exists (SELECT * FROM Model WHERE cod_mm = @masina_codMM) 
	begin
		RAISERROR('Cod model nu exista!',14,1)
	end

	if dbo.checkFormatSerieSasiu(@masina_serie_sasiu) = 0
	begin
		RAISERROR('Serie sasiu invalida!',14,1)
	end

	INSERT INTO Mașină(serie_sasiu_m,cod_mm) VALUES (@masina_serie_sasiu,@masina_codMM)
	INSERT INTO LogTable VALUES('add','masina',GETDATE())

GO

CREATE OR ALTER PROCEDURE addAccesMasina (@angajat_id INT, @masina_id INT)
AS
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT * FROM Angajat WHERE cod_a=@angajat_id)
	BEGIN
			RAISERROR('Angajat id invalid!', 14, 1)
	END
	
	IF NOT EXISTS (SELECT * FROM Mașină WHERE cod_m=@masina_id)
	BEGIN
		RAISERROR('Masina id invalid!', 14, 1)
	END

	IF EXISTS (SELECT * FROM Acces_masina WHERE cod_m=@masina_id AND cod_a=@angajat_id)
	BEGIN 
		RAISERROR('Asocierea exista deja!',14,1)
	END

	INSERT INTO Acces_masina(cod_a,cod_m) VALUES (@angajat_id,@masina_id);
	print 'Added!'
	--log the transaction
	INSERT INTO LogTable VALUES('add','acces_masina',GETDATE())


GO
CREATE OR ALTER PROCEDURE addRollbackScenario 
AS
	BEGIN TRAN
	BEGIN TRY 
		EXEC addAngajat "TEST","7893647589321",457 -- this will fail
		EXEC addMasina "ZARB4WT8953230313",2
		EXEC addAccesMasina 1,1
		COMMIT TRAN
	END TRY
	BEGIN CATCH -- if one transaction fails i.e. throws exception, rollback everything
		ROLLBACK TRAN
		RETURN
	END CATCH

GO
CREATE OR ALTER PROCEDURE addCommitScenario
AS
	BEGIN TRAN
	BEGIN TRY 
		EXEC addAngajat "TEST","7893647589321",1
		EXEC addMasina "ZARB4WT8953230313",2
		EXEC addAccesMasina 90,1
		COMMIT TRAN
	END TRY
	BEGIN CATCH 
		ROLLBACK TRAN
		RETURN
	END CATCH

GO
EXEC addRollbackScenario
EXEC addCommitScenario

select* from Angajat
select* from Mașină
select* from Model
select* from Acces_masina
select * from LogTable

delete from Angajat where cnp_a='7893647589321';
delete from Mașină where serie_sasiu_m='ZARB4WT8953230313';
delete from Acces_masina;



