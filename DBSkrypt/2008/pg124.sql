truncate table [dbo].sprawy
GO

alter table [dbo].sprawy alter column opis varchar(2048)
GO
alter table [dbo].sprawy add kopia bit not null
Go
EXECUTE sp_bindefault N'dbo.df_zero', N'[dbo].sprawy.kopia'
Go
ALTER TABLE [dbo].[sprawy] DROP  CONSTRAINT [sprawy_sprawy_pkey] 
GO
ALTER TABLE [dbo].[sprawy] ADD  CONSTRAINT [sprawy_sprawy_pkey] PRIMARY KEY CLUSTERED 
(
	[serial_id] ASC
)WITH (PAD_INDEX  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO



CREATE NONCLUSTERED INDEX [idx_sprawy_od] ON [dbo].[sprawy] 
(
	[od] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [idx_sprawy_stanowisko] ON [dbo].[sprawy] 
(
	[stanowisko] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO
