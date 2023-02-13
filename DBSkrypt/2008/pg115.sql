
ALTER TABLE oddzial ALTER id_oddzialu TYPE int4;
ALTER TABLE oddzial ALTER COLUMN id_oddzialu SET STATISTICS -1;

CREATE TABLE nrsprawy (
    id int4,
    id_sprawy int4,
    biuro char(5),
    nrs char(40)
);


ALTER TABLE public.nrsprawy OWNER TO postgres;

alter table sprawy add column skargana varchar(250), add column id_produkt int4, add column id_g_ustaw int4, add column gr_ub_rzec bool, add column gr_ub_osob bool, add column  id_stru int4, add column nrog char(40);

CREATE TABLE grup_usta (
    id int4,
    nazwa varchar(120),
    opis text
);
ALTER TABLE public.grup_usta OWNER TO postgres;

CREATE TABLE struorg (
    id_stru int4 ,
    nazwa varchar(60),
    data_od date,
    data_do date,
    aktualna bool
);
ALTER TABLE public.struorg OWNER TO postgres;


drop table bazapust;
drop table bdoprzek;
drop table bdziendo;
drop table bdzienni;
drop table binnewyc;
drop table bkontrol;
drop table bobieg;
drop table bopisrej;
drop table bosoby;
drop table bprze_kl;
drop table bprzycho;
drop table brejestr;
drop table bwychodz;
drop table d_filtry;
drop table stanowiska_biurka_hlp;
drop table stanydok;
drop table stanytab;
drop table sprawy_v_sprawy cascade;

DROP SEQUENCE bazapust_fox_seq;
DROP SEQUENCE bdoprzek_fox_seq;
DROP SEQUENCE bdziendo_fox_seq;
DROP SEQUENCE bdzienni_fox_seq;
DROP SEQUENCE binnewyc_fox_seq;
DROP SEQUENCE bkontrol_fox_seq;
DROP SEQUENCE bobieg_fox_seq;
DROP SEQUENCE bopisrej_fox_seq;
DROP SEQUENCE bosoby_fox_seq;
DROP SEQUENCE bprze_kl_fox_seq;
DROP SEQUENCE bprzycho_fox_seq;
DROP SEQUENCE brejestr_fox_seq;
DROP SEQUENCE bwychodz_fox_seq;
DROP SEQUENCE d_filtry_fox_seq;
DROP SEQUENCE stanydok_fox_seq;
DROP SEQUENCE stanytab_fox_seq;

drop sequence CENNIK_fox_seq;
drop sequence CENNIK1_fox_seq;
drop sequence CENNIKP_fox_seq;
drop sequence DZIENDOS_fox_seq;
drop sequence DZIENNIK_fox_seq;
drop sequence ERRORB_fox_seq;
drop sequence ERRORH_fox_seq;
drop sequence ETY_ATTR_fox_seq;
drop sequence ETY_OBO_fox_seq;
drop sequence ETYKIETY_fox_seq;
drop sequence GLOBVAR_fox_seq;
drop sequence GRUP_UBEZ_fox_seq;
drop sequence GRUPY_fox_seq;
drop sequence HISTHASL_fox_seq;
drop sequence INDEKSY_fox_seq;
drop sequence INNEOPL_fox_seq;
drop sequence INSPEKTORAT_fox_seq;
drop sequence KLUCZE_fox_seq;
drop sequence KLUCZEPU_fox_seq;
drop sequence KONF_fox_seq;
drop sequence KONFETYK_fox_seq;
drop sequence KONTROLE_fox_seq;
drop sequence KRAJE_fox_seq;
drop sequence LIST_NAZW_fox_seq;
drop sequence LISTAPOL_fox_seq;
drop sequence LISTAPRC_fox_seq;
drop sequence LISTAUZY_fox_seq;
drop sequence LOGING_fox_seq;
drop sequence LPOCZT_fox_seq;
drop sequence MAKSY_fox_seq;
drop sequence MAX_DZIE_fox_seq;
drop sequence NADANIA_fox_seq;
drop sequence OBIEG_fox_seq;
drop sequence ODDZIAL_fox_seq;
drop sequence OPCJE_fox_seq;
drop sequence OPISREJE_fox_seq;
drop sequence OPISY_fox_seq;
drop sequence OS_GRU_fox_seq;
drop sequence OSOBY_fox_seq;
drop sequence PRAWA_fox_seq;
drop sequence PRZE_DOK_fox_seq;
drop sequence PRZE_KLU_fox_seq;
drop sequence PRZYCHOD_fox_seq;
drop sequence REJESTR_fox_seq;
drop sequence RODZ_DOK_fox_seq;
drop sequence RODZ_PRAW_fox_seq;
drop sequence RODZ_WYDRUKU_fox_seq;
drop sequence SPRAWY_fox_seq;
drop sequence STRUKTURA_fox_seq;
drop sequence SZKODY_W_fox_seq;
drop sequence UZYTKOWN_fox_seq;
drop sequence WART_ETY_fox_seq;
drop sequence WWYCHODZ_fox_seq;
drop sequence WYCHODZ_fox_seq;
drop sequence WZOR_DOK_fox_seq;
drop sequence ZADANIA_fox_seq;
drop sequence ZAPOSRDN_fox_seq;
drop sequence ZLEHASLA_fox_seq;
drop sequence document_fox_seq;
drop sequence import1_fox_seq;
drop sequence innepol_fox_seq;
drop sequence innewych_fox_seq;
drop sequence karta_fox_seq;
drop sequence kontrole_uz_fox_seq;
drop sequence log_arch_fox_seq;
drop sequence planobi_fox_seq;
drop sequence rwa_fox_seq;
drop sequence sl_dotyczy_fox_seq;
drop sequence slo_klu_fox_seq;
drop sequence spr_prz_fox_seq;
drop sequence ulice_fox_seq;
drop sequence ulice_r_fox_seq;
drop sequence wykaz_fox_seq;
drop sequence wzorzecobiegu_fox_seq;
drop sequence zalatwiona_fox_seq;
