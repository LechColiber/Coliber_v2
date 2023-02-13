
--select tytul,dbo.Tran101(tytul) from zasoby where rodzaj_zas = 2 order by tytul

-- select dbo.FGetMagazineTitle(c.kod,a.tytul,c.numer_z,c.numer_z2,c.rok1,c.kol) from czasop_n c join akcesja a on c.kod = a .kod

/*
select id_czasop,names,replace(names,',',char(10)) as kodyk from 
(
select  id_czasop ,names = stuff((select ', ' + cast(k_kreskowy as varchar) as [text()]
        from cza_zas xt
        where xt.id_czasop = t.id_czasop
        for xml path('')), 1, 2, '')
from cza_zas t
group by id_czasop
) x
where x.names != '0'
*/

/*
CREATE FUNCTION [dbo].[Tran101]
(
	@Napis varchar(1000)
)
RETURNS varchar(1000)
AS
BEGIN

DECLARE @pos INT
DECLARE @pos1 INT
DECLARE @pos2 INT
DECLARE @len INT
DECLARE @tmp varchar(1000)
DECLARE @org varchar(1000)

set @pos1 = CHARINDEX(';',REVERSE(@Napis))
set @pos2 = CHARINDEX(':',REVERSE(@Napis))
set @pos = 0
if (@pos1 = 0) set @pos1 = 1001
if (@pos2 = 0) set @pos2 = 1001
if (@pos1 < @pos2) set @pos = @pos1
if (@pos2 < @pos1) set @pos = @pos2
if @pos = 0 return @Napis

set @tmp = RIGHT(@napis,@pos)
set @pos = CHARINDEX('/',reverse(@tmp))
if @pos = 0 return @Napis
set @len = len(@tmp)
set @org = @tmp
set @tmp = ';' + right(@tmp,@pos-1) + ' /' + substring(@tmp,2,@len - @pos - 1) 
set @tmp = rtrim(dbo.expand(@tmp,2,@len * 2))
--+ ' pos1 = ' + cast(@pos1 as varchar(10)) + ' pos2 = ' + cast(@pos2 as varchar(10))
return Replace(@Napis,@org,@tmp)
end

go
*/

/*
ALTER TRIGGER [dbo].[upd_zas_from_czasop_insert] 
   ON  [dbo].[czasop_n] 
   for INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @kod int;
    declare @rok1 numeric(4,0);
    declare @rok2 numeric(4,0);
    DECLARE @numer_z numeric(4,0);
    DECLARE @numer_z2 numeric(4,0);
	declare @id_czasop_n int;
	declare @volumin varchar(16);
    declare @tytul varchar(max);
    DECLARE @Id_zasob int;
    DECLARE @ilosc numeric(3,0);
    DECLARE @i int;
    DECLARE @syg varchar(20);
	DECLARE @ile_wyp int;
	DECLARE @num_abs numeric(5, 0);
    DECLARE @num_abs2 numeric(5, 0);
	DECLARE @Mode int;
	DECLARE @kol int;
	DECLARE @id_volumes int;
	declare @KodyK varchar(254);
	declare @iKod int;

	DECLARE insert_in_czasop_n CURSOR FAST_FORWARD FOR		
		SELECT	KodyK, kod, numer_z, numer_z2, num_abs, num_abs2, id_czasop_n,
				(SELECT volumes.rok1 FROM volumes WHERE volumes.id_volumes = inserted.id_volumes) AS rok1, 
				(SELECT volumes.rok2 FROM volumes WHERE volumes.id_volumes = inserted.id_volumes) AS rok2, 
				(SELECT volumes.volumin FROM volumes WHERE volumes.id_volumes = inserted.id_volumes) AS volumin, 
				ilosc, kol, id_volumes, ile_wyp 
		FROM inserted;

	OPEN insert_in_czasop_n;

	FETCH NEXT FROM insert_in_czasop_n INTO @KodyK, @kod, @numer_z, @numer_z2, @num_abs, @num_abs2, @id_czasop_n, @rok1, @rok2, @volumin, @ilosc, @kol, @id_volumes, @ile_wyp;

	-- rodzaj_zas=2 to czasopisma
	-- nie ma rekordu w tabeli zasoby - prosty insert 
	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @Mode = (SELECT id_akces FROM akcesja WHERE kod = @kod);
		SET @tytul = (SELECT LTRIM(RTRIM(tytul)) FROM akcesja WHERE akcesja.kod = @kod);

		SET @syg = (SELECT syg 
					FROM cza_syg 
					WHERE id_cza_syg = (SELECT id_cza_syg FROM volumes WHERE id_volumes = @id_volumes));

		DECLARE @numer int = CASE WHEN @Mode IN (1, 2) THEN @numer_z ELSE @num_abs END;
		DECLARE @numer2 int = CASE WHEN @Mode IN (1, 2) THEN @numer_z2 ELSE @num_abs2 END;
	
		SET @i = 1;
		
		IF @Mode = 1 OR @Mode = 2
			EXEC GetMagazineTitle @kod, @tytul, @numer_z, @numer_z2, @rok1, @kol, @tytul OUTPUT;
		ELSE
			EXEC GetMagazineTitle @kod, @tytul, @num_abs, @num_abs2, @rok1, @kol, @tytul OUTPUT;

	    set @KodyK = REPLACE(@KodyK, char(10), '.') + '.'
	 
		WHILE @i <= @ile_wyp
			 BEGIN  

				select @iKod = cast(dbo.StrElem(@KodyK, '.', @i) as int)

				--insert into zztest values (PARSENAME(REPLACE(@KodyK, char(10), '.'), @i))

				INSERT INTO dbo.zasoby (k_kreskowy, kod, syg, tytul, autor, rodzaj_zas, rok1, volumin, numer_z, numer_z2, numer_inw, stan, zewn_akt) 
				VALUES (@iKod, @kod, ISNULL(@syg,''), @tytul, '', 2, @rok1, @volumin, @numer_z, @numer_z2, ISNULL(@syg, '0'), 0, 0);
	
				SET @Id_zasob = SCOPE_IDENTITY();

				INSERT INTO dbo.cza_zas(kod, id_zasob, id_czasop, num, wypozycz, k_kreskowy) VALUES (@kod, @Id_zasob, @id_czasop_n, @numer, 0, @iKod);

				/*IF @Mode = 1 OR @Mode = 2
					INSERT INTO dbo.cza_zas(kod, id_zasob, id_czasop, num, wypozycz) values (@kod, @Id_zasob, @id_czasop_n, @numer_z, 0);
				ELSE
					INSERT INTO dbo.cza_zas(kod, id_zasob, id_czasop, num, wypozycz) values (@kod, @Id_zasob, @id_czasop_n, @num_abs, 0);*/

				SET @i = @i + 1;
			END

		FETCH NEXT FROM insert_in_czasop_n INTO @KodyK, @kod, @numer_z, @numer_z2, @num_abs, @num_abs2, @id_czasop_n, @rok1, @rok2, @volumin, @ilosc, @kol, @id_volumes, @ile_wyp;
	END

	CLOSE insert_in_czasop_n;
	DEALLOCATE insert_in_czasop_n;
END
go
*/

/*
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
		
		SET @tytul = ISNULL(LTRIM(RTRIM(@tytul)), '') + '; ' + @tytul_zeszytu +

						 						 
						CASE WHEN @rok IS NOT NULL and @rok != 0 THEN
							LTRIM(RTRIM(CAST(@rok AS varchar)))
						ELSE
						''
						END + 

						CASE WHEN @numer IS NOT NULL and @numer != 0 THEN
						' / ' + LTRIM(RTRIM(CAST(@numer AS varchar))) 
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
GO
*/