
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [cen].[przekazp]
(
@iaktualne int, 
@inastepne int, 
@cBiuro varchar(5)
)
AS
BEGIN
SET NOCOUNT ON

DECLARE @t_przychod TABLE (
	idpisma int,
    pnrdzien int,
    nadwcamie character(35),
    nadwcaadr character(40),
    nadwcanaz character(80),
    nadwcaznk character(40),
    rodzprzes character(5),
    nrprzesyl character(30),
    datapisma DateTime,
    dotyczy varchar(254),
    nrsprawy varchar(40),
    grupa varchar(5),
    ggrupa varchar(5),
    datawplyw DateTime,
    nrdzien int,
    termins DateTime,
    zalatw bit,
    aktualnie int,
    nast_stano int,
    rok int,
    po_id int,
    po_next_id int,
    serial_id int,
    ns_opis varchar(255),
    ns_typ varchar(1),
    ns_grupa varchar(5),
    przekaz_ok bit)

	DECLARE @iNrDzien int
	DECLARE @iNrKanc int 
	DECLARE @lOK bit
	DECLARE @lOK1 bit 
	DECLARE @iIdUzyt int
	DECLARE @cNazwaUzytk varchar(64) 
	DECLARE @iWersja int
	DECLARE @cTyp varchar(1)
	DECLARE @cAll varchar(3)
	DECLARE @cGrupa varchar(5)
	DECLARE @ns_ggrupa varchar(5)

	SET @iNrKanc = -1
	SET @iNrDzien = -1
	SET @lOK = 1
	SET @lOK1 = 1
	SET @iIdUzyt = -1
	SET @iWersja = -1
	IF  @inastepne > 0
	begin
		set @lOK1 = 0
	end 

	--Variable for ROWYPE
	DECLARE @idpisma int
    DECLARE @pnrdzien int
    DECLARE @nadwcamie character(35)
    DECLARE @nadwcaadr character(40)
    DECLARE @nadwcanaz character(80)
    DECLARE @nadwcaznk character(40)
    DECLARE @rodzprzes character(5)
    DECLARE @nrprzesyl character(30)
    DECLARE @datapisma datetime
    DECLARE @dotyczy varchar(254)
    DECLARE @nrsprawy varchar(40)
    DECLARE @grupa varchar(5)
    DECLARE @ggrupa varchar(5)
    DECLARE @datawplyw datetime
    DECLARE @nrdzien int
    DECLARE @termins datetime
    DECLARE @zalatw bit
    DECLARE @aktualnie int
    DECLARE @nast_stano int
    DECLARE @rok int
    DECLARE @po_id int
    DECLARE @po_next_id int
    DECLARE @serial_id int
    DECLARE @ns_opis varchar(255)
    DECLARE @ns_typ varchar(1)
    DECLARE @ns_grupa varchar(5)
    DECLARE @przekaz_ok bit
	declare @cDeklar varchar(40)
	
	select @cTyp = typ,@cGrupa = grupa FROM t_global_uzyt_i_stanow WHERE id_stanowiska = @iaktualne ;
	select @cAll = ltrim(rtrim(wartosc)) from globvar where nazwa = 'KO_przekaz_all';
	IF (COALESCE(@cTyp,'X') LIKE 'K') AND (COALESCE(@cAll,'.F.') LIKE '.T.')
	BEGIN
		SET @cTyp = 'K';
	END
	ELSE
	BEGIN
		SET @cTyp = 'X';
	END
	-- kursor
	DECLARE c_pismap CURSOR FAST_FORWARD LOCAL FOR
	select idpisma,pnrdzien,nadwcamie,nadwcaadr,nadwcanaz,nadwcaznk,rodzprzes,nrprzesyl,datapisma,dotyczy,nrsprawy,grupa,ggrupa,datawplyw,nrdzien,termins,zalatw,aktualnie,nast_stano,rok,po_id,po_next_id,serial_id,'' as ns_opis,'' as ns_typ,'' as ns_grupa,0 as przekaz_ok,left(uwagi,40) as Deklar
		FROM przychod (UPDLOCK)
		WHERE  aktualnie 
		in (SELECT id_stanowiska FROM t_global_uzyt_i_stanow WHERE typ = @cTyp or id_stanowiska = @iaktualne or grupa = @cBiuro ) 
		and nast_stano <> @iaktualne and nast_stano <> 0 AND (nast_stano = @inastepne or 1=@lOK1 ) order by nrdzien 
	--Loop
	OPEN c_pismap
	FETCH NEXT FROM c_pismap INTO @idpisma,@pnrdzien,@nadwcamie,@nadwcaadr,@nadwcanaz,@nadwcaznk,@rodzprzes,@nrprzesyl,@datapisma,@dotyczy,@nrsprawy,@grupa,@ggrupa,@datawplyw,@nrdzien,@termins,@zalatw,@aktualnie,@nast_stano,@rok,@po_id,@po_next_id,@serial_id,@ns_opis,@ns_typ,@ns_grupa,@przekaz_ok,@cDeklar
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @iIdUzyt    =-1
		SET @lOK        = 1
		/*następne stanowisko*/
		SET @iIdUzyt  = (select id_uzyt from nadania where id_stanowiska = @nast_stano)
		select  @ns_typ = Typ,@ns_grupa = Grupa,@ns_ggrupa = GGrupa,@cNazwaUzytk = Nazwa from listauzy where id_uzy = @iIdUzyt ;
		SELECT  @ns_opis = LTRIM(RTRIM(S.grupa)) + ' / ' + LTRIM(RTRIM(S.nazwa)) + ' / ' + @cNazwaUzytk FROM struktura S where  id_stanowiska = @nast_stano;
		/*numer dziennika*/
		SET @iNrDzien = @nrdzien;
		if @grupa <> @ns_grupa
		BEGIN
			exec get_nrdzien @ns_grupa,'P','NRDZIEN',0,@iNrDzien output;
			if  @iNrDzien <= 0 
			BEGIN
				SET @lOK = 0;
			END
		END
		/*numer kancelaryjny*/
		SET @iNrKanc  = @pnrdzien ;
		if  @ns_typ = 'K' and @grupa <> @ns_grupa AND @iNrKanc = 0
		BEGIN
			exec cen.get_nrdzien '','P','PNRDZIEN',0,@iNrKanc output;
			if  @iNrKanc <= 0
			BEGIN
				SET @lOK  = 0 ;
			end ;
		end;
		SET @przekaz_ok = @lOK;
		if  @lOK = 1
		BEGIN
			/*zadania*/
			insert into zadania (idpisma, zrobione) values (@idpisma,0);
			update zadania set zrobione = 1 where idpisma = @idpisma;
			/**/
			update przychod set aktualnie = @nast_stano,grupa=@ns_grupa,ggrupa=@ns_grupa,nast_stano=0,nrdzien=@iNrDzien,pnrdzien=@iNrKanc,po_id=@po_next_id,po_next_id=0,uwagi = '' where serial_id=@serial_id;
			insert into obieg (idpisma,stanowisko,nrdzien,datawplyw,przekaz,time_,rok,grupa,Deklar) values (@idpisma,@iAktualne,@nrdzien,GetDate(),'O',CONVERT(VARCHAR(13),GetDate(),103),@rok,@cGrupa,@cDeklar);
			insert into @t_przychod values (@idpisma,@iNrKanc,@nadwcamie,@nadwcaadr,@nadwcanaz,@nadwcaznk,@rodzprzes,@nrprzesyl,@datapisma,@dotyczy,@nrsprawy,@cGrupa,@ggrupa,@datawplyw,@iNrDzien,@termins,@zalatw,@aktualnie,@nast_stano,@rok,@po_id,@po_next_id,@serial_id,@ns_opis,@ns_typ,@ns_grupa,@przekaz_ok )
			if  @ns_grupa <> @ns_ggrupa
			begin
				exec get_nrdzien @ns_ggrupa,'P','NRDZIEN',0,@iNrDzien output;
				insert into obieg (idpisma,stanowisko,nrdzien,datawplyw,przekaz,time_,rok,grupa,Deklar) values (@idpisma,@iAktualne,@iNrDzien,GetDate(),'C',CONVERT(VARCHAR(13),GetDate(),103),@rok,@ns_ggrupa,@cDeklar);
--				insert into @t_przychod values (@idpisma,@iNrKanc,@nadwcamie,@nadwcaadr,@nadwcanaz,@nadwcaznk,@rodzprzes,@nrprzesyl,@datapisma,@dotyczy,@nrsprawy,@cGrupa,@ggrupa,@datawplyw,@iNrDzien,@termins,@zalatw,@aktualnie,@nast_stano,@rok,@po_id,@po_next_id,@serial_id,@ns_opis,@ns_typ,@ggrupa,@przekaz_ok )
			end
			FETCH NEXT FROM c_pismap INTO @idpisma,@pnrdzien,@nadwcamie,@nadwcaadr,@nadwcanaz,@nadwcaznk,@rodzprzes,@nrprzesyl,@datapisma,@dotyczy,@nrsprawy,@grupa,@ggrupa,@datawplyw,@nrdzien,@termins,@zalatw,@aktualnie,@nast_stano,@rok,@po_id,@po_next_id,@serial_id,@ns_opis,@ns_typ,@ns_grupa,@przekaz_ok,@cDeklar
		END
	END
	CLOSE c_pismap
	DEALLOCATE c_pismap
	select * from @t_przychod order by grupa,nrdzien
END
