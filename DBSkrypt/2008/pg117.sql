 CREATE INDEX idx_nrsprawy_id_sprawy
   ON nrsprawy USING btree (id_sprawy);

 CREATE SEQUENCE ogolny_nrsprawy_serial_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE ogolny_nrsprawy_serial_id_seq OWNER TO postgres;
GRANT ALL ON TABLE ogolny_nrsprawy_serial_id_seq TO postgres;

alter table sprawy add column  grupa char(5);

CREATE OR REPLACE FUNCTION sprawy_it()
  RETURNS "trigger" AS
$BODY$begin
        if  not empty(NEW.nr) and not empty(NEW.grupa) then
			insert into nrsprawy (id,id_sprawy,biuro,nrs) values (0,NEW.id,NEW.grupa,NEW.nr);
        end if ;
	return NEW;
end;$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
ALTER FUNCTION sprawy_it() OWNER TO postgres;

CREATE OR REPLACE FUNCTION sprawy_ut()
  RETURNS "trigger" AS
$BODY$begin
        if  not empty(NEW.nr) and not empty(NEW.grupa) and NEW.nr <> OLD.nr then
			insert into nrsprawy (id,id_sprawy,biuro,nrs) values (0,NEW.id,NEW.grupa,NEW.nr);
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
	return OLD;
end;$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
ALTER FUNCTION sprawy_dt() OWNER TO postgres;

CREATE TRIGGER sprawy_it
  AFTER INSERT
  ON sprawy
  FOR EACH ROW
  EXECUTE PROCEDURE sprawy_it();

-- Trigger: sprawy_ut on sprawy

-- DROP TRIGGER sprawy_ut ON sprawy;

CREATE TRIGGER sprawy_ut
  AFTER UPDATE
  ON sprawy
  FOR EACH ROW
  EXECUTE PROCEDURE sprawy_ut();

-- Trigger: sprawy_dt on sprawy

-- DROP TRIGGER sprawy_dt ON sprawy;

CREATE TRIGGER sprawy_dt
  AFTER DELETE
  ON sprawy
  FOR EACH ROW
  EXECUTE PROCEDURE sprawy_dt();
