CREATE DATABASE postgres OWNER postgres TABLESPACE public;


-- public.city definition

-- Drop table

-- DROP TABLE public.city;

CREATE TABLE public.city (
	id int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT city_pk PRIMARY KEY (id)
);


-- public.tollfreedays definition

-- Drop table

-- DROP TABLE public.tollfreedays;

CREATE TABLE public.tollfreedays (
	id int4 NOT NULL,
	"Date" date NOT NULL,
	cityid int4 NULL,
	CONSTRAINT tollfreedays_pk PRIMARY KEY (id),
	CONSTRAINT tollfreedays_fk FOREIGN KEY (cityid) REFERENCES public.city(id)
);


-- public.maximumamount definition

-- Drop table

-- DROP TABLE public.maximumamount;

CREATE TABLE public.maximumamount (
	id int4 NOT NULL,
	amount int4 NOT NULL,
	cityid int4 NULL,
	CONSTRAINT maximumamount_fk FOREIGN KEY (cityid) REFERENCES public.city(id)
);

INSERT INTO public.city (id,"name") VALUES
	 (1,'Gothenburg');

INSERT INTO public.maximumamount (id,amount,cityid) VALUES
	 (1,60,1);

INSERT INTO public.tollfreedays (id,"Date",cityid) VALUES
	 (1,'2013-01-01',1),
	 (2,'2013-01-06',1),
	 (3,'2013-03-29',1),
	 (4,'2013-03-31',1),
	 (5,'2013-04-01',1),
	 (6,'2013-05-01',1),
	 (7,'2013-05-09',1),
	 (8,'2013-05-19',1),
	 (9,'2013-06-06',1),
	 (10,'2013-06-22',1);
INSERT INTO public.tollfreedays (id,"Date",cityid) VALUES
	 (11,'2013-11-02',1),
	 (12,'2013-12-24',1),
	 (13,'2013-12-25',1),
	 (14,'2013-12-26',1),
	 (15,'2013-12-31',1);
