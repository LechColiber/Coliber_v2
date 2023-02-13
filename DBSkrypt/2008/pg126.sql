use koresp

drop Table dbo.sprawy_imp
go

CREATE TABLE dbo.sprawy_imp
	(
	id int NOT NULL,
	nrog char(40) NOT NULL,
	nazwa_spra char(100) NULL,
	opis text NULL,
	spos_zak char(100) NULL,
	nazwa_kli char(100) NULL,
	imie char(30) NULL,
	adres char(100) NULL,
	miejscow char(50) NULL,
	kod_poczt char(10) NULL,
	inspektora char(50) NULL,
	jedn_teren char(50) NULL,
	oddzial char(50) NULL,
	grup_ubez char(120) NULL,
	data_szkod datetime NULL,
	od datetime NULL,
	data_do datetime NULL,
	przewid datetime NULL,
	stanowisko numeric(8, 0) NULL,
	dot_l_s char(1) NULL,
	rodz_spraw char(100) NULL,
	rwa_symbol char(4) NULL,
	zaposrdn text NULL,
	nr_szkody char(20) NULL,
	rodz_ryz char(120) NULL,
	wlasc_poj char(120) NULL,
	nr_rej char(20) NULL,
	skargana char(250) NULL,
	id_produkt numeric(10, 0) NULL,
	id_g_ustaw numeric(10, 0) NULL,
	prowadzacy char(30) NULL,
	timestamp datetime NULL,
	gr_ub_rzec bit NULL,
	gr_ub_osob bit NULL,
	id_stru numeric(10, 0) NULL,
	nr char(40) NULL,
	kopia int not null ,
	timestamp_column timestamp NOT NULL
	CONSTRAINT
	PK_sprawy_imp PRIMARY KEY CLUSTERED 
	(
	id
	) )  ON [PRIMARY]	 TEXTIMAGE_ON [PRIMARY]
GO


EXECUTE sp_bindefault N'[dbo].[df_zero]', N'[dbo].[sprawy_imp].[kopia]' 

GO

EXECUTE sp_unbindefault N'[dbo].[sprawy].[kopia]'
go
alter table [dbo].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[dbo].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[bia].[sprawy].[kopia]'
go
alter table [bia].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[bia].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[byd].[sprawy].[kopia]'
go
alter table [byd].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[byd].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[cen].[sprawy].[kopia]'
go
alter table [cen].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[cen].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[gda].[sprawy].[kopia]'
go
alter table [gda].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[gda].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[kat].[sprawy].[kopia]'
go
alter table [kat].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[kat].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[kra].[sprawy].[kopia]'
go
alter table [kra].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[kra].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[lod].[sprawy].[kopia]'
go
alter table [lod].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[lod].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[lub].[sprawy].[kopia]'
go
alter table [lub].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[lub].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[opo].[sprawy].[kopia]'
go
alter table [opo].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[opo].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[poz].[sprawy].[kopia]'
go
alter table [poz].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[poz].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[rze].[sprawy].[kopia]'
go
alter table [rze].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[rze].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[szc].[sprawy].[kopia]'
go
alter table [szc].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[szc].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[war].[sprawy].[kopia]'
go
alter table [war].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[war].[sprawy].[kopia]' 
go
EXECUTE sp_unbindefault N'[wro].[sprawy].[kopia]'
go
alter table [wro].[sprawy] alter column kopia int not null 
go
EXECUTE sp_bindefault N'dbo.df_zero', N'[wro].[sprawy].[kopia]' 
go
