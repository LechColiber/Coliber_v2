--select count(serial_id) from sprawy
--select nrog,len(nrog) from dbo.sprawy group by nrog having count(serial_id) > 1

SET QUOTED_IDENTIFIER OFF
SET NOCOUNT ON

declare @cNrOg varchar(40)
declare @cTemp varchar(40)
declare @cSchema char(3)
declare @cSQL varchar(200)
declare @nId int
declare @iDupl int
set @cTemp = '-----'

declare @nIle int
declare @iCnt int
set @nIle = 0
set @iCnt = 0
DECLARE qTemp CURSOR LOCAL FORWARD_ONLY FAST_FORWARD FOR
select nrog,serial_id from dbo.sprawy 
where nrog in (select nrog from dbo.sprawy group by nrog having count(serial_id) > 1) 
order by 1,2
OPEN qTemp
FETCH qTemp INTO @cNrOg,@nId
WHILE (@@fetch_status = 0) 
BEGIN
	if  @nIle = 0
	begin
		begin transaction
	end
	if  @cNrOg <> @cTemp
	begin
		set @cTemp = @cNrOg
		set @iDupl = 0
	end
	set @iDupl = @iDupl + 1
	set @cNrOg = dbo.alltrim(@cNrOg)+CAST(@iDupl as CHAR(1))
	cSchema = dbo.Oddzial(@nId)
	cSQL = "update "+cSchema+".sprawy set nrog = '"+@cNrOg+" where serial_id = "+dbo.Alltrim(CAST(@nId AS CHAR(10)))
	set @nIle = @nIle + 1
	if  @nIle = 1
	begin
		commit
		set @nIle = 0
		set @iCnt = @iCnt + 1
		if  @iCnt % 100 = 0
		begin
			print @iCnt
			print getdate()
		end
	end
	FETCH qTemp INTO @nId
END
if @nIle<>0
begin
	commit
	print @iCnt
	print getdate()
end
CLOSE qTemp
DEALLOCATE qTemp
go
