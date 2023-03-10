USE [Coliber]
GO
ALTER FUNCTION [dbo].[LogInToDb]
(
	@p_username varchar(50),
	@p_password varchar(42)
)
RETURNS int
AS
BEGIN
	RETURN ISNULL((SELECT id FROM login WHERE nazwa = @p_username AND haslo = CONVERT(VARCHAR(42), HASHBYTES('MD5', @p_password), 2) AND deleted = 0), -2);
END
GO

alter table login alter column nazwa varchar(50) not null
GO

/*

-- aby nie pokazywał się użytkownikowi ekran logowania
INSERT INTO dbo.login (nazwa,haslo,prawa,baza_start,imie,nazwisko,deleted)
     VALUES ('DOMENA\USER','D41D8CD98F00B204E9800998ECF8427E','',1,'NAZWA','',0)
GO

*/