/*
use archivarius
go
CREATE UNIQUE INDEX uidx_teczka_kod_kreskowy ON Teczka (kod_kreskowy) WHERE kod_kreskowy != ''
GO
*/


USE Coliber
GO

alter table zasoby add SuperKey Integer
go

alter table zasoby add rodzaj char(1)
go

CREATE INDEX IDX_SuperKey ON Zasoby (SuperKey)
go

select distinct k_kreskowy from zasoby WHERE k_kreskowy != 0
--CREATE UNIQUE INDEX uidx_zasoby_k_kreskowy ON Zasoby (k_kreskowy) WHERE k_kreskowy != 0
GO


ALTER VIEW [dbo].[all_sygnat]  
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
	cza_syg.syg, cza_syg.syg_expand,cza_syg.sort_order,
	'' AS numer_inw, '' AS numer_inw_expand, cza_zas.k_kreskowy,
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
	UNION
	SELECT   z.id_zasob, z.Kod, 0 as id_czas_syg,z.Syg , z.Syg AS syg_expand, '' as sort_order, z.numer_inw , z.numer_inw AS numer_inw_expand, CAST(z.k_kreskowy AS varchar) , rodzaj_zas AS rodzaj, '' AS autor, z.rok1 AS rok1, NULL AS num, NULL AS tytul_sort from zasoby z where rodzaj = 'D'

	--SELECT e.id_zasob, e.Sygnatura AS syg, e.Sygnatura as syg_expand, '' AS numer_inw, '' as numer_inw_expand,''  AS k_kreskowy, 4 AS rodzaj,'' AS autor, NULL AS rok1, NULL AS num, NULL AS tytul_sort FROM dbo.Normy_egzemplarz e


GO


ALTER VIEW [dbo].[all_sygnat_z_usunietymi]  
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

--ISNULL((SELECT LTRIM(RTRIM(dbo.cza_syg.syg)) FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg), '')  as syg,
--ISNULL((SELECT LTRIM(RTRIM(dbo.cza_syg.syg_expand)) FROM dbo.cza_syg WHERE dbo.cza_syg.id_cza_syg = dbo.volumes.id_cza_syg), '')  as syg_expand,

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
SELECT   z.id_zasob, z.Syg , z.Syg AS syg_expand, z.numer_inw , z.numer_inw AS numer_inw_expand, CAST(k_kreskowy AS varchar) AS k_kreskowy, rodzaj_zas AS rodzaj, '' AS autor, z.rok1 AS rok1, NULL AS num, NULL AS tytul_sort from zasoby z where rodzaj = 'D'


--SELECT e.id_zasob, e.Sygnatura AS syg, e.Sygnatura as syg_expand, '' AS numer_inw, '' as numer_inw_expand,''  AS k_kreskowy, 4 AS rodzaj,'' AS autor, NULL AS rok1, NULL AS num, NULL AS tytul_sort FROM dbo.Normy_egzemplarz e


GO



ALTER PROCEDURE dbo.Czasop_ExtrasAdd
	-- Add the parameters for the stored procedure here	 
	@p_MagazineID int,
	@p_Syg varchar(20),
	@p_rok1 numeric(4, 0),
	@p_rok2 numeric(4, 0),
	@p_volumin varchar(16),
	@p_autor1 varchar(40),
	@p_autor2 varchar(40),
	@p_autor3 varchar(40),
	@p_tytul_dod varchar(201),
	@k_kreskowy int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @idDodad int;
	declare @autor varchar(120)
	set @autor = ''
	if @p_autor1 is not null and @p_autor1 != '' begin 	set @autor = @autor + @p_autor1 + ' ' end
	if @p_autor2 is not null and @p_autor2 != '' begin 	set @autor = @autor + @p_autor2 + ' ' end 
	if @p_autor3 is not null and @p_autor3 != '' begin 	set @autor = @autor + @p_autor3 + ' ' end
	set @autor = RTrim(@autor)

	declare @tytul varchar(1200)
	select @tytul = RTrim(LTrim(tytul)) + ' :dod: ' + @p_tytul_dod from czasop where kod = @p_MagazineID

    -- Insert statements for procedure here
	INSERT INTO dodatki (kod, syg, rok1, rok2, volumin, autor1, autor2, autor3, tytul_dod, data_biez, k_kreskowy)
	VALUES (@p_MagazineID, @p_Syg, @p_rok1, @p_rok2, @p_volumin, @p_autor1, @p_autor2, @p_autor3, @p_tytul_dod, GETDATE(),@k_kreskowy);

	SELECT @idDodad = SCOPE_IDENTITY();

	INSERT INTO zasoby (k_kreskowy,kod,syg,tytul,autor,rodzaj_zas,rok1,rok2,volumin,stan,zewn_akt,SuperKey,rodzaj) VALUES
		(@k_kreskowy,@p_MagazineID,@p_syg,@tytul,@autor,2,@p_rok1,isnull(@p_rok2,0),@p_volumin,0,0,@idDodad,'D')


END

GO

ALTER PROCEDURE [dbo].[Czasop_ExtrasEdit]
	-- Add the parameters for the stored procedure here
	@p_Syg varchar(20),
	@p_rok1 numeric(4, 0),
	@p_rok2 numeric(4, 0),
	@p_volumin varchar(16),
	@p_autor1 varchar(40),
	@p_autor2 varchar(40),
	@p_autor3 varchar(40),
	@p_tytul_dod varchar(201),
	@k_kreskowy int,
	@p_id_dodatki int
AS
BEGIN
	SET NOCOUNT ON;

	declare @autor varchar(120)
	set @autor = ''
	if @p_autor1 is not null and @p_autor1 != '' begin 	set @autor = @autor + @p_autor1 + ' ' end
	if @p_autor2 is not null and @p_autor2 != '' begin 	set @autor = @autor + @p_autor2 + ' ' end 
	if @p_autor3 is not null and @p_autor3 != '' begin 	set @autor = @autor + @p_autor3 + ' ' end
	set @autor = RTrim(@autor)

	declare @kod int
	declare @tytul varchar(1200)
	select @kod  = kod from dodatki where id_dodatki = @p_id_dodatki
	select @tytul = RTrim(LTrim(tytul)) + ' :dod: ' + @p_tytul_dod from czasop where kod = @kod

	UPDATE dodatki SET syg = @p_Syg, rok1 = @p_rok1, rok2 = @p_rok2, volumin = @p_volumin, autor1 = @p_autor1, autor2 = @p_autor2, autor3 = @p_autor3, tytul_dod = @p_tytul_dod, k_kreskowy = @k_kreskowy WHERE id_dodatki = @p_id_dodatki;

	update zasoby SET syg = @p_Syg, rok1 = @p_rok1, rok2 = isnull(@p_rok2,0), volumin = @p_volumin, autor = @autor, tytul = @tytul, k_kreskowy = @k_kreskowy WHERE SuperKey = @p_id_dodatki and rodzaj = 'D' ;

END

GO


--select * from zasoby where id_zasob not in (select distinct id_zasob from cza_zas) and rodzaj_zas = 2 --and (rodzaj is null or rodzaj != 'D')

/*
ALTER TABLE zasoby DISABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
update zasoby set rodzaj = 'D' from zasoby where id_zasob not in (select distinct id_zasob from cza_zas) and rodzaj_zas = 2 --and (rodzaj is null or rodzaj != 'D')
--update zasoby set tytul = dbo.Tran101(tytul) where rodzaj_zas = 2 
go
ALTER TABLE zasoby ENABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
*/

--select w.opis,z.Tytul from Wypozyczalnia.dbo.w2_zasoby_t w join zasoby z on cast(w.obcy_id as int) = z.id_zasob where len(w.opis) > 10 and left(w.opis,len(w.opis)-10) != left(z.tytul,len(z.tytul)-10)
--select tytul,dbo.Tran101(tytul) from zasoby where rodzaj_zas = 2 order by tytul

/*
ALTER TABLE zasoby DISABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
update zasoby set rodzaj = 'D' from zasoby where id_zasob not in (select distinct id_zasob from cza_zas) and rodzaj_zas = 2 --and (rodzaj is null or rodzaj != 'D')
--update zasoby set tytul = dbo.Tran101(tytul) where rodzaj_zas = 2 
go
ALTER TABLE zasoby ENABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
*/

--select w.opis,c.tytul from w2_zasoby_t w join coliber.dbo.zasoby c on cast(w.obcy_id as int) = c.id_zasob where grupa_id = 2 and w.opis # c.tytul

/*
use Wypozyczalnia
ALTER TABLE w2_zasoby_t DISABLE TRIGGER UpdateZasobyOnColiber
GO
update w2_zasoby_t set opis = c.tytul from w2_zasoby_t w join coliber.dbo.zasoby c on cast(w.obcy_id as int) = c.id_zasob where grupa_id = 2 and w.opis # c.tytul
go
ALTER TABLE w2_zasoby_t ENABLE TRIGGER UpdateZasobyOnColiber
GO
*/
