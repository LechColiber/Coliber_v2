alter table [bia].listauzy add usun_p bit,usun_w bit 
go
update [bia].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [bia].listauzy alter column usun_p bit not null
go
alter table [bia].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[bia].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[bia].[listauzy].[usun_w]' 
go
alter table [byd].listauzy add usun_p bit,usun_w bit 
go
update [byd].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [byd].listauzy alter column usun_p bit not null
go
alter table [byd].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[byd].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[byd].[listauzy].[usun_w]' 
go
alter table [cen].listauzy add usun_p bit,usun_w bit 
go
update [cen].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [cen].listauzy alter column usun_p bit not null
go
alter table [cen].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[cen].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[cen].[listauzy].[usun_w]' 
go
alter table [gda].listauzy add usun_p bit,usun_w bit 
go
update [gda].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [gda].listauzy alter column usun_p bit not null
go
alter table [gda].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[gda].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[gda].[listauzy].[usun_w]' 
go
alter table [kat].listauzy add usun_p bit,usun_w bit 
go
update [kat].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [kat].listauzy alter column usun_p bit not null
go
alter table [kat].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[kat].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[kat].[listauzy].[usun_w]' 
go
go
go
alter table [kra].listauzy add usun_p bit,usun_w bit 
go
update [kra].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [kra].listauzy alter column usun_p bit not null
go
alter table [kra].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[kra].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[kra].[listauzy].[usun_w]' 
go
go
go
alter table [lod].listauzy add usun_p bit,usun_w bit 
go
update [lod].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [lod].listauzy alter column usun_p bit not null
go
alter table [lod].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[lod].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[lod].[listauzy].[usun_w]' 
go
go
go
alter table [lub].listauzy add usun_p bit,usun_w bit 
go
update [lub].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [lub].listauzy alter column usun_p bit not null
go
alter table [lub].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[lub].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[lub].[listauzy].[usun_w]' 
go
go
go
alter table [opo].listauzy add usun_p bit,usun_w bit 
go
update [opo].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [opo].listauzy alter column usun_p bit not null
go
alter table [opo].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[opo].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[opo].[listauzy].[usun_w]' 
go
go
go
alter table [poz].listauzy add usun_p bit,usun_w bit 
go
update [poz].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [poz].listauzy alter column usun_p bit not null
go
alter table [poz].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[poz].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[poz].[listauzy].[usun_w]' 
go
go
go
alter table [rze].listauzy add usun_p bit,usun_w bit 
go
update [rze].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [rze].listauzy alter column usun_p bit not null
go
alter table [rze].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[rze].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[rze].[listauzy].[usun_w]' 
go
go
go
alter table [szc].listauzy add usun_p bit,usun_w bit 
go
update [szc].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [szc].listauzy alter column usun_p bit not null
go
alter table [szc].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[szc].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[szc].[listauzy].[usun_w]' 
go
go
go
alter table [war].listauzy add usun_p bit,usun_w bit 
go
update [war].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [war].listauzy alter column usun_p bit not null
go
alter table [war].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[war].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[war].[listauzy].[usun_w]' 
go
go
go
alter table [wro].listauzy add usun_p bit,usun_w bit 
go
update [wro].listauzy set usun_p = 0,usun_w = 0 where usun_p is null or usun_w is null
go
alter table [wro].listauzy alter column usun_p bit not null
go
alter table [wro].listauzy alter column usun_w bit not null
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[wro].[listauzy].[usun_p]' 
go
EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[wro].[listauzy].[usun_w]' 
go
go
go
