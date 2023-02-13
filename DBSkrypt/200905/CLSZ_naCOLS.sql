/*
--select * from cen.nrsprawy where biuro = 'BLS'
update cen.nrsprawy set biuro='BLSiå' where biuro = 'BLS'
print 'nrsprawy'
go
--select * from cen.karta where biuro = 'BLS'
update cen.karta set biuro='BLSiå' where biuro = 'BLS'
print 'karta'
go
--select * from cen.kontrole where biuro = 'BLS'
update cen.kontrole set biuro='BLSiå' where biuro = 'BLS'
print 'kontrole'
go
--select * from cen.listaprc where biuro = 'BLS'
update cen.listaprc set biuro='BLSiå' where biuro = 'BLS'
print 'listaprac'
go
--select * from cen.t_global_uzyt_i_stanow where ggrupa = 'BLS'
update cen.t_global_uzyt_i_stanow set ggrupa='BLSiå' where ggrupa = 'BLS'
print 't_global...'
go
--select * from cen.listauzy where ggrupa = 'BLS'
update cen.listauzy set ggrupa='BLSiå' where ggrupa = 'BLS'
print 'listauzy'
go
--select * from cen.list_nazw where ggrupa = 'BLS'
update cen.list_nazw set ggrupa='BLSiå' where ggrupa = 'BLS'
print 'list|_nazw'
go
--select * from cen.osoby where grupa = 'BLS'
update cen.osoby set grupa='BLSiå' where grupa = 'BLS'
print 'osoby'
go
--select * from cen.obiegw where grupa = 'BLS'
update cen.obiegw set grupa='BLSiå' where grupa = 'BLS'
print 'obiegw'
go
--select * from cen.rejestr where grupa = 'BLS'
update cen.rejestr set grupa='BLSiå' where grupa = 'BLS'
print 'rejestr'
go
--select * from cen.opisreje where grupa = 'BLS'
update cen.opisreje set grupa='BLSiå' where grupa = 'BLS'
print 'opisreje'
go
--select * from cen.sl_dotyczy where grupa = 'BLS'
update cen.sl_dotyczy set grupa='BLSiå' where grupa = 'BLS'
print 'sl_dotyczy'
go
--select * from cen.struktura where grupa = 'BLS'
update cen.struktura set grupa='BLSiå' where grupa = 'BLS'
print 'struktura'
go
--select * from cen.wwychodz where grupa = 'BLS'
update cen.wwychodz set grupa='BLSiå' where grupa = 'BLS'
print 'wwychodz'
go
--select * from cen.grupy where grupa = 'BLS'
update cen.grupy set grupa='BLSiå' where grupa = 'BLS'
print 'grupy'
go
--select * from cen.przychod where ggrupa = 'BLS'
update cen.przychod set ggrupa='BLSiå' where ggrupa = 'BLS'
print 'przychod'
go
--select * from cen.wychodz where grupa = 'BLS'
update cen.wychodz set grupa='BLSiå' where grupa = 'BLS'
print 'wychodz'
go
--select * from cen.inneopl where grupa = 'BLS'
update cen.inneopl set grupa='BLSiå' where grupa = 'BLS'
print 'inneopl'
go
--select * from cen.innepol where grupa = 'BLS'
update cen.innepol set grupa='BLSiå' where grupa = 'BLS'
print 'innepol'
go
--select * from cen.innewych where grupa = 'BLS'
update cen.innewych set grupa='BLSiå' where grupa = 'BLS'
print 'innewych'
go
--select * from cen.obieg where grupa = 'BLS'
update cen.obieg set grupa='BLSiå' where grupa = 'BLS'
print 'obieg'
go
--select * from cen.listauzy where grupa = 'BLS'
update cen.listauzy set grupa='BLSiå' where grupa = 'BLS'
print 'listauzy'
go
--select * from dbo.nrsprawy where biuro = 'BLS'
update dbo.nrsprawy set biuro='BLSiå' where biuro = 'BLS'
print 'dbo.nrsprawy'
go
--select * from dbo.HistoriaSpr where grupa = 'BLS'
update dbo.HistoriaSpr set grupa='BLSiå' where grupa = 'BLS'
print 'HistoriaSpr'
go
--select * from dbo.sprawy where grupa = 'BLS'
update dbo.sprawy set grupa='BLSiå' where grupa = 'BLS'
print 'dbo.sprawy'
go
*/


-- select * from cen.sprawy where grupa = 'BLS'
-- uwaga !!!, bardzo d≥ugo trwa
-- ale trigger uniemozliwia wykonanie instrukcji
-- --update cen.sprawy set grupa='BLSiå' where grupa = 'BLS'

SET QUOTED_IDENTIFIER OFF
SET NOCOUNT ON
declare @iId int
declare @nIle int
declare @iCnt int
set @nIle = 0
set @iCnt = 0
DECLARE qSprawy CURSOR LOCAL FORWARD_ONLY FAST_FORWARD FOR
select id from cen.sprawy where grupa = 'COLS'
OPEN qSprawy
FETCH qSprawy INTO @iId
WHILE (@@fetch_status = 0) 
BEGIN
	if  @nIle = 0
	begin
		begin transaction
	end
	update cen.sprawy set grupa = 'COLSå' where id = @iId
		set @nIle = @nIle + 1
	if  @nIle = 100
	begin
		commit
		set @nIle = 0
		set @iCnt = @iCnt + 1
		print @iCnt
		print getdate()
	end
	FETCH qSprawy INTO @iId
END
if @nIle<>0
begin
	commit
	print @iCnt
	print getdate()
	print @nIle
end
CLOSE qSprawy
DEALLOCATE qSprawy
go
