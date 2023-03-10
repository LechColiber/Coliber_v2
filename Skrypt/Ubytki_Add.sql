USE [coliber_wzorzec_multilang]
GO
/****** Object:  StoredProcedure [dbo].[Ubytki_Add]    Script Date: 06/01/2015 16:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Krzysztof Rybka
-- Create date: 2014.01.08
-- Description:	Dodaje ubytki.
-- Parameters:
--				1. @p_BookID int - kod książki
--				2. @p_id_sygnat int - id_sygnat sygnatury
--				3. @p_syg nvarchar(20) - sygnatura
--				4. @p_tytul nvarchar(201) - tytuł ubytku
--				5. @p_volumin nvarchar(6) - wolumin
--				6. @p_numer_inw nvarchar(20) - numer inwentarzowy
--				7. @p_czesci nvarchar(25) - części (numery)
--				8. @p_nr_ksiegi nvarchar(7) - numer księgi ubytku
--				9. @p_nr_dow nvarchar(10) - numer dowodu ubytku
--				10. @p_cena numeric(11,2) - cena (roczna prenumerata - czasopisma)
--				11. @p_data_ubyt datetime - data ubytkowania
--				12. @p_uwagi_u nvarchar(35) - uwagi
--				13. @p_przyczyna numeric(1, 0) - przyczyna ubytkowania:
--					1 – Niezwrócone 
--					2 – Zniszczone
--					3 – Wycofane
--					4 – Zagubione
--					5 – Inne nieuzasadnione
--				14. @p_type int - typ ubytku:
--					1 - książka
--					2 - czasopismo - ewidencja
--					3 - czasopismo - seryjne
-- =============================================
ALTER PROCEDURE [dbo].[Ubytki_Add]
	-- Add the parameters for the stored procedure here	
	@p_BookID int,
	@p_id_sygnat int,
	@p_syg nvarchar(20),
	@p_tytul nvarchar(201),
	@p_volumin nvarchar(6),	
	@p_numer_inw nvarchar(20),
	@p_czesci nvarchar(25),
	@p_nr_ksiegi nvarchar(7),
	@p_nr_dow nvarchar(10),
	@p_cena numeric(11,2),
	@p_data_ubyt datetime,				
	@p_uwagi_u nvarchar(35),
	@p_przyczyna numeric(1, 0),
	@p_id_rodzaj int,
	@p_type int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @p_type = 1
		BEGIN			
			DECLARE @rok_wyd int = (SELECT CASE WHEN rok_wyd IS NOT NULL THEN rok_wyd ELSE 0 END FROM ksiazki_new WHERE kod = @p_BookID);
			DECLARE @autor nvarchar(40) = '';
			
			--(SELECT autor1 + ' ' + imie1 FROM ksiazki WHERE kod = @p_BookID);

			SELECT @p_tytul = tytul_gl FROM ksiazki_new WHERE kod = @p_BookID;
			SELECT @p_cena = cena FROM sygnat WHERE id_sygnat = @p_id_sygnat;

			INSERT INTO ubytki_k (kod, syg, tytul_gl, numer_inw, nr_ksiegi, nr_dow, cena, data_ubyt, uwagi_u, przyczyna, sort_order, id_rodzaj, ilosc, rok_wyd, autor1)
			VALUES (@p_BookID, @p_syg, @p_tytul, @p_numer_inw, @p_nr_ksiegi, @p_nr_dow, @p_cena, @p_data_ubyt, @p_uwagi_u, @p_przyczyna, dbo.FGenerateSortOrderFromSignature(@p_syg), @p_id_rodzaj, 1, @rok_wyd, @autor);

			EXEC Ksiazki_DeleteSignature @p_id_sygnat;
		END
	ELSE IF @p_type = 2
		BEGIN
			DECLARE @rok1 numeric(4,0);
			DECLARE @rok2 numeric(4,0);

			SELECT @rok1 = rok1, @rok2 = ISNULL(rok2, 0) FROM volumes WHERE id_volumes = @p_id_sygnat;

			INSERT INTO ubytki_c (kod, syg, tytul, numer_inw, nr_ksiegi, id_volorser, data_ubyt, volumin, czesci, rocz_pren, przyczyna, nr_dow, uwagi_u, id_rodzaj, sort_order, rok1, rok2)
			VALUES (@p_BookID, @p_syg, @p_tytul, @p_numer_inw, @p_nr_ksiegi, @p_id_sygnat, @p_data_ubyt, @p_volumin, @p_czesci, @p_cena, @p_przyczyna, @p_nr_dow, @p_uwagi_u, @p_id_rodzaj, dbo.FGenerateSortOrderFromSignature(@p_syg), @rok1, @rok2);
			
			EXEC Czasop_DeleteVolumin @p_id_sygnat;
		END
	ELSE IF @p_type = 3
		BEGIN
			DECLARE @rok_ser numeric(4,0);

			SELECT @rok_ser = rok_ser FROM seryjne WHERE id_seryjne = @p_id_sygnat;

			INSERT INTO ubytki_c (kod, syg, tytul, numer_inw, nr_ksiegi, id_volorser, data_ubyt, volumin, czesci, rocz_pren, przyczyna, nr_dow, uwagi_u, id_rodzaj, sort_order, rok1)
			VALUES (@p_BookID, @p_syg, @p_tytul, @p_numer_inw, @p_nr_ksiegi, @p_id_sygnat, @p_data_ubyt, @p_volumin, @p_czesci, @p_cena, @p_przyczyna, @p_nr_dow, @p_uwagi_u, @p_id_rodzaj, dbo.FGenerateSortOrderFromSignature(@p_syg), @rok_ser);
			
			EXEC Czasop_SeryjneDelete @p_id_sygnat;
		END
END

