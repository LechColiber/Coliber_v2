drop table [cen].zzTest
go
alter table [cen].sprawy add zapo_id int
go
EXEC sys.sp_bindefault @defname=N'dbo.df_one', @objname=N'[cen].[sprawy].[wersja]' 
go

