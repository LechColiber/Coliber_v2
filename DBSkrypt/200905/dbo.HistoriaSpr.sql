
create default [dbo].[df_one] as 1
go
create default [dbo].[df_dt] as GetDate()
go
alter table dbo.sprawy add zapo_id int
go
CREATE TABLE [dbo].[zzTest](
	[info] [varchar](200) COLLATE Polish_CI_AS NULL,
	[ts_column] [datetime] NULL
) ON [PRIMARY]

GO
CREATE PROCEDURE dbo.Log
	-- Add the parameters for the stored procedure here
	@cNapis varchar(100)
AS
BEGIN
	insert into dbo.zzTest values (@cNapis,getdate())
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoriaSpr]') AND type in (N'U'))
DROP TABLE [dbo].[HistoriaSpr]
go
CREATE TABLE [dbo].[HistoriaSpr](
	[id_sprawy] [int] NOT NULL,
	[Kolejnosc] [int] NOT NULL,
	[nrog] [varchar](40) COLLATE Polish_CI_AS NOT NULL,
	[nrsprawy] [varchar](40) COLLATE Polish_CI_AS NULL,
	[od] [datetime] NULL,
	[przewid] [datetime] NULL,
	[data_do] [datetime] NULL,
	[IleDni] [int] NULL,
	[spos_zak] [varchar](100) COLLATE Polish_CI_AS NULL,
	[stanowisko] [int] NULL,
	[grupa] [varchar](5) COLLATE Polish_CI_AS NULL,
	[id_stru] [int] NULL,
	[id_oddzialu] [int] NULL,
	[oddzial] [varchar](50) COLLATE Polish_CI_AS NULL,
	[inspektora] [varchar](50) COLLATE Polish_CI_AS NULL,
	[zapo_id] [int] NULL,
	[zaposrdn] [varchar](250) COLLATE Polish_CI_AS NULL,
	[Opis] [varchar](200) COLLATE Polish_CI_AS NULL,
	[Pomylka] [bit] NOT NULL ,
	[Aktywny] [bit] NOT NULL ,
	[data_op] [datetime] NULL ,
 CONSTRAINT [HistoriaSpr_pkey] PRIMARY KEY CLUSTERED 
(
	[id_sprawy],[kolejnosc] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [idx_HistoriaSpr_NrOg] ON [dbo].[HistoriaSpr] 
(
	[NrOg] ASC
)WITH (PAD_INDEX  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[dbo].[df_zero]', @objname=N'[dbo].[HistoriaSpr].[Aktywny]' 
GO
EXEC sys.sp_bindefault @defname=N'[dbo].[df_zero]', @objname=N'[dbo].[HistoriaSpr].[Pomylka]' 
GO
EXEC sys.sp_bindefault @defname=N'[dbo].[df_dt]', @objname=N'[dbo].[HistoriaSpr].[data_op]' 
GO

