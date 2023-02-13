begin;
CREATE OR REPLACE FUNCTION "month"(pd "timestamp")
  RETURNS int2 AS
$BODY$begin
	if (pd is null) then
		return 0;
	else
		return extract (month from pd);
	end if;
end;$BODY$
  LANGUAGE 'plpgsql' STABLE;
ALTER FUNCTION "month"(pd "timestamp") OWNER TO postgres;
GRANT EXECUTE ON FUNCTION "month"(pd "timestamp") TO public;
GRANT EXECUTE ON FUNCTION "month"(pd "timestamp") TO postgres;
end;

begin;
delete from przychod where nrsprawy ='';
alter table przychod add column sp_zakoncz bool default false, add column pniezalatw int default 0, add column stanowisko int default 0;
ALTER TABLE przychod ALTER COLUMN nrsprawy SET NOT NULL;
ALTER TABLE przychod ADD CONSTRAINT przychod_nrsprawy_chk CHECK (nrsprawy <> '');
ALTER TABLE przychod ALTER COLUMN nrsprawy SET STATISTICS -1;
end;

begin;
delete from wychodz where nrsprawy ='';
alter table wychodz  add column sp_zakoncz bool default false, add column pniezalatw int default 0, add column stanowisko int default 0;
ALTER TABLE wychodz ALTER COLUMN nrsprawy SET NOT NULL;
ALTER TABLE wychodz ADD CONSTRAINT wychodz_nrsprawy_chk CHECK (nrsprawy <> '');
ALTER TABLE wychodz ALTER COLUMN nrsprawy SET STATISTICS -1;
end;


begin;
Delete From sprawy where nr in (select nr from sprawy group by nr having Count(nr) > 1);
alter table sprawy add column sp_zakoncz bool default false, add column pniezalatw int default 0;
ALTER TABLE sprawy ALTER COLUMN nr SET NOT NULL;
ALTER TABLE sprawy ADD CONSTRAINT sprawy_nr_unique UNIQUE (nr) USING INDEX TABLESPACE pg_default;
alter table sprawy add CONSTRAINT sprawy_numer_chk CHECK (nr <> '-brak-'::bpchar AND nr <> ''::bpchar)
ALTER COLUMN nr SET STATISTICS -1;
end;

begin;
CREATE OR REPLACE FUNCTION przychod_dt()
  RETURNS "trigger" AS
$BODY$BEGIN
	delete from zalacz   where idpisma = OLD.idPisma;
	delete from termind  where idpisma = OLD.idPisma;
	delete from hiomylki where idpisma = OLD.idPisma;
	return OLD;
END;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;

ALTER FUNCTION przychod_dt() OWNER TO postgres;
GRANT EXECUTE ON FUNCTION przychod_dt() TO postgres;
GRANT EXECUTE ON FUNCTION przychod_dt() TO public;

CREATE TRIGGER przychod_dt
  AFTER DELETE
  ON przychod
  FOR EACH ROW
  EXECUTE PROCEDURE przychod_dt();

begin;
CREATE OR REPLACE FUNCTION sprawy_dt()
  RETURNS "trigger" AS
$BODY$begin
	delete from spr_dzial where spr_id = OLD.id;
	delete from spr_zapo where spr_id = OLD.id;
	delete from nrsprawy where id_sprawy = OLD.id;
	update przychod set nrsprawy = '-brak-',sp_zakoncz=false,pniezalatw=0,stanowisko=0 where nrsprawy = OLD.nr;
	update wychodz  set nrsprawy = '-brak-',sp_zakoncz=false,pniezalatw=0,stanowisko=0 where nrsprawy = OLD.nr;
	return OLD;
end;$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
ALTER FUNCTION sprawy_dt() OWNER TO postgres;

CREATE OR REPLACE FUNCTION sprawy_it()
  RETURNS "trigger" AS
$BODY$begin
        if  not empty(NEW.nr) and not empty(NEW.grupa) then
			insert into nrsprawy (id,id_sprawy,biuro,nrs) values (0,NEW.id,NEW.grupa,NEW.nr);
        end if ;
	if  not empty(NEW.data_do) then
		NEW.sp_zakoncz = true ;
	end if ;
	update przychod set sp_zakoncz=NEW.sp_zakoncz,pniezalatw=NEW.pniezalatw,stanowisko=NEW.Stanowisko where nrsprawy = NEW.nr;
	update wychodz  set sp_zakoncz=NEW.sp_zakoncz,pniezalatw=NEW.pniezalatw,stanowisko=NEW.Stanowisko where nrsprawy = NEW.nr;
	return NEW;
end;$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
ALTER FUNCTION sprawy_it() OWNER TO postgres;

CREATE OR REPLACE FUNCTION sprawy_ut()
  RETURNS "trigger" AS
$BODY$declare
	zmieniono int;
begin
        if  not empty(NEW.nr) and not empty(NEW.grupa) and NEW.nr <> OLD.nr then
			insert into nrsprawy (id,id_sprawy,biuro,nrs) values (0,NEW.id,NEW.grupa,NEW.nr);
	--		GET DIAGNOSTICS zmieniono = ROW_COUNT;	
	--		raise  notice 'p %', zmieniono;
        end if ;
	if  (empty(OLD.data_do) and not empty(NEW.Data_do)) or (not empty(OLD.data_do) and empty(NEW.Data_do)) then
		if  empty(NEW.data_do) then
			NEW.sp_zakoncz = false;
		else
			NEW.sp_zakoncz = true;
		end if;
	end if;
	if  NEW.nr <> OLD.Nr or NEW.sp_zakoncz <> OLD.sp_zakoncz or NEW.pniezalatw <> OLD.pniezalatw or NEW.Stanowisko <> OLD.Stanowisko then
		update przychod set nrsprawy = NEW.nr,sp_zakoncz=NEW.sp_zakoncz,pniezalatw=NEW.pniezalatw,stanowisko=NEW.Stanowisko where nrsprawy = OLD.nr;
		update wychodz  set nrsprawy = NEW.nr,sp_zakoncz=NEW.sp_zakoncz,pniezalatw=NEW.pniezalatw,stanowisko=NEW.Stanowisko where nrsprawy = OLD.nr;
	end if;	
	return NEW;
end;$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
ALTER FUNCTION sprawy_ut() OWNER TO postgres;
end;

update sprawy set sp_zakoncz = false where empty(data_do);
update sprawy set sp_zakoncz = true where not empty(data_do);
update przychod set stanowisko = 0, sp_zakoncz = false,pniezalatw = 0 where nrsprawy = '-brak-';
update wychodz  set stanowisko = 0, sp_zakoncz = false,pniezalatw = 0 where nrsprawy = '-brak-';

-- uwaga to zapytanie mo¿e trwaæ wiecznoœæ !!!!
-- trzeba go koniecznie jakoœ rozbiæ !!!!
--update sprawy set pniezalatw = (select count(*) from przychod where nrsprawy = sprawy.nr and zalatw = false) + 
--	(select count(*) from wychodz where nrsprawy = sprawy.nr  and zalatw = false)

