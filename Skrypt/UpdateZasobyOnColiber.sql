USE [wypozyczalnia_wzorzec_multilang]
GO
/****** Object:  Trigger [dbo].[UpdateZasobyOnColiber]    Script Date: 06/01/2015 18:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[UpdateZasobyOnColiber] ON [dbo].[w2_zasoby_t] 
AFTER UPDATE 
AS

	UPDATE coliber_wzorzec_multilang..zasoby
		SET stan = wypozyczony,
			zewn_akt = 1
		FROM inserted
		WHERE id_zasob = CAST(obcy_id AS INT) AND inserted.zewn_akt = 0;

	DELETE FROM dbo.w2_zamowienia WHERE stan_zamow IN ('0', '3') AND zasob_id IN (SELECT zasob_id FROM deleted WHERE deleted.deleted = 1);

/*
	DECLARE @wypozyczony AS BIT
	DECLARE @obcy_id AS VARCHAR(25)
	DECLARE @zewn_akt AS BIT

	DECLARE i_cursor CURSOR LOCAL FAST_FORWARD FOR
		SELECT wypozyczony, obcy_id, zewn_akt FROM inserted

	OPEN i_cursor

	FETCH NEXT
		FROM i_cursor
		INTO @wypozyczony, @obcy_id, @zewn_akt
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @zewn_akt = 0 -- Jeśli 1, to znaczy, że to uaktualnienie zostało wywołane przez trigger w Colibrze i nie wolno go tam odsyłać, bo się zapętli
			UPDATE coliber_wzorzec..zasoby
				SET stan = @wypozyczony,
					zewn_akt = 1
				WHERE id_zasob = CAST(@obcy_id AS INT)
		FETCH NEXT
			FROM i_cursor
			INTO @wypozyczony, @obcy_id, @zewn_akt
	END

CLOSE i_cursor
DEALLOCATE i_cursor
*/
