DROP INDEX [idx_dok_dok_Id] ON [dbo].[Normy_dokument]
GO
DROP INDEX [idx_id_nor_dok] ON [dbo].[Normy_dokument]
GO
Alter table dbo.Normy_dokument alter column id_nor_dok int not null 
GO
Alter table dbo.Normy_dokument drop column [dok_dok_id]
GO
Alter table dbo.Normy_dokument ADD Primary Key (id_nor_dok)
GO
CREATE NONCLUSTERED INDEX [idx_id_nor_dok] ON [dbo].[Normy_dokument]
(
    [id_nor_dok] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[normy_dokument] ADD [UI] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL UNIQUE DEFAULT (newid())
GO
ALTER TABLE [dbo].[normy_dokument] ADD [plik] [varbinary](max) FILESTREAM 
GO