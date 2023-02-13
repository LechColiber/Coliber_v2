alter table dzialania add column wybrany bool;

CREATE TABLE profile_gen (
    id int,
    nazwa varchar(60),
    profil bytea,
    id_tworcy int4,
    data_utw timestamp without time zone,
    data_mod timestamp without time zone,
    wspoldziel bool
);


ALTER TABLE public.profile_gen OWNER TO postgres;

CREATE OR REPLACE FUNCTION sprawy_ut()
  RETURNS "trigger" AS
$BODY$declare
	zmieniono int;
begin
	--raise  notice 'on %', OLD.nr;
	--raise  notice 'nn %', NEW.nr;
	--raise  notice 'og %', OLD.grupa;
	--raise  notice 'ng %', NEW.grupa;
        if  not empty(NEW.nr) and not empty(NEW.grupa) and NEW.nr <> OLD.nr then
			insert into nrsprawy (id,id_sprawy,biuro,nrs) values (0,NEW.id,NEW.grupa,NEW.nr);
			update przychod set nrsprawy = NEW.nr where nrsprawy = OLD.nr;
	--		GET DIAGNOSTICS zmieniono = ROW_COUNT;	
	--		raise  notice 'p %', zmieniono;
			update wychodz  set nrsprawy = NEW.nr where nrsprawy = OLD.nr;
	--		GET DIAGNOSTICS zmieniono = ROW_COUNT;	
	--		raise  notice 'w %', zmieniono;
        end if ;
	return NEW;
end;$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
ALTER FUNCTION sprawy_ut() OWNER TO postgres;

CREATE OR REPLACE FUNCTION sprawy_dt()
  RETURNS "trigger" AS
$BODY$begin
	delete from spr_dzial where spr_id = OLD.id;
	delete from spr_zapo where spr_id = OLD.id;
	delete from nrsprawy where id_sprawy = OLD.id;
	update przychod set nrsprawy = '-brak-' where nrsprawy = OLD.nr;
	update wychodz  set nrsprawy = '-brak-' where nrsprawy = OLD.nr;
	return OLD;
end;$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
ALTER FUNCTION sprawy_dt() OWNER TO postgres;