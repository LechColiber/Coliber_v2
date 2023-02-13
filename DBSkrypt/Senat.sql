--update cen.przychod set ggrupa = grupa
--go

--select ggrupa,* from cen.przychod where pnrdzien = 9476
declare @iCnt int
declare @iRows int
SET ROWCOUNT 500

set @iCnt = 0
process_more:
set @iCnt = @iCnt + 1
print @iCnt 
update cen.przychod set sp_zakoncz = 1, pniezalatw = 0 where nrsprawy='-brak-' and (sp_zakoncz <> 1 or pniezalatw <> 0)
set @iRows = @@ROWCOUNT
IF @iRows > 0 GOTO process_more

set @iCnt = 0
process_wych:
set @iCnt = @iCnt + 1
print @iCnt 
update cen.wychodz set sp_zakoncz = 1, pniezalatw = 0 where nrsprawy='-brak-' and (sp_zakoncz <> 1 or pniezalatw <> 0)
set @iRows = @@ROWCOUNT
IF @iRows > 0 GOTO process_wych

SET ROWCOUNT 0
