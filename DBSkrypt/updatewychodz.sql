SET NOCOUNT ON
declare @iCnt int
--	zmienne programu
declare @grupa  varchar(5)
declare @kgrupa varchar(5)
declare @ggrupa varchar(5)
declare @nId int
--  koniec 
DECLARE qTabele CURSOR LOCAL FORWARD_ONLY FAST_FORWARD FOR
select grupa,kgrupa,serial_id from cen.wychodz

OPEN qTabele
FETCH qTabele INTO @grupa,@kgrupa,@nId
set @iCnt = 0
begin transaction
WHILE (@@fetch_status = 0) 
BEGIN
	if (dbo.empty(@kgrupa)=1) set @kgrupa=@grupa
	select top 1 @ggrupa = ggrupa from cen.listauzy where grupa = @grupa
	if (@ggrupa<>@grupa) update cen.wychodz set kgrupa=@kgrupa where serial_id = @nId
	set @iCnt = @iCnt + 1
	if  (@iCnt%100=0)
	begin
		commit
		print @iCnt
		print convert(NVARCHAR(30),GETDATE(),121)
		begin transaction
	end
	FETCH qTabele INTO @grupa,@kgrupa,@nId
END
commit
print @iCnt
CLOSE qTabele
DEALLOCATE qTabele
