use [wypozyczalniatk]
select * from w2_grupy_z where nazwa = 'Normy'
if @@ROWCOUNT = 0
begin
INSERT INTO [dbo].[w2_grupy_z] ([nazwa],[aktywna],[limit_czasu]) VALUES ('Normy',1,30)
end


USE [colibertk]
GO

EXEC sp_RENAME 'Normy_egzemplarz.zas_zas_id' , 'id_zasob', 'COLUMN'

DROP INDEX [idx_Spn_spn_id] ON [dbo].[Normy_egzemplarz]
GO

CREATE NONCLUSTERED INDEX [idx_id_zasob_normy_egz] ON [dbo].[Normy_egzemplarz]
(
	[id_zasob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


INSERT INTO zasoby (k_kreskowy, kod, syg, tytul, autor, rok1, rodzaj_zas, rok2, volumin, numer_z, numer_z2, numer_inw, stan, zewn_akt) 
SELECT i.Id_nor_egz,i.nor_nor_id,i.Sygnatura,n.Tytul,'',DATEPART(year,i.Data),4,0,'',0,0,'',0,0
  FROM Normy_egzemplarz i join normy n on i.Nor_nor_id = n.Id_norma
where i.Sygnatura is not null and i.Data is not null and i.id_zasob is not null and i.id_zasob != 0

go
	
update Normy_egzemplarz set id_zasob = zasoby.id_zasob from zasoby join Normy_egzemplarz on Normy_egzemplarz.Id_nor_egz = zasoby.k_kreskowy and zasoby.rodzaj_zas = 4
go


CREATE TRIGGER dbo.normy_egzemplarz_it on dbo.normy_egzemplarz for INSERT AS
BEGIN
	set nocount on

	INSERT INTO zasoby (k_kreskowy, kod, syg, tytul, autor, rok1, rodzaj_zas, rok2, volumin, numer_z, numer_z2, numer_inw, stan, zewn_akt) 
	SELECT i.Id_nor_egz,i.nor_nor_id,i.Sygnatura,n.Tytul,'',DATEPART(year,i.Data),4,0,'',0,0,'',0,0
	  FROM inserted i join normy n on i.Nor_nor_id = n.Id_norma
	
	update Normy_egzemplarz set id_zasob = zasoby.id_zasob from zasoby join Normy_egzemplarz on Normy_egzemplarz.Id_nor_egz = zasoby.k_kreskowy and zasoby.rodzaj_zas = 4

END

GO

CREATE TRIGGER [dbo].[normy_egzemplarz_ut] on [dbo].[Normy_egzemplarz] for UPDATE AS
BEGIN
	set nocount on

	update zasoby set syg = i.sygnatura, rok1 = DATEPART(year,i.data), tytul = n.Tytul 
	from inserted i 
	join zasoby on i.id_zasob = zasoby.id_zasob
	join normy n on i.Nor_nor_id = n.Id_norma

END
go

DROP VIEW [dbo].[all_sygnat]
GO


CREATE VIEW [dbo].[all_sygnat]  
AS
	SELECT dbo.sygnat.id_zasob, sygnat.kod, dbo.sygnat.id_sygnat, 
	LTRIM(RTRIM(dbo.sygnat.syg)) AS syg, syg_expand, sort_order, LTRIM(RTRIM(dbo.sygnat.numer_inw)) AS numer_inw, numer_inw_expand,
	CASE WHEN k_kreskowy != 0 THEN CAST(k_kreskowy AS varchar) ELSE '' END AS k_kreskowy,	

	1 AS rodzaj,

	CASE 
		WHEN LEN(autorzy.autorzy) > 0 AND LEN(autorzy.wautorzy) > 0 THEN autorzy.autorzy + ', ' + autorzy.wautorzy 
		WHEN LEN(autorzy.autorzy) > 0 AND LEN(autorzy.wautorzy) = 0 THEN autorzy.autorzy
		WHEN LEN(autorzy.autorzy) = 0 AND LEN(autorzy.wautorzy) > 0 THEN autorzy.wautorzy
	END AS autor, NULL AS rok1, NULL AS num, NULL AS tytul_sort
	FROM dbo.sygnat
	OUTER APPLY 
	(
		SELECT ISNULL((SELECT stuff((
					SELECT  ', ' + LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie))
					FROM dbo.list_aut_k INNER JOIN dbo.ksiazki_autor_new ON dbo.ksiazki_autor_new.id_autor = dbo.list_aut_k.id_aut 
					WHERE dbo.ksiazki_autor_new.id_ksiazka = dbo.sygnat.kod 
					ORDER BY rating for xml path('')), 1,2,'')), '') AS autorzy,
			   ISNULL((SELECT stuff((
					SELECT  ', ' + LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie))
					FROM dbo.list_aut_k 
					INNER JOIN dbo.ksiazki_wautor_new ON dbo.ksiazki_wautor_new.id_wautor = dbo.list_aut_k.id_aut														
					WHERE dbo.ksiazki_wautor_new.id_ksiazka = dbo.sygnat.kod 
					ORDER BY rating for xml path('')),1,2,'')), '') AS wautorzy
	) autorzy
	UNION
	   
	SELECT dbo.cza_zas.id_zasob, dbo.cza_zas.kod, 
	dbo.volumes.id_cza_syg AS id_sygnat,
	/*
	ISNULL((SELECT LTRIM(RTRIM(dbo.cza_syg.syg)) FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg), '')  as syg,
	ISNULL((SELECT LTRIM(RTRIM(dbo.cza_syg.syg_expand)) FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg), '')  as syg_expand,
	ISNULL((SELECT dbo.cza_syg.sort_order FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg), '')  as sort_order,*/
	cza_syg.syg, cza_syg.syg_expand,cza_syg.sort_order,
	'' AS numer_inw, '' AS numer_inw_expand, '' AS k_kreskowy,
	2 as rodzaj, NULL AS autor, dbo.volumes.rok1, num, (SELECT LTRIM(RTRIM(tytul)) FROM dbo.czasop WHERE dbo.czasop.kod = dbo.volumes.kod) AS tytul_sort
	FROM dbo.cza_zas 
	INNER JOIN dbo.czasop_n ON dbo.czasop_n.id_czasop_n = dbo.cza_zas.id_czasop
	INNER JOIN dbo.volumes ON dbo.volumes.id_volumes = dbo.czasop_n.id_volumes
	--INNER JOIN dbo.cza_syg ON dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg

	OUTER APPLY
	(
		SELECT LTRIM(RTRIM(dbo.cza_syg.syg)) AS syg, 
		LTRIM(RTRIM(dbo.cza_syg.syg_expand)) AS syg_expand,
		sort_order
		FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg
	) cza_syg
	union
	SELECT e.id_zasob, 0 as kod, e.Id_nor_egz, e.Sygnatura AS syg, e.Sygnatura as syg_expand, 1 as sort_order, '' AS numer_inw, '' as numer_inw_expand,
	''  AS k_kreskowy, 4 AS rodzaj,'' AS autor, NULL AS rok1, NULL AS num, NULL AS tytul_sort
	FROM dbo.Normy_egzemplarz e

GO

DROP VIEW [dbo].[all_sygnat_z_usunietymi]
GO

CREATE VIEW [dbo].[all_sygnat_z_usunietymi]  
AS
-- istniej¹ce ksi¹¿ki
SELECT dbo.sygnat.id_zasob, LTRIM(RTRIM(dbo.sygnat.syg)) AS syg, syg_expand, LTRIM(RTRIM(dbo.sygnat.numer_inw)) AS numer_inw, numer_inw_expand,
CASE WHEN k_kreskowy != 0 THEN CAST(k_kreskowy AS varchar) ELSE '' END AS k_kreskowy,
1 AS rodzaj,

CASE 
	WHEN LEN(autorzy.autorzy) > 0 AND LEN(autorzy.wautorzy) > 0 THEN autorzy.autorzy + ', ' + autorzy.wautorzy 
	WHEN LEN(autorzy.autorzy) > 0 AND LEN(autorzy.wautorzy) = 0 THEN autorzy.autorzy
	WHEN LEN(autorzy.autorzy) = 0 AND LEN(autorzy.wautorzy) > 0 THEN autorzy.wautorzy
END AS autor, NULL AS rok1, NULL AS num, NULL AS tytul_sort
FROM dbo.sygnat
OUTER APPLY 
(
	SELECT ISNULL((SELECT stuff((
				SELECT  ', ' + LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie))
				FROM dbo.list_aut_k INNER JOIN dbo.ksiazki_autor_new ON dbo.ksiazki_autor_new.id_autor = dbo.list_aut_k.id_aut 
				WHERE dbo.ksiazki_autor_new.id_ksiazka = dbo.sygnat.kod 
				ORDER BY rating for xml path('')), 1,2,'')), '') AS autorzy,
		   ISNULL((SELECT stuff((
				SELECT  ', ' + LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie))
				FROM dbo.list_aut_k 
				INNER JOIN dbo.ksiazki_wautor_new ON dbo.ksiazki_wautor_new.id_wautor = dbo.list_aut_k.id_aut														
				WHERE dbo.ksiazki_wautor_new.id_ksiazka = dbo.sygnat.kod 
				ORDER BY rating for xml path('')),1,2,'')), '') AS wautorzy
) autorzy
UNION

-- usuniête ksi¹¿ki
SELECT id_zasob, LTRIM(RTRIM(syg)) AS syg, syg_expand, LTRIM(RTRIM(numer_inw)) AS numer_inw, numer_inw_expand,
'' AS k_kreskowy,
1 AS rodzaj, autorzy, NULL AS rok1, NULL AS num, NULL AS tytul_sort
FROM dbo.sygnatury_usuniete_opisy
UNION

-- istniej¹ce czasopisma
SELECT dbo.cza_zas.id_zasob, --dbo.cza_zas.kod, 
/*
ISNULL((SELECT LTRIM(RTRIM(dbo.cza_syg.syg)) FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg), '')  as syg,
ISNULL((SELECT LTRIM(RTRIM(dbo.cza_syg.syg_expand)) FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg), '')  as syg_expand,*/
cza_syg.syg, cza_syg.syg_expand,
'' AS numer_inw, '' AS numer_inw_expand, '' AS k_kreskowy,
2 as rodzaj, NULL AS autor, dbo.volumes.rok1, num, (SELECT LTRIM(RTRIM(tytul)) FROM dbo.czasop WHERE dbo.czasop.kod = dbo.volumes.kod) AS tytul_sort
FROM dbo.cza_zas 
INNER JOIN dbo.czasop_n ON dbo.czasop_n.id_czasop_n = dbo.cza_zas.id_czasop
INNER JOIN dbo.volumes ON dbo.volumes.id_volumes = dbo.czasop_n.id_volumes

OUTER APPLY
(
	SELECT LTRIM(RTRIM(dbo.cza_syg.syg)) AS syg, 
	LTRIM(RTRIM(dbo.cza_syg.syg_expand)) AS syg_expand,
	sort_order
	FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg
) cza_syg
union
SELECT e.id_zasob, e.Sygnatura AS syg, e.Sygnatura as syg_expand, '' AS numer_inw, '' as numer_inw_expand,
''  AS k_kreskowy, 4 AS rodzaj,'' AS autor, NULL AS rok1, NULL AS num, NULL AS tytul_sort
FROM dbo.Normy_egzemplarz e

GO

ALTER TRIGGER [dbo].[UpdateZasobyOnWypozyczalnia] ON [dbo].[zasoby] 
FOR INSERT, UPDATE 
AS
BEGIN
		DECLARE @czy_sygn AS BIT;

        SELECT @czy_sygn = w_warunek FROM konfig WHERE LOWER(nazwa) = 'replikujsygnjakokod';

		-- nowe
		UPDATE cza_zas SET wypozycz = inserted.stan FROM inserted WHERE cza_zas.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;
		UPDATE sygnat  SET wypozycz = inserted.stan FROM inserted WHERE sygnat.id_zasob = inserted.id_zasob AND inserted.zewn_akt = 1;	
		
		IF ((SELECT COUNT(*) FROM inserted WHERE zewn_akt = 0) > 0)
		BEGIN
			UPDATE wypozyczalniatk.dbo.w2_zasoby_t
					SET kod_kresk = CASE WHEN @czy_sygn = 0 THEN CAST(k_kreskowy AS VARCHAR) ELSE syg END,
						grupa_id = inserted.rodzaj_zas ,
						--opis = CASE WHEN LEN(LTRIM(autor)) = 0 THEN LTRIM(RTRIM(tytul)) ELSE LTRIM(RTRIM(autor)) + ': ' + LTRIM(RTRIM(tytul)) END,
						opis = LTRIM(RTRIM(tytul)) + ISNULL(' : ' + (SELECT LTRIM(RTRIM(t_dodatk)) FROM dbo.t_dodatk WHERE dbo.t_dodatk.kod = inserted.kod AND inserted.rodzaj_zas = 1), ''),
						zewn_akt = 1,
						numer_inw = inserted.numer_inw,
						uwagi = (SELECT LTRIM(RTRIM(uwagi_s)) AS uwagi_s FROM dbo.sygnat WHERE dbo.sygnat.id_zasob = inserted.id_zasob AND inserted.rodzaj_zas = 1)
					FROM inserted
				WHERE CAST(obcy_id as int) = inserted.id_zasob AND inserted.zewn_akt = 0 ;
		END

		INSERT INTO wypozyczalniatk..w2_zasoby (obcy_id, kod_kresk, grupa_id, opis, zewn_akt, numer_inw, uwagi)        
		SELECT (CAST(id_zasob AS VARCHAR)), CASE WHEN @czy_sygn = 0 THEN CAST(k_kreskowy AS VARCHAR) ELSE syg END, inserted.rodzaj_zas, LTRIM(RTRIM(tytul)) + ISNULL(' : ' + (SELECT LTRIM(RTRIM(t_dodatk)) FROM dbo.t_dodatk WHERE dbo.t_dodatk.kod = inserted.kod AND inserted.rodzaj_zas = 1), ''), 1, inserted.numer_inw, (SELECT LTRIM(RTRIM(uwagi_s)) AS uwagi_s FROM dbo.sygnat WHERE dbo.sygnat.id_zasob = inserted.id_zasob and inserted.rodzaj_zas = 1)
		FROM inserted WHERE id_zasob NOT IN (SELECT CAST(obcy_id AS int) FROM wypozyczalniatk..w2_zasoby);		        
END

go