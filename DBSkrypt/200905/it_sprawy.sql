ALTER TRIGGER [cen].[sprawy_it] on [cen].[sprawy] for INSERT AS
DECLARE
	@nId int,
    @cNr varchar(40),
    @cGrupa varchar(5),
	@iSerial int,
	@spZak bit,
	@nIle int,
	@iSt int,
	@tDo datetime,
	@tChk datetime,
	@iVer int
BEGIN
	set @nIle = @@ROWCOUNT
	if (@nIle > 1 )
	begin
		raiserror('tu_x: @@ROWCOUNT[%d] Trigger does not handle @@ROWCOUNT> 1 !', 17, 127, @nIle) with seterror, nowait
		return
	end
	set nocount on
	set @iVer = 1
	--zmienne
	set @tChk = CAST('1901-01-01' as datetime)
    select @nId=id,@cGrupa=Grupa,@cNr=Nr,@iSerial=serial_id,@spZak=sp_zakoncz,@nIle=pniezalatw,@iSt=stanowisko,@tDo=data_do from inserted
	--dbo.sprawy
	insert into dbo.sprawy (id,nr,nazwa_spra,opis,spos_zak,nazwa_kli,imie,adres,miejscow,kod_poczt,inspektora,jedn_teren,oddzial,grup_ubez,data_szkod,od,przewid,stanowisko,dot_l_s,rodz_spraw,rwa_symbol,zaposrdn,nr_szkody,rodz_ryz,wlasc_poj,nr_rej,wersja,id_encoded,timestamp_column,data_do,skargana,id_produkt,id_g_ustaw,gr_ub_rzec,gr_ub_osob,id_stru,nrog,id_oddzialu,grupa,sp_zakoncz,pniezalatw,serial_id,zapo_id) select id,nr,nazwa_spra,opis,spos_zak,nazwa_kli,imie,adres,miejscow,kod_poczt,inspektora,jedn_teren,oddzial,grup_ubez,data_szkod,od,przewid,stanowisko,dot_l_s,rodz_spraw,rwa_symbol,zaposrdn,nr_szkody,rodz_ryz,wlasc_poj,nr_rej,@iVer,id_encoded,timestamp_column,data_do,skargana,id_produkt,id_g_ustaw,gr_ub_rzec,gr_ub_osob,id_stru,nrog,id_oddzialu,grupa,sp_zakoncz,pniezalatw,serial_id,zapo_id from inserted
	--nrsprawy
	if  dbo.Empty(@cNr)=0 and dbo.Empty(@cGrupa)=0
	begin
		insert into nrsprawy (id,id_sprawy,biuro,nrs) values (0,@nId,@cGrupa,@cNr)
		insert into dbo.nrsprawy (id,id_sprawy,biuro,nrs) values (0,@nId,@cGrupa,@cNr)
	end
	--przesy³ki
	update przychod set sp_zakoncz=@spZak,pniezalatw=@nIle,stanowisko=@iSt where nrsprawy = @cNr
	update wychodz  set sp_zakoncz=@spZak,pniezalatw=@nIle,stanowisko=@iSt where nrsprawy = @cNr
	--HistoriaSpr
	insert into dbo.HistoriaSpr (id_sprawy,nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog,Aktywny,zaposrdn)
	select i.id,i.nr,i.spos_zak,i.inspektora,i.oddzial,i.od,i.przewid,i.stanowisko,i.data_do,i.id_stru,i.id_oddzialu,i.grupa,i.zapo_id,1,i.nrog,1,i.zaposrdn from inserted i
END


