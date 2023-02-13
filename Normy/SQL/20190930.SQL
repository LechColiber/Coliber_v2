
CREATE PROCEDURE [dbo].[SetId]
@cKey varchar(20),
@iNumer int 
AS 
DECLARE @iRec AS int
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION
Update Numery set Numer=@iNumer WHERE Key_ = @cKey
SET @iRec=@@ROWCOUNT
IF (@iRec=0)
BEGIN
    INSERT INTO Numery (Key_,Numer) VALUES (@cKey,1)
    SET @iNumer=1
END
COMMIT

GO


declare @Id int

set @Id = (select max(id_norma) from Normy)
execute SetId 'Normy',@Id

set @Id = (select max(Id_nor_zw) from Normy_zwiazane)
execute SetId 'Normy_zwiazane',@Id

set @Id = (select max(Id_nor_zas) from Normy_zastapione)
execute SetId 'Normy_zastapione',@Id

set @Id = (select max(Id_nor_klu) from Normy_klucz)
execute SetId 'Normy_klucz',@Id

set @Id = (select max(Id_nor_egz) from Normy_egzemplarz)
execute SetId 'Normy_egzemplarz',@Id

set @Id = (select max(Id_nor_dok) from Normy_dokument)
execute SetId 'Normy_dokument',@Id

set @Id = (select max(Id_nor_jezyk) from Normy_jezyk)
execute SetId 'Normy_jezyk',@Id

go

alter table normy_zwiazane alter column Sygnatura varchar(50)
go
alter table normy_zastapione alter column Sygnatura varchar(50)
go
alter table Normy Add Wycofana date null
go
