ALTER TABLE dbo.zaposrdn ADD
	del tinyint NULL,
	kolej_wysw int NULL


CREATE NONCLUSTERED INDEX [idx_sprawy_od] ON [dbo].[sprawy] 
(
	[od] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]

/*
---ten fragment nale�y wykona� na wszystkich schematach !!!
CREATE NONCLUSTERED INDEX [idx_sprawy_stanowisko] ON [dbo].[sprawy] 
(
	[stanowisko] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]



ALTER TABLE [dbo].[sprawy] ADD  CONSTRAINT [sprawy_sprawy_pkey] PRIMARY KEY CLUSTERED 
(
	[serial_id] ASC
)WITH (PAD_INDEX  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO


*/
