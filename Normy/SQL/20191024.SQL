use wypozyczalnia
go
alter table w2_zasoby_t add sygnatura varchar(30)
go
alter table w2_zasoby_t add kod int
go
CREATE NONCLUSTERED INDEX [idx_w2_zasoby_t_kod] ON w2_zasoby_t
(
	[kod] ASC
)
GO

ALTER TABLE w2_zasoby_t DISABLE TRIGGER UpdateZasobyOnColiber
GO

update w2_zasoby_t  set w2_zasoby_t.kod = c.kod,w2_zasoby_t.sygnatura = c.syg
from (select kod,syg,id_zasob from coliber.dbo.zasoby ) c
where c.id_zasob = cast(w2_zasoby_t.obcy_id as int)
go

ALTER TABLE w2_zasoby_t ENABLE TRIGGER UpdateZasobyOnColiber
GO

use coliber
go

alter table zasoby alter column syg varchar(30)
go

alter table Normy_egzemplarz alter column sygnatura varchar(30)
go

ALTER TRIGGER [dbo].[UpdateZasobyOnWypozyczalnia] ON [dbo].[zasoby] 
FOR INSERT, UPDATE 
AS
BEGIN

		-- nowe
		UPDATE cza_zas SET wypozycz = inserted.stan FROM inserted WHERE cza_zas.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;
		UPDATE sygnat  SET wypozycz = inserted.stan FROM inserted WHERE sygnat.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;	
		UPDATE Normy_egzemplarz SET zas_stan_id = inserted.stan FROM inserted WHERE Normy_egzemplarz.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;	
		
		IF ((SELECT COUNT(*) FROM inserted WHERE zewn_akt = 0) > 0)
		BEGIN
			UPDATE wypozyczalnia.dbo.w2_zasoby_t
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

		INSERT INTO wypozyczalnia..w2_zasoby_t(obcy_id, kod_kresk, sygnatura, kod, grupa_id, opis, zewn_akt, numer_inw, uwagi)        
		SELECT (CAST(id_zasob AS VARCHAR)), CAST(inserted.k_kreskowy as int), inserted.syg, inserted.kod, inserted.rodzaj_zas, 
		LTRIM(RTRIM(tytul)) + ISNULL(' : ' + (SELECT LTRIM(RTRIM(t_dodatk)) FROM dbo.t_dodatk WHERE dbo.t_dodatk.kod = inserted.kod AND inserted.rodzaj_zas = 1), '')
		, 1, inserted.numer_inw, (SELECT LTRIM(RTRIM(uwagi_s)) AS uwagi_s FROM dbo.sygnat WHERE dbo.sygnat.id_zasob = inserted.id_zasob and inserted.rodzaj_zas = 1)
		FROM inserted WHERE id_zasob NOT IN (SELECT CAST(obcy_id AS int) FROM wypozyczalnia..w2_zasoby_t);		        
END
go
