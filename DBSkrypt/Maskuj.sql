set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[maskuj] 
(
	@co varchar(20),
	@jak varchar(20)
)
RETURNS varchar(20)
AS
BEGIN
	DECLARE @Result varchar(10)
	declare @cZnak char(1)
	declare @j int
	declare @c int

	set @Result = ''
	set @j = 1
	set @c = 1

	IF  dbo.empty(@jak)=1
	begin
		return @co
	end
	IF  dbo.Empty(@co)=1
	begin
		return ''
	end
	WHILE @j <= LEN(@jak)
	begin
		IF  SUBSTRING(@jak,@j,1) = '9' OR SUBSTRING(@jak,@j,1) = 'X'
		begin
			set @Result = @Result + (CASE WHEN LEN(@co)>=@c THEN SUBSTRING(@co,@c,1)ELSE ' ' END)
			set @c = @c + 1
		end
		ELSE
		begin
			set @Result = @Result + (CASE WHEN LEN(@co)>=@c THEN SUBSTRING(@jak,@j,1) ELSE ' ' END)
		end
		set @j = @j + 1
	END 
	RETURN @Result
END

