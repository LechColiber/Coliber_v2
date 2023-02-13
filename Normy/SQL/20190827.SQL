USE [coliber]
GO
CREATE FULLTEXT INDEX ON [dbo].[Normy] KEY INDEX [PK_Normy] ON ([documents_catalog]) WITH (CHANGE_TRACKING AUTO)
GO
USE [coliber]
GO
ALTER FULLTEXT INDEX ON [dbo].[Normy] ADD ([Tytul] LANGUAGE [Neutral])
GO
USE [coliber]
GO
ALTER FULLTEXT INDEX ON [dbo].[Normy] ENABLE
GO


alter table normy add StatusN char(20)
go

update normy set StatusN = 'Aktualna' where Data_uniew is null
go