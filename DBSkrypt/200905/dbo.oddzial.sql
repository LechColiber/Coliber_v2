alter table dbo.oddzial_tab add OddzialOk varchar(50)
GO
update dbo.oddzial_tab set OddzialOK = Nazwa where patindex('%oddzia%',nazwa)=0
GO
update dbo.oddzial_tab set OddzialOK = 'Oddział '+ oddzial where patindex('%oddzia%',nazwa)<>0
GO
ALTER VIEW [dbo].[oddzial]
AS
SELECT		TOP 1000 id_oddzialu, nazwa, del, serial_id, ________pg_dropped_5________, id_stru, oddzial,oddzialok
FROM		dbo.oddzial_tab
ORDER BY	kolejnosc, nazwa
GO