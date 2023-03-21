CREATE TYPE "positions" AS ENUM (
  'tester',
  'programator',
  'support',
  'analytik',
  'obchodnik',
  'ine'
);

CREATE TABLE "Employees" (
  "id" bigserial PRIMARY KEY NOT NULL,
  "first_name" varchar(255) NOT NULL,
  "last_name" varchar(255) NOT NULL,
  "address" varchar(255),
  "date_of_birth" date NOT NULL CONSTRAINT v_minulosti CHECK (date_of_birth < current_date),
  "starting_date" date NOT NULL,
  "salary" decimal(15,2) NOT NULL
);

CREATE TABLE "employees_positions" (
  "id" bigserial PRIMARY KEY NOT NULL,
  "employee_id" bigint,
  "position" positions,
  "started" date,
  "end" date
);

ALTER TABLE "employees_positions" ADD FOREIGN KEY ("employee_id") REFERENCES "Employees" ("id");


CREATE OR REPLACE FUNCTION check_starting_date() RETURNS trigger
	LANGUAGE plpgsql 
	AS $$
	BEGIN
		IF new.starting_date < current_date
		THEN
			RAISE EXCEPTION 'starting date must be greater or equal to current date';
		END IF;
		RETURN NEW;
		
	END;
	$$;

CREATE CONSTRAINT TRIGGER check_date
after insert
on "Employees"
for each row
EXECUTE PROCEDURE check_starting_date();


