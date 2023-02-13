begin;
CREATE TABLE dzialania
(
  dz_id int4,
  nazwa varchar(50),
  ukryte bool
) 
WITHOUT OIDS;
ALTER TABLE dzialania OWNER TO postgres;


ALTER TABLE grup_ubez ALTER numer TYPE char(3);

CREATE TABLE prod_ust (
    id_usta int4,
    id_prod int4
);


ALTER TABLE public.prod_ust OWNER TO postgres;

alter table sprawy add column id_oddzialu int4 default 0;
alter table oddzial add column id_stru int4 default 0;
end;

Begin;
drop Table zaposrdn;
end;

begin;
CREATE SEQUENCE zaposrdn_serial_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE zaposrdn_serial_id_seq OWNER TO postgres;
GRANT ALL ON TABLE zaposrdn_serial_id_seq TO postgres;

CREATE TABLE zaposrdn
(
  nazwa varchar(20),
  timestamp_column timestamp,
  serial_id int4 NOT NULL DEFAULT nextval('zaposrdn_serial_id_seq'::regclass),
  nazwad varchar(200),		
  CONSTRAINT zaposrdn_pkey PRIMARY KEY (serial_id)
) 
WITH OIDS;
ALTER TABLE zaposrdn OWNER TO postgres;
GRANT ALL ON TABLE zaposrdn TO postgres;

CREATE TABLE spr_zapo (
    spr_id int4,
    zapo_id int4,
    kolejnosc int2
);


ALTER TABLE public.spr_zapo OWNER TO postgres;

CREATE INDEX idx_spr_zapo_spr_id ON spr_zapo USING btree (spr_id) TABLESPACE pg_default;
end;

begin;
DROP TABLE spr_dzial;
end;

begin;
CREATE TABLE spr_dzial
(
  id int4 not null ,
  spr_id int4,
  dz_id int4,
  data timestamp,
  CONSTRAINT sl_dzialania_pkey PRIMARY KEY (id)
) 
WITHOUT OIDS;
ALTER TABLE spr_dzial OWNER TO postgres;


CREATE INDEX idx_spr_dzial_spr_id
  ON spr_dzial
  USING btree
  (spr_id);
end;
