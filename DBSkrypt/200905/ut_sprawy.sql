ALTER TRIGGER [cen].[sprawy_ut] on [cen].[sprawy] for UPDATE AS
DECLARE
	@nId int,
    @cNr varchar(40),
	@cOld varchar(40),
    @cGrupa varchar(5),
    @cGrOld varchar(5),
	@iSerial int,
	@spZak bit,
	@spZakOld bit,
	@nIle int,
	@nIleOld int,
	@iSt int,
	@iStOld int,
	@iZapo int,
	@iZapoOld int,
	@tDo datetime,
	@tDoOld datetime,
	@tOd datetime,
	@tOdOld datetime,
	@iVer int,
	@tChk datetime,
	@cNrOg varchar(40)
BEGIN
	set @nIle = @@ROWCOUNT
	if (@nIle > 1 )
	begin
		raiserror('tu_x: @@ROWCOUNT[%d] Trigger does not handle @@ROWCOUNT> 1 !', 17, 127, @nIle) with seterror, nowait
		return
	end
	set nocount on
	--zmienne
	set @tChk = CAST('1901-01-01' as datetime)
	select @iZapoOld = zapo_id,@iVer = wersja,@cOld = nr,@cGrOld=Grupa,@spZakOld = sp_zakoncz,@nIleOld = pniezalatw,@iStOld = stanowisko,@tOdOld=Od,@tDoOld = data_do from deleted 
    select @iZapo = zapo_id,@cNrOg = nrog,@nId=id,@cGrupa=Grupa,@cNr=Nr,@iSerial=serial_id,@spZak=sp_zakoncz,@nIle=pniezalatw,@iSt=stanowisko,@tOd=Od,@tDo=data_do from inserted
	--nrsprawy
	if  dbo.Empty(@cNr)=0 and dbo.Empty(@cGrupa)=0 and @cNr <> @cOld
	begin
		insert into nrsprawy (id,id_sprawy,biuro,nrs) values (0,@nId,@cGrupa,@cNr)
		insert into dbo.nrsprawy (id,id_sprawy,biuro,nrs) values (0,@nId,@cGrupa,@cNr)
	end
	--sprawy.sp_zakoncz
	if  (dbo.empty(@tDoOld)=1 and dbo.empty(@tDo)=0) or (dbo.empty(@tDo)=1 and dbo.empty(@tDoOld)=0)
	begin 
		if  IsNull(@tDo,@tChk)>@tChk
		begin
			set @spZak = 1
		end
		else
		begin
			set @spZak = 0
		end
	end
	-- przesy³ki
	if  @cNr <> @cOld or @spZak <> @spZakOld or @nIle <> @nIleOld or @iSt <> @iStOld
	begin
		update przychod set nrsprawy=@cNr,sp_zakoncz=@spZak,pniezalatw=@nIle,stanowisko=@iSt where nrsprawy = @cOld
		update wychodz  set nrsprawy=@cNr,sp_zakoncz=@spZak,pniezalatw=@nIle,stanowisko=@iSt where nrsprawy = @cOld
	end
	--HistoriaSpr
	if  ((@spZakOld Is Null and @spZak Is Null ) or (@spZakOld = @spZak))
	begin 
		if  @iZapoOld <> @iZapo or @tOd <> @tOdOld or @cNr <> @cOld or @cGrOld <> @cGrupa or @iSt <> @iStOld
		begin
			update dbo.HistoriaSpr set Aktywny = 0 where nrog = @cNrOg and kolejnosc = @iVer
			set @iVer = @iVer + 1
			insert into dbo.HistoriaSpr (id_sprawy,nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog,Aktywny,zaposrdn)
			select i.id,i.nr,i.spos_zak,i.inspektora,i.oddzial,i.od,i.przewid,i.stanowisko,i.data_do,i.id_stru,i.id_oddzialu,i.grupa,i.zapo_id,@iVer,i.nrog,1,i.zaposrdn from inserted i
		end
	end
	else
	begin
		if  (@tDo is null)  and (@tDoOld is not null) and @tOd > @tDoOld
		begin
			set @iVer = @iVer + 1
			insert into dbo.HistoriaSpr (id_sprawy,nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog,Aktywny,zaposrdn)
			select i.id,i.nr,i.spos_zak,i.inspektora,i.oddzial,i.od,i.przewid,i.stanowisko,i.data_do,i.id_stru,i.id_oddzialu,i.grupa,i.zapo_id,@iVer,i.nrog,1,i.zaposrdn from inserted i
		end
		else
		begin
			update h set 
				nrsprawy=i.nr,
				od=i.od,
				przewid=i.przewid,
				data_do=i.data_do,
				spos_zak=i.spos_zak,
				stanowisko=i.stanowisko,
				grupa=i.grupa,
				inspektora=i.inspektora,
				id_stru=i.id_stru,
				id_oddzialu=i.id_oddzialu,
				oddzial=i.oddzial,
				zapo_id=i.zapo_id,
				zaposrdn=i.zaposrdn
			 from inserted i join dbo.HistoriaSpr h on i.nrog = h.nrog and h.kolejnosc = @iVer
		end
	end
	--sprawy
	update sprawy set wersja=@iVer,sp_zakoncz=@SpZak where serial_id = @iSerial
	--dbo.sprawy
	update s set s.nr = i.nr,s.nazwa_spra=i.nazwa_spra,s.opis=i.opis,s.spos_zak=i.spos_zak,s.nazwa_kli=i.nazwa_kli,s.imie=i.imie,s.adres=i.adres,s.miejscow=i.miejscow,s.kod_poczt=i.kod_poczt,s.inspektora=i.inspektora,s.jedn_teren=i.jedn_teren,s.oddzial=i.oddzial,s.grup_ubez=i.grup_ubez,s.data_szkod=i.data_szkod,s.od=i.od,s.przewid=i.przewid,s.stanowisko=i.stanowisko,s.dot_l_s=i.dot_l_s,s.rodz_spraw=i.rodz_spraw,s.rwa_symbol=i.rwa_symbol,s.zaposrdn=i.zaposrdn,s.nr_szkody=i.nr_szkody,s.rodz_ryz=i.rodz_ryz,s.wlasc_poj=i.wlasc_poj,s.nr_rej=i.nr_rej,s.wersja=@iVer,s.id_encoded=i.id_encoded,s.timestamp_column=i.timestamp_column,s.data_do=i.data_do,s.skargana=i.skargana,s.id_produkt=i.id_produkt,s.id_g_ustaw=i.id_g_ustaw,s.gr_ub_rzec=i.gr_ub_rzec,s.gr_ub_osob=i.gr_ub_osob,s.id_stru=i.id_stru,s.nrog=i.nrog,s.id_oddzialu=i.id_oddzialu,s.grupa=i.grupa,s.sp_zakoncz=@SpZak,s.pniezalatw=i.pniezalatw,s.serial_id=i.serial_id,s.zapo_id=i.zapo_id from inserted i join dbo.sprawy s on i.serial_id = s.serial_id
END
go

