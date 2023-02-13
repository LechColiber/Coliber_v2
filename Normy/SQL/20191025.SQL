update wypozyczalnia.dbo.w2_zasoby_t set deleted = 0 where deleted is null
GO

USE Coliber
GO

ALTER TRIGGER [dbo].[UpdateZasobyOnWypozyczalnia] ON [dbo].[zasoby] 
FOR INSERT, UPDATE 
AS
BEGIN

		-- nowe
		UPDATE cza_zas SET wypozycz = inserted.stan FROM inserted WHERE cza_zas.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;
		UPDATE sygnat  SET wypozycz = inserted.stan FROM inserted WHERE sygnat.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;	
		--UPDATE Normy_egzemplarz SET zas_stan_id = inserted.stan FROM inserted WHERE Normy_egzemplarz.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;	
		
		IF ((SELECT COUNT(*) FROM inserted WHERE zewn_akt = 0) > 0)
		BEGIN
			UPDATE wypozyczalnia_wzorzec_dentons.dbo.w2_zasoby_t
					SET kod_kresk = CAST(k_kreskowy AS VARCHAR),
						sygnatura = syg ,
						grupa_id = inserted.rodzaj_zas ,
						--opis = CASE WHEN LEN(LTRIM(autor)) = 0 THEN LTRIM(RTRIM(tytul)) ELSE LTRIM(RTRIM(autor)) + ': ' + LTRIM(RTRIM(tytul)) END,
						opis = LTRIM(RTRIM(tytul)) + ISNULL(' : ' + (SELECT LTRIM(RTRIM(t_dodatk)) FROM dbo.t_dodatk WHERE dbo.t_dodatk.kod = inserted.kod AND inserted.rodzaj_zas = 1), ''),
						zewn_akt = 1,
						numer_inw = inserted.numer_inw,
						uwagi = (SELECT LTRIM(RTRIM(uwagi_s)) AS uwagi_s FROM dbo.sygnat WHERE dbo.sygnat.id_zasob = inserted.id_zasob AND inserted.rodzaj_zas = 1),
						kod = inserted.kod
					FROM inserted
				WHERE CAST(obcy_id as int) = inserted.id_zasob AND inserted.zewn_akt = 0 ;
		END

		INSERT INTO wypozyczalnia_wzorzec_dentons..w2_zasoby_t(obcy_id, kod_kresk, sygnatura,kod, grupa_id, opis, zewn_akt, numer_inw, uwagi,deleted)        
		SELECT (CAST(id_zasob AS VARCHAR)), CAST(inserted.k_kreskowy as int), inserted.syg, inserted.kod, inserted.rodzaj_zas, 
		LTRIM(RTRIM(tytul)) + ISNULL(' : ' + (SELECT LTRIM(RTRIM(t_dodatk)) FROM dbo.t_dodatk WHERE dbo.t_dodatk.kod = inserted.kod AND inserted.rodzaj_zas = 1), '')
		, 1, inserted.numer_inw, (SELECT LTRIM(RTRIM(uwagi_s)) AS uwagi_s FROM dbo.sygnat WHERE dbo.sygnat.id_zasob = inserted.id_zasob and inserted.rodzaj_zas = 1),0
		FROM inserted WHERE id_zasob NOT IN (SELECT CAST(obcy_id AS int) FROM wypozyczalnia_wzorzec_dentons..w2_zasoby_t);		        
END

GO

CREATE TRIGGER [dbo].[normy_egzemplarz_dt] on [dbo].[Normy_egzemplarz] for DELETE AS
BEGIN
	
	set nocount on

	delete zasoby 
	from zasoby join deleted  on deleted.id_zasob = zasoby.id_zasob

END

GO