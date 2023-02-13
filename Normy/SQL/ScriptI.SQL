GO
print 'Normy'
create index idx_Nor_rodz_i on Normy (NOR_RODZ_ID)
create index idx_Nr_normy on Normy (NR_NORMY)
GO
print 'Normy_autor'
create index idx_Nor_nor_id on Normy_autor (NOR_NOR_ID)
create index idx_Id_nor_aut on Normy_autor (ID_NOR_AUT)
GO
print 'Normy_dokument'
create index idx_Dok_dok_id on Normy_dokument (DOK_DOK_ID)
create index idx_Nor_nor_id on Normy_dokument (NOR_NOR_ID)
create index idx_Id_nor_dok on Normy_dokument (ID_NOR_DOK)
GO
print 'Normy_egzemplarz'
create index idx_Nor_nor_id on Normy_egzemplarz (NOR_NOR_ID)
create index idx_Spn_spn_id on Normy_egzemplarz (SPN_SPN_ID)
create index idx_Id_nor_egz on Normy_egzemplarz (ID_NOR_EGZ)
GO
print 'Normy_instytucja'
create index idx_Nor_nor_id on Normy_instytucja (NOR_NOR_ID)
create index idx_Inst_inst_ on Normy_instytucja (INST_INST_ID)
create index idx_Id_nor_in on Normy_instytucja (ID_NOR_IN)
GO
print 'Normy_jezyk'
create index idx_Nor_nor_id on Normy_jezyk (NOR_NOR_ID)
create index idx_Id_nor_jez on Normy_jezyk (ID_NOR_JEZYK)
GO
print 'Normy_klucz'
create index idx_Klu_klu_id on Normy_klucz (KLU_KLU_ID)
create index idx_Nor_nor_id on Normy_klucz (NOR_NOR_ID)
create index idx_Id_nor_klu on Normy_klucz (ID_NOR_KLU)
GO
print 'Normy_rodzaj'
create index idx_Id_rodzaj on Normy_rodzaj (ID_RODZAJ)
GO
print 'Normy_tytul'
create index idx_Nor_nor_id on Normy_tytul (NOR_NOR_ID)
create index idx_Tyt_rodz_i on Normy_tytul (TYT_RODZ_ID)
create index idx_Id_nor_tyt on Normy_tytul (ID_NOR_TYT)
GO
print 'Normy_wydawca'
create index idx_Id_nor_wyd on Normy_wydawca (ID_NOR_WYD)
create index idx_Nor_nor_id on Normy_wydawca (NOR_NOR_ID)
create index idx_Wyd_mwyd_i on Normy_wydawca (WYD_MWYD_ID)
create index idx_Wyd_rodz_i on Normy_wydawca (WYD_RODZ_ID)
create index idx_Wyd_wyd_i on Normy_wydawca (WYD_WYD_ID)
GO
print 'Normy_zastapione'
create index idx_Nor_nor_id on Normy_zastapione (NOR_NOR_ID)
create index idx_Id_nor_zas on Normy_zastapione (ID_NOR_ZAS)
GO
print 'Normy_zwiazane'
create index idx_Nor_nor_id on Normy_zwiazane (NOR_NOR_ID)
create index idx_Id_nor_zw on Normy_zwiazane (ID_NOR_ZW)
GO
