alter table cen.listauzy add usun_p bit,usun_w bit 
go
update cen.listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table cen.listauzy alter column usun_p bit not null
go
alter table cen.listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[cen].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[cen].[listauzy].[usun_w]' 
go
