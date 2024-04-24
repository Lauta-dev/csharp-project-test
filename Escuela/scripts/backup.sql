--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: mood; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE public.mood AS ENUM (
    'sad',
    'ok',
    'happy'
);


ALTER TYPE public.mood OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Name: classrooms; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.classrooms (
    id text NOT NULL,
    classroom text NOT NULL
);


ALTER TABLE public.classrooms OWNER TO postgres;

--
-- Name: student; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student (
    id text NOT NULL,
    "ClassroomsId" text NOT NULL,
    name text NOT NULL,
    last_name text NOT NULL,
    age integer NOT NULL,
    fecha_de_nacimiento timestamp with time zone NOT NULL
);


ALTER TABLE public.student OWNER TO postgres;

--
-- Name: task; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.task (
    id text NOT NULL,
    title text NOT NULL,
    content text NOT NULL,
    important integer NOT NULL,
    create_at timestamp with time zone NOT NULL,
    limit_at timestamp with time zone NOT NULL,
    student_id text NOT NULL,
    teacher_id text NOT NULL,
    classroom_id text NOT NULL
);


ALTER TABLE public.task OWNER TO postgres;

--
-- Name: teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teacher (
    id text NOT NULL,
    "ClassroomsId" text NOT NULL,
    school_subject text NOT NULL,
    schedule timestamp with time zone NOT NULL,
    name text NOT NULL,
    last_name text NOT NULL,
    age integer NOT NULL,
    fecha_de_nacimiento timestamp with time zone NOT NULL
);


ALTER TABLE public.teacher OWNER TO postgres;

--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20240324131456_123	8.0.2
20240328231222_newa	8.0.2
20240329003013_new	8.0.2
20240329004729_new	8.0.2
20240330002839_abc	8.0.2
20240331233216_abc	8.0.2
20240401183259_123	8.0.2
20240401183723_abc	8.0.2
20240401184017_abcd	8.0.2
20240401184226_abce	8.0.2
20240401184401_abcf	8.0.2
20240401184546_abcfe	8.0.2
20240401184650_abcfe	8.0.2
20240401185131_abcfe	8.0.2
20240401185315_abcfe	8.0.2
20240401185506_abcfe	8.0.2
20240401185901_abcfe	8.0.2
20240401190026_abcfe	8.0.2
20240401190545_abcfe	8.0.2
20240401190851_abcfe	8.0.2
20240401191039_abcfe1	8.0.2
20240401191211_abcfe_v2	8.0.2
20240401191522_abcfe_v3	8.0.2
20240402182942_abcdefg	8.0.2
20240402183335_abcdefg	8.0.2
20240402184300_abc	8.0.2
20240403151215_addTeacherAndStudentTask	8.0.2
20240403185650_teacherTableRes	8.0.2
20240403190007_teacherTableRe	8.0.2
20240403190146_teacherTableRe	8.0.2
20240403190716_corijoTeacheTbl	8.0.2
20240403192811_idToGui	8.0.2
20240403232229_fafa	8.0.2
20240403233511_faf	8.0.2
20240405003724_abc	8.0.2
20240405153945_aaddad	8.0.2
20240405154927_aaad	8.0.2
20240405155049_aad	8.0.2
20240405155340_ad	8.0.2
20240405203712_ad11	8.0.2
20240406004928_Abc	8.0.2
20240408155453_f	8.0.2
20240408155740_tuki	8.0.2
\.


--
-- Data for Name: classrooms; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.classrooms (id, classroom) FROM stdin;
3fc953d4-8d67-4b07-9a29-0f626f209ed7	6-A
c96c045c-de98-49c6-8a32-674dc7e03d14	2-A
ce39c707-c830-4de2-8c3b-3e0d534dcbdc	3-A
d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	1-A
da0df677-cafa-4495-969a-0e5444a703cb	4-A
eaf13192-b53a-467a-8766-5d3ebb1436d9	5-A
\.


--
-- Data for Name: student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student (id, "ClassroomsId", name, last_name, age, fecha_de_nacimiento) FROM stdin;
7e8f304e-2d72-4839-b1e0-55cb5302f1e8	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	J	Wulen	44	1979-12-31 21:00:00-03
8814894b-5972-42ab-b740-025c93754c81	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Diegito	Bari	24	1999-12-31 21:00:00-03
b2de8cfe-2207-48c4-b10d-844124f8e9f8	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Lautaro	Diaz	21	2002-12-31 21:00:00-03
fcd68805-9fc1-4019-ada2-d031354bba66	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Baity	Byte	26	1997-12-31 21:00:00-03
\.


--
-- Data for Name: task; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.task (id, title, content, important, create_at, limit_at, student_id, teacher_id, classroom_id) FROM stdin;
b772a837-1c28-4fb8-b368-530da1c3ada6	React	Creación de una web app para ver el tiempo	0	2024-04-23 11:52:35.453-03	2024-04-26 11:52:00-03	7e8f304e-2d72-4839-b1e0-55cb5302f1e8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
d7f78de5-93a5-4539-b2db-deb5560be0b1	JavaScript	Feching de datos	0	2024-04-23 11:52:35.453-03	2024-05-09 11:52:00-03	7e8f304e-2d72-4839-b1e0-55cb5302f1e8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
f936d2ac-c26c-410f-ad0f-1d53bd7be0e3	Bash	Crear un script de Bash para controlar el volumen del equipo usando el comando `pamixer`	0	2024-04-23 11:52:35.453-03	2024-04-30 11:52:00-03	7e8f304e-2d72-4839-b1e0-55cb5302f1e8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
386ff583-02c8-451d-9e36-77654131458d	React	Creación de una web app para ver el tiempo	0	2024-04-23 11:52:35.453-03	2024-04-26 11:52:00-03	b2de8cfe-2207-48c4-b10d-844124f8e9f8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
a80ec428-564a-4f7b-a05a-f23a0cd9991c	Bash	Crear un script de Bash para controlar el volumen del equipo usando el comando `pamixer`	0	2024-04-23 11:52:35.453-03	2024-04-30 11:52:00-03	b2de8cfe-2207-48c4-b10d-844124f8e9f8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
bd3904f3-7b10-4f46-9828-7cc3d1debd3c	JavaScript	Feching de datos	0	2024-04-23 11:52:35.453-03	2024-05-09 11:52:00-03	fcd68805-9fc1-4019-ada2-d031354bba66	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
58f1c3a9-4536-43ec-8312-858724343ca1	JavaScript en el navegador	Crea un boton rojo desde JavaScript manipulando el dom	0	2024-04-23 11:52:35.453-03	2024-05-09 11:52:00-03	fcd68805-9fc1-4019-ada2-d031354bba66	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
5df91d0e-5116-4356-aec4-11680408f13e	Poo con Lua	Usa los conceptos basicos de POO en Lua	0	2024-04-23 11:52:35.453-03	2024-04-30 11:52:00-03	b2de8cfe-2207-48c4-b10d-844124f8e9f8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
987d5640-f21a-481e-9b8f-192ce0bb60bc	Explicación y compresion sobre GNU	Linux y GNU/Linux son lo mismo	0	2024-04-23 11:52:35.453-03	2024-04-26 11:52:00-03	b2de8cfe-2207-48c4-b10d-844124f8e9f8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
72d61543-ed43-4475-99ae-6f2a65c3e1e9	JavaScript en el navegador	Crea un boton rojo desde JavaScript manipulando el dom	0	2024-04-23 11:52:35.453-03	2024-05-09 11:52:00-03	fcd68805-9fc1-4019-ada2-d031354bba66	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
dafcd2b9-8556-450f-b2fd-90533b3d79b3	Poo con Lua	Usa los conceptos basicos de POO en Lua	0	2024-04-23 11:52:35.453-03	2024-04-26 11:52:00-03	b2de8cfe-2207-48c4-b10d-844124f8e9f8	a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b
\.


--
-- Data for Name: teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teacher (id, "ClassroomsId", school_subject, schedule, name, last_name, age, fecha_de_nacimiento) FROM stdin;
a800c720-92f6-4e9e-b8bb-f6da8dc62af4	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Informatica	2024-04-22 09:37:00-03	asd	moodle	12	2024-04-08 12:05:05.699-03
de7798d1-3320-4bbe-b833-54fda7900d22	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Informatica	2024-04-22 09:37:00-03	Mario	Correa	23	2024-04-08 12:05:05.699-03
15996bb2-e047-42a3-a671-09694cc909f8	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Informatica	2024-04-22 09:37:00-03	Thiago	Correa	23	2024-04-08 12:05:05.699-03
a7aa432a-d006-4578-9673-b9837ef3ca79	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Informatica	2024-04-22 09:37:00-03	Facundo	Diaz	25	2024-04-08 12:05:05.699-03
f911b68f-6d7e-4856-9013-5e6181785948	d7fbbe3f-e107-4ad0-914a-a30d6a741c8b	Informatica	2024-04-22 09:37:00-03	Jorde	Correa	20	2024-04-08 12:05:05.699-03
\.


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: classrooms PK_classrooms; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.classrooms
    ADD CONSTRAINT "PK_classrooms" PRIMARY KEY (id);


--
-- Name: student PK_student; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT "PK_student" PRIMARY KEY (id);


--
-- Name: task PK_task; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT "PK_task" PRIMARY KEY (id);


--
-- Name: teacher PK_teacher; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT "PK_teacher" PRIMARY KEY (id);


--
-- Name: IX_student_ClassroomsId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_student_ClassroomsId" ON public.student USING btree ("ClassroomsId");


--
-- Name: IX_task_classroom_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_task_classroom_id" ON public.task USING btree (classroom_id);


--
-- Name: IX_task_student_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_task_student_id" ON public.task USING btree (student_id);


--
-- Name: IX_task_teacher_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_task_teacher_id" ON public.task USING btree (teacher_id);


--
-- Name: IX_teacher_ClassroomsId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_teacher_ClassroomsId" ON public.teacher USING btree ("ClassroomsId");


--
-- Name: student FK_student_classrooms_ClassroomsId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT "FK_student_classrooms_ClassroomsId" FOREIGN KEY ("ClassroomsId") REFERENCES public.classrooms(id) ON DELETE CASCADE;


--
-- Name: task FK_task_classrooms_classroom_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT "FK_task_classrooms_classroom_id" FOREIGN KEY (classroom_id) REFERENCES public.classrooms(id) ON DELETE CASCADE;


--
-- Name: task FK_task_student_student_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT "FK_task_student_student_id" FOREIGN KEY (student_id) REFERENCES public.student(id) ON DELETE CASCADE;


--
-- Name: task FK_task_teacher_teacher_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT "FK_task_teacher_teacher_id" FOREIGN KEY (teacher_id) REFERENCES public.teacher(id) ON DELETE CASCADE;


--
-- Name: teacher FK_teacher_classrooms_ClassroomsId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT "FK_teacher_classrooms_ClassroomsId" FOREIGN KEY ("ClassroomsId") REFERENCES public.classrooms(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

