create table Normy (Id_norma int not null identity(1,1), CONSTRAINT PK_Normy PRIMARY KEY CLUSTERED (Id_norma),Dlugosc int,Egzemplarze varchar(254),Format varchar(20),Isbn varchar(20),Isbn2 varchar(20),Jezyki varchar(254),Klucze varchar(254),Nor_rodz_id int,Opis_fizyczny varchar(100),Data_pub date,Tytul varchar(254),Tytuly varchar(512),Uwagi varchar(512),Wydanie varchar(100),Wydawcy varchar(254),Wysokosc int,Zastapione varchar(254),Data_ust date,Nr_normy varchar(50),Data_uniew date)
GO
create table Normy_autor (Aut_aut_id int,Aut_rodz_id int,Id_nor_aut int,Imie varchar(20),Kolejnosc int,Nazwisko varchar(50),Nor_nor_id int)
GO
create table Normy_dokument (Dok_dok_id int,Id_nor_dok int,Nazwa varchar(200),Nor_nor_id int,Opis varchar(512),Sciezka varchar(200),Typ char(3))
GO
create table Normy_egzemplarz (Id_nor_egz int,Inw_inw_id int,Cena decimal(14,2),Data date,Data_udostep date,Kod_kreskowy varchar(20),Nor_nor_id int,Limit_czasu int,Nr_dow_wpl varchar(30),Nr_inwentarzowy int,Nr_teczki varchar(20),Spn_spn_id int,Sygnatura varchar(20),Uwagi varchar(512),Waluta char(5),Wartosc decimal(14,2),Warunki_udostep varchar(512),Zas_gru_id int,Zas_stan_id int,Zas_udo_id int,Zas_zas_id int)
GO
create table Normy_instytucja (Id_nor_in int,Inst_inst_id int,Nazwa varchar(100),Nor_nor_id int,Siedziba varchar(50))
GO
create table Normy_jezyk (Id_nor_jezyk int,Jez_jez_id int,Nazwa char(3),Nor_nor_id int)
GO
create table Normy_klucz (Id_nor_klu int,Klu_klu_id int,Nazwa varchar(150),Nor_nor_id int)
GO
create table Normy_rodzaj (Id_rodzaj int,Nazwa varchar(50))
GO
create table Normy_tytul (Id_nor_tyt int,Nor_nor_id int,Tytul varchar(254),Tyt_rodz_id int)
GO
create table Normy_wydawca (Id_nor_wyd int,Data date,Miejsce varchar(50),Nazwa varchar(254),Akronim varchar(50),Nor_nor_id int,Wyd_mwyd_id int,Wyd_rodz_id int,Wyd_wyd_id int)
GO
create table Normy_zastapione (Id_nor_zas int,Sygnatura varchar(20),Tytul varchar(254),Uwagi varchar(512),Data_uniew date,Nor_nor_id int)
GO
create table Normy_zwiazane (Id_nor_zw int,Sygnatura varchar(20),Tytul varchar(254),Uwagi varchar(512),Nor_nor_id int)
GO
