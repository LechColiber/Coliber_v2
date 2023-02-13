BEGIN TRAN
BEGIN TRY
    EXEC sp_rename '[Normy].[Id_norma]', 'OldId';

    ALTER TABLE [Normy] ADD Id_norma int NULL

    EXEC ('UPDATE [Normy] SET Id_norma = OldId')

    ALTER TABLE [Normy] NOCHECK CONSTRAINT ALL

    ALTER TABLE [Normy] DROP CONSTRAINT [PK_Normy];
    ALTER TABLE [Normy] DROP COLUMN OldId
    ALTER TABLE [Normy] ALTER COLUMN [Id_norma] INTEGER NOT NULL
    ALTER TABLE [Normy] ADD CONSTRAINT PK_Normy PRIMARY KEY (Id_norma)

    ALTER TABLE [Normy] CHECK CONSTRAINT ALL

    COMMIT TRAN
END TRY
BEGIN CATCH
    ROLLBACK TRAN  
    SELECT ERROR_MESSAGE ()
END CATCH
GO

DROP INDEX [idx_Id_nor_klu] ON [dbo].[Normy_klucz]
GO
Alter table dbo.Normy_klucz alter column id_nor_klu int not null
GO
Alter table dbo.Normy_klucz ADD Primary Key (id_nor_klu)
GO
CREATE NONCLUSTERED INDEX [idx_Id_nor_klu] ON [dbo].[Normy_klucz]
(
    [Id_nor_klu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

DROP INDEX [idx_Id_nor_zw] ON [dbo].[Normy_zwiazane]
GO
Alter table dbo.Normy_zwiazane alter column id_nor_zw int not null
GO
Alter table dbo.Normy_zwiazane ADD Primary Key (id_nor_zw)
GO
CREATE NONCLUSTERED INDEX [idx_Id_nor_zw] ON [dbo].[Normy_zwiazane]
(
    [Id_nor_zw] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

DROP INDEX [idx_Id_nor_zas] ON [dbo].[Normy_zastapione]
GO
Alter table dbo.Normy_zastapione alter column id_nor_zas int not null
GO
Alter table dbo.Normy_zastapione ADD Primary Key (id_nor_zas)
GO
CREATE NONCLUSTERED INDEX [idx_Id_nor_zas] ON [dbo].[Normy_zastapione]
(
    [Id_nor_zas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

DROP INDEX [idx_id_nor_jez] ON [dbo].[Normy_jezyk]
GO
DROP INDEX [idx_id_nor_jezyk] ON [dbo].[Normy_jezyk]
GO
Alter table dbo.Normy_jezyk alter column id_nor_jezyk int not null
GO
Alter table dbo.Normy_jezyk ADD Primary Key (id_nor_jezyk)
GO
CREATE NONCLUSTERED INDEX [idx_id_nor_jezyk] ON [dbo].[Normy_jezyk]
(
    [id_nor_jezyk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

DROP INDEX [idx_id_nor_egz] ON [dbo].[Normy_egzemplarz]
GO
Alter table dbo.Normy_egzemplarz alter column id_nor_egz int not null
GO
Alter table dbo.Normy_egzemplarz ADD Primary Key (id_nor_egz)
GO
CREATE NONCLUSTERED INDEX [idx_id_nor_egz] ON [dbo].[Normy_egzemplarz]
(
    [id_nor_egz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

alter table normy_jezyk alter column nazwa char(25) not null
GO

CREATE TABLE [dbo].[Numery](
    [Key_] [varchar](20) NULL,
    [Numer] [int] NULL
) ON [PRIMARY]

GO

CREATE PROCEDURE [dbo].[GetId]
@cKey varchar(20),
@iNumer int OUTPUT
AS 
DECLARE @iRec AS int
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION
Update Numery set @iNumer=Numer+1,Numer=@iNumer WHERE Key_ = @cKey
SET @iRec=@@ROWCOUNT
IF (@iRec=0)
BEGIN
    INSERT INTO Numery (Key_,Numer) VALUES (@cKey,1)
    SET @iNumer=1
END
COMMIT

GO


