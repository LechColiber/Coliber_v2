set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [cen].[przekazw]
(
@iaktualne int, 
@inastepne int
)
AS
BEGIN
SET NOCOUNT ON
DECLARE @t_wychodz TABLE (
	grupa character(5),
	pnrdzien int,
	nrdzien int,
	aktualnie int,
	adrsatmie character(35),
	adrsatadr character(40),
	adrsarnaz character(80),
	nadawca character(60),
	nadwcaznk character(40),
	datapisma datetime,
	dotyczy character(254),
	nrsprawy character(40),
	datawysl datetime,
	rodzprzes character(5),
	nrprzesyl character(10),
	przekaz character(1),
	zalatw bit,
	idw int,
	idpisma int,
	kod character(20),
	kraj_id int,
	maska character(20),
	nast_stano int,
	po_id int,
	po_next_id int,
	serial_id int,
	nrdzienp int,
	ns_opis character varying(255),
	ns_typ character(1),
	ns_grupa character(5),
	przekaz_ok bit)

	DECLARE @lOK bit --= 1
	DECLARE @lOK1 bit --= 1
	DECLARE @iNrDzien int-- = -1
	DECLARE @iNrKanc int --=  -1
	DECLARE @iIdPisma int --int -1;
	DECLARE @iIdUzyt int  --=  -1
	DECLARE @iWersja int --= -1 
	DECLARE @dDataWysl datetime -- int null;
	DECLARE @lRet bit --int false;
	DECLARE @lZaznacz bit --int true;
	DECLARE @nId int

	SET @lOK = 1
	SET @lOK1 = 1
	SET @iNrDzien = -1
	SET @iNrKanc = -1
	SET @iIdPisma = -1;
	SET @iIdUzyt = -1
	SET @iWersja = -1
	SET @lRet = 0 
	SET @lZaznacz = 1
	SET @nId = null

	IF  @inastepne > 0
	begin
		set @lOK1 = 0
	end 

	--Variable for ROWYPE
    DECLARE @grupa character(5)
	DECLARE @pnrdzien int
	DECLARE @nrdzien int
	DECLARE @aktualnie int
	DECLARE @adrsatmie character(35)
	DECLARE @adrsatadr character(40)
	DECLARE @adrsarnaz character(80)
	DECLARE @nadawca character(60)
	DECLARE @nadwcaznk character(40)
	DECLARE @datapisma datetime
	DECLARE @dotyczy character(254)
	DECLARE @nrsprawy character(40)
	DECLARE @datawysl datetime
	DECLARE @rodzprzes character(5)
	DECLARE @nrprzesyl character(10)
	DECLARE @przekaz character(1)
	DECLARE @zalatw bit
	DECLARE @idw int
	DECLARE @idpisma int
	DECLARE @kod character(20)
	DECLARE @kraj_id int
	DECLARE @maska character(20)
	DECLARE @nast_stano int
	DECLARE @po_id int
	DECLARE @po_next_id int
	DECLARE @serial_id int
	DECLARE @nrdzienp int
	DECLARE @ns_opis character varying(255)
	DECLARE @ns_typ character(1)
	DECLARE @ns_grupa character(5)
	DECLARE @przekaz_ok bit
	
	DECLARE c_pismaw CURSOR  FAST_FORWARD LOCAL FOR
	select grupa,pnrdzien,nrdzien,aktualnie,adrsatmie,adrsatadr,adrsarnaz,nadawca,nadwcaznk,datapisma,dotyczy,nrsprawy,datawysl,rodzprzes,nrprzesyl,przekaz,zalatw,idw,idpisma,kod,kraj_id,maska,nast_stano,po_id,po_next_id,serial_id,0 as nrdzienp,'' as ns_opis,'' as ns_typ,'' as ns_grupa,0 as przekaz_ok
	   from wychodz (UPDLOCK)
		   where aktualnie = @iAktualne and nast_stano <> @iAktualne and nast_stano <> 0 
			and przekaz <> 'V' order by grupa,nrdzien
	--Loop
	OPEN c_pismaw
	FETCH NEXT FROM c_pismaw INTO @grupa,@pnrdzien,@nrdzien,@aktualnie,@adrsatmie,@adrsatadr,@adrsarnaz,@nadawca,@nadwcaznk,@datapisma,@dotyczy,@nrsprawy,@datawysl,@rodzprzes,@nrprzesyl,@przekaz,@zalatw,@idw,@idpisma,@kod,@kraj_id,@maska,@nast_stano,@po_id,@po_next_id,@serial_id,@nrdzienp,@ns_opis,@ns_typ,@ns_grupa,@przekaz_ok
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @dDataWysl  = null;
		SET @lOK        = 1
		SET @iNrKanc    = 0
		SET @iIdPisma   = 0;
		SET @lZaznacz   = 1;
		/*następne stanowisko*/
		SET @iIdUzyt  = (select id_uzyt from nadania where id_stanowiska = @nast_stano)
		select  @ns_typ = Typ,@ns_grupa = Grupa from listauzy where id_uzy = @iIdUzyt ;
		SELECT  @ns_opis = LTRIM(RTRIM(S.grupa)) + ' / ' + LTRIM(RTRIM(S.nazwa)) + ' / ' FROM struktura S where  id_stanowiska = @nast_stano;
		/*data wysl*/
		if  @przekaz = 'W' 
		begin
			SET @dDataWysl = current_timestamp 
		end
		else
		begin
			if  @ns_grupa = 'KO' 
			begin
				SET @lZaznacz = 0
				SET @lRet = (select rejestrowa from lpoczt where skrot = @rodzprzes)
				if  @lRet = 0
				begin
					SET @dDataWysl = current_timestamp 
				end
			end 
		end
		/*nr dziennika,idpisma i nrkanc*/
		set @iNrDzien  = @nrdzien;
		if  @przekaz <> 'W'
		begin
			if  @ns_typ <> 'K' and @ns_grupa <> 'KO' 
			begin
				if  (@ns_typ = 'B' or @ns_typ = 'P') and @ns_grupa <> 'WOM' 
				begin
					if  @grupa <> @ns_grupa 
					begin
						exec get_nrdzien @ns_grupa, 'W', 'NRDZIEN', 0,@iNrDzien output;
						if  @iNrDzien <= 0 
						begin
							set @lOK = 0
						end
					end
				end
			end
			SET @iNrKanc = @pnrdzien ;
			if  @ns_typ= 'K' and dbo.empty(@pnrdzien) =1
			begin
				exec get_nrdzien '', 'W', 'PNRDZIEN', 0,@iNrKanc output;
				if  @iNrKanc <= 0 
				begin
					set @lOK = 0
				end
			end
		end
		else
		begin
			if  @ns_typ <> 'K'
			begin
				if  @grupa <> @ns_grupa 
				begin
					exec get_nrdzien @ns_grupa, 'P', 'NRDZIEN', 0,@iNrDzien output;
					if  @iNrDzien <= 0 
					begin
						set @lOK = 0
					end
				end
			end
			else
			begin
				set @iNrDzien =  0
			end
			exec get_nrdzien @grupa, 'P', 'IDPISMA', 0,@iIdPisma output;
			if  @iIdPisma <= 0 
			begin
				set @lOK = 0
			end
		end
		if  @iNastepne > 0 and @iNastepne = @nast_stano
		begin
			set @lOK = 0
		end
		if  @iNastepne = -99 and @ns_typ<>'K'
		begin
			set @lOK = 0
		end
		SET @przekaz_ok = @lOK
		if  @lOK = 1
		begin
			if  @przekaz <> 'W' 
			begin
				/*wychodz*/
				update wychodz set aktualnie=@nast_stano,nast_stano=0,nrdzien=@iNrDzien,pnrdzien=@iNrKanc,przekaz=@ns_typ,grupa=(CASE @ns_typ WHEN 'K' THEN @grupa ELSE @ns_grupa END),po_id=@po_next_id,po_next_id=0,datawysl=@dDataWysl where serial_id=@serial_id;
				set @aktualnie  = @nast_stano ;
				set @nast_stano = 0 ;
				set @nrdzien    = @iNrDzien ;
				set @pnrdzien   = @iNrKanc ;
				set @przekaz    = @ns_typ ;
				set @po_id      = @po_next_id ;
				set @po_next_id = 0 ;
				set @datawysl   = null ;
				/*sprawy*/
				if  dbo.empty(@nrsprawy)=0 and upper(dbo.alltrim(@nrsprawy))<>'-BRAK-' 
				begin
					select @iWersja = wersja from sprawy where nr = @nrsprawy;
					update sprawy set wersja = (@iWersja + 1) where nr = @nrsprawy;
				end
			end		
			else
			begin
				/*przychod*/
				exec GetKey 'Przychod',@nId output;
				insert into przychod (idpisma,nrprzesyl,rodzprzes,datapisma,datawplyw,zalatw,aktualnie,rok,kraj_id,maska,kod,czy_zagr,nadwcamie,nadwcaadr,nadwcanaz,dotyczy,nadwcaznk,dokogo,grupa,nrdzien,nrsprawy,serial_id,sp_zakoncz) 
					values (@iIdPisma,@nrdzien,@rodzprzes,@datapisma,current_timestamp,0,@nast_stano,year(current_timestamp),@kraj_id,@maska,@kod,0,@adrsatmie,@adrsatadr,@nadawca,@dotyczy,@nadwcaznk,substring(@adrsarnaz,1,40),@ns_grupa,@iNrDzien,'-brak-',@nId,1);
				/*obieg*/
				insert into obieg (idpisma,nrdzien,grupa,time_,date_stamp,rok,przekaz,Stanowisko,datawplyw) 
					values (@iIdPisma,@nrdzien,@grupa,CONVERT(VARCHAR(13),GetDate(),103),current_timestamp,year(current_timestamp),'W',@iAktualne,current_timestamp);
				/*wychodz*/
				update wychodz set przekaz='V',idprzy=@iIdPisma,nast_stano=0,po_next_id=0,datawysl=@dDataWysl where serial_id=@serial_id;
				set @przekaz    = 'V' ;
				--set @idprzy		= @iIdPisma
				set @nast_stano = 0 ;
				set @po_next_id = 0 ;
				set @datawysl   = @dDataWysl ;
				/*zadania*/
				update zadania set zrobione = 1 where idpisma = @idpisma;
				insert into zadania (idpisma, zrobione) values (@idpisma,0);
			end
		end
		INSERT INTO obiegw (idw,stanowisko,dataprzeka,grupa,nrdzien,zaznacz) VALUES (@idw,@aktualnie,current_timestamp,@grupa,@nrdzien,@lZaznacz );
		insert into @t_wychodz values (@grupa,@pnrdzien,@nrdzien,@aktualnie,@adrsatmie,@adrsatadr,@adrsarnaz,@nadawca,@nadwcaznk,@datapisma,@dotyczy,@nrsprawy,@datawysl,@rodzprzes,@nrprzesyl,@przekaz,@zalatw,@idw,@idpisma,@kod,@kraj_id,@maska,@nast_stano,@po_id,@po_next_id,@serial_id,@nrdzienp,@ns_opis,@ns_typ,@ns_grupa,@przekaz_ok)
		FETCH NEXT FROM c_pismaw INTO  @grupa,@pnrdzien,@nrdzien,@aktualnie,@adrsatmie,@adrsatadr,@adrsarnaz,@nadawca,@nadwcaznk,@datapisma,@dotyczy,@nrsprawy,@datawysl,@rodzprzes,@nrprzesyl,@przekaz,@zalatw,@idw,@idpisma,@kod,@kraj_id,@maska,@nast_stano,@po_id,@po_next_id,@serial_id,@nrdzienp,@ns_opis,@ns_typ,@ns_grupa,@przekaz_ok
	END
	CLOSE c_pismaw
	DEALLOCATE c_pismaw
	select * from @t_wychodz order by grupa,nrdzien
END


