--select * from czasop_n where id_czasop_n not in (select distinct id_czasop from cza_zas)
--select * from cza_zas where id_czasop not in (select distinct id_czasop_n from czasop_n)

--select distinct rodzaj_zas from zasoby where id_zasob not in (select distinct id_zasob from cza_zas)

--select * from zasoby where id_zasob not in (select distinct id_zasob from cza_zas) and rodzaj_zas = 2

--select 'cz.' + rtrim(dbo.expand(substring(syg,4,10),3,6)) from zasoby where rodzaj_zas = 2 and syg like 'cz%'

--select tytul,dbo.Tran101(tytul) as tyt from zasoby where rodzaj_zas = 2 order by tyt

--select dbo.FGetMagazineTitle(c.kod,a.tytul,c.numer_z,c.numer_z2,c.rok1,c.kol) from czasop_n c join akcesja a on c.kod = a .kod order by 1





/*
select czasop_n.kodyk,x.id_czasop,names,replace(names,',',char(10)) as kodyk from 
czasop_n join 
(
select  id_czasop ,names = stuff((select ', ' + cast(k_kreskowy as varchar) as [text()]
        from cza_zas xt
        where xt.id_czasop = t.id_czasop
        for xml path('')), 1, 2, '')
from cza_zas t
group by id_czasop
) x on czasop_n.id_czasop_n = x.id_czasop
where x.names != '0' and (czasop_n.KodyK is null or czasop_n.KodyK = '')

ALTER TABLE czasop_n DISABLE TRIGGER upd_zas_from_czasop_update
GO

update czasop_n set kodyk = replace(names,',',char(10))  from 
czasop_n  join 
(
select  id_czasop ,names = stuff((select ', ' + cast(k_kreskowy as varchar) as [text()]
        from cza_zas xt
        where xt.id_czasop = t.id_czasop
        for xml path('')), 1, 2, '')
from cza_zas t
group by id_czasop
) x on czasop_n.id_czasop_n = x.id_czasop
where x.names != '0' and (czasop_n.KodyK is null or czasop_n.KodyK = '')

ALTER TABLE czasop_n ENABLE TRIGGER upd_zas_from_czasop_update
GO

alter table dodatki add k_kreskowy int
go
ALTER PROCEDURE [dbo].[Czasop_ExtrasList]
	-- Add the parameters for the stored procedure here
	@p_MagazineID int,
	@p_signature varchar(20),
	@p_volumin varchar(16),
	@p_rok1 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	  SELECT id_dodatki AS id, LTRIM(RTRIM(autor1)) AS autor1, LTRIM(RTRIM(autor2)) AS autor2, LTRIM(RTRIM(autor3)) AS autor3, LTRIM(RTRIM(tytul_dod)) AS tytul_dod,k_kreskowy 
	  FROM dodatki
	  WHERE kod = @p_MagazineID AND syg = @p_signature AND volumin = @p_volumin AND rok1 = @p_rok1;
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
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dodatki SET
		syg = @p_Syg, rok1 = @p_rok1, rok2 = @p_rok2, volumin = @p_volumin, autor1 = @p_autor1, autor2 = @p_autor2, autor3 = @p_autor3, tytul_dod = @p_tytul_dod, k_kreskowy = @k_kreskowy
	WHERE id_dodatki = @p_id_dodatki;
END
Go

ALTER PROCEDURE [dbo].[Czasop_ExtrasAdd]
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

    -- Insert statements for procedure here
	INSERT INTO dodatki (kod, syg, rok1, rok2, volumin, autor1, autor2, autor3, tytul_dod, data_biez, k_kreskowy)
	VALUES (@p_MagazineID, @p_Syg, @p_rok1, @p_rok2, @p_volumin, @p_autor1, @p_autor2, @p_autor3, @p_tytul_dod, GETDATE(),@k_kreskowy);
END
go

USE [Coliber]
GO
ALTER FUNCTION [dbo].[FGetMagazineTitle]
(
	-- Add the parameters for the function here
	@kod int,
	@tytul varchar(max),
	@numer int,
	@numer_2 int,
	@rok int,
	@kol int
)
RETURNS varchar(max)
AS
BEGIN
	DECLARE @id_czest int;
	DECLARE @MaxKol int = 0;
	DECLARE @len INT
	DECLARE @tmp varchar(1000)
	SET @tytul = ISNULL(@tytul, '');
	DECLARE @tytul_zeszytu varchar(max) = ISNULL((SELECT CASE WHEN LEN(LTRIM(RTRIM(tytul_num))) > 0 THEN 'Tytu³ zeszytu: ' + LTRIM(RTRIM(tytul_num)) + '; ' ELSE '' END FROM dbo.czasop_n WHERE kod = @kod AND rok1 = @rok AND kol = @kol), '');

	SELECT @id_czest = id_czest FROM akcesja WHERE kod = @kod;

	SET @MaxKol = (SELECT liczba_pol_podstawowych 
					FROM czasop_n_liczba_pol
					WHERE id_czestotliwosc = @id_czest AND przestepny = (CASE WHEN ((@rok % 4 = 0 AND @rok % 100 != 0) OR @rok % 400 = 0) AND @id_czest = 1 THEN 1 ELSE 0 END)
					);

	IF @kol = @MaxKol + 1 
	BEGIN
		SET @tytul = ISNULL(LTRIM(RTRIM(@tytul)), '') + '; ' + @tytul_zeszytu + 'indeks za ' + ISNULL(LTRIM(RTRIM(CAST(@rok AS varchar))), '');
	END
	ELSE
	BEGIN
		
		set @tmp = LTRIM(RTRIM(CAST(@numer AS varchar)))
		set @len = len(@tmp)
		SET @tytul = ISNULL(LTRIM(RTRIM(@tytul)), '') + '; ' + @tytul_zeszytu +

						 						 
						CASE WHEN @rok IS NOT NULL and @rok != 0 THEN
							LTRIM(RTRIM(CAST(@rok AS varchar)))
						ELSE
						''
						END + 

						CASE WHEN @numer IS NOT NULL and @numer != 0 THEN
							' / ' + rtrim(dbo.expand(@tmp,2,@len * 2))
						ELSE
						''
						END +

						CASE WHEN @numer IS NOT NULL AND @numer != 0 and @numer_2 IS NOT NULL and @numer_2 != 0 THEN
						' / '
						ELSE
						'' 
						END +

						CASE WHEN @numer_2 != 0 AND @numer_2 IS NOT NULL THEN
						LTRIM(RTRIM(CAST(@numer_2 AS varchar)))
						ELSE
						'' 
						END +
						
						CASE WHEN @kol <= @MaxKol THEN 
						'' 
						ELSE 
						' nr spec.' 
						END 



	END

	-- [tytul_czasopisma]; Tytul zeszytu: [tytul_zeszytu]; [numer] / [numer2] nr spec. / [rok]

	RETURN @tytul;
END
go

ALTER TABLE zasoby DISABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
update zasoby set tytul = dbo.Tran101(tytul) where rodzaj_zas = 2 
go
ALTER TABLE zasoby ENABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
ALTER TABLE zasoby DISABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
update zasoby set syg =  'cz.' + rtrim(dbo.expand(substring(syg,4,10),3,6)) where rodzaj_zas = 2 and syg like 'cz.%'
go
ALTER TABLE zasoby ENABLE TRIGGER UpdateZasobyOnWypozyczalnia
GO
use coliber
ALTER TABLE cza_syg DISABLE TRIGGER UpdateSygInOtherTables
GO
update cza_syg set syg =  'cz.' + rtrim(dbo.expand(substring(syg,4,10),3,6)) where syg like 'cz.%'
go
ALTER TABLE cza_syg ENABLE TRIGGER UpdateSygInOtherTables
GO


use Wypozyczalnia

--select w.opis,c.tytul from w2_zasoby_t w join coliber.dbo.zasoby c on cast(w.obcy_id as int) = c.id_zasob where grupa_id = 2

ALTER TABLE w2_zasoby_t DISABLE TRIGGER UpdateZasobyOnColiber
GO

update w2_zasoby_t set opis = c.tytul from w2_zasoby_t w join coliber.dbo.zasoby c on cast(w.obcy_id as int) = c.id_zasob where grupa_id = 2 
go

ALTER TABLE w2_zasoby_t ENABLE TRIGGER UpdateZasobyOnColiber
GO



use Wypozyczalnia


ALTER TABLE w2_zasoby_t DISABLE TRIGGER UpdateZasobyOnColiber
GO

update w2_zasoby_t set sygnatura =  'cz.' + rtrim(coliber.dbo.expand(substring(sygnatura,4,10),3,6)) where grupa_id = 2 and sygnatura like 'cz.%'
go

ALTER TABLE w2_zasoby_t ENABLE TRIGGER UpdateZasobyOnColiber
GO


*/

