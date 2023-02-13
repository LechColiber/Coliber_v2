
use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [cen].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [cen].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [bia].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [bia].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [byd].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [byd].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [gda].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [gda].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [kat].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [kat].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [kra].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [kra].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [lod].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [lod].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [lub].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [lub].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [opo].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [opo].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [poz].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [poz].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [rze].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [rze].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [szc].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [szc].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [war].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [war].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [wlo].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [wlo].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END

use koresp
GO
BEGIN
	declare @nId  int
	declare @nMax int
	declare @iCnt int
	declare @nZapo int
	declare @cNrOg varchar(40)
	set @iCnt = 0
	SET NOCOUNT ON
    declare qSprawy cursor LOCAL FAST_FORWARD for select id,nrog from [wro].sprawy
    open qSprawy
    fetch next from qSprawy into @nId,@cNrOg
    WHILE ((@@FETCH_STATUS = 0) and (@iCnt < 1000))
	begin 
		insert into dbo.HistoriaSpr (nrsprawy,spos_zak,inspektora,oddzial,od,przewid,stanowisko,data_do,id_stru,id_oddzialu,grupa,zapo_id,Kolejnosc,nrog)
		select s.nr,s.spos_zak,s.inspektora,s.oddzial,s.od,s.przewid,s.stanowisko,s.data_do,s.id_stru,s.id_oddzialu,s.grupa,z.zapo_id,z.kolejnosc,s.nrog
		from dbo.spr_zapo z join dbo.sprawy s on s.id = z.spr_id where z.spr_id = @nId
		select @nMax = max(kolejnosc) from dbo.spr_zapo where spr_id = @nId
		update dbo.HistoriaSpr set Aktywny = 1,@nZapo=zapo_id where nrog = @cNrOg and kolejnosc = @nMax
		update [wro].sprawy set wersja = @nMax,zapo_id=@nZapo where id = @nId
		set @iCnt = @iCnt+1
	    fetch next from qSprawy into @nId,@cNrOg
	end
    close qSprawy
    deallocate qSprawy
END
