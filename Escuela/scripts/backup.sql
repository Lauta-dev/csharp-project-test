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
a28dfaf8-6bb3-4069-8ec5-b35f67ecc8e9	1-A
5796e177-7165-417d-8d37-d1956749e0ff	2-A
34f2fed4-d209-47b8-83e0-dfb81b41ca05	3-A
29309f3a-34e2-4b5e-b81f-0c352737e9ec	4-A
f0e46a0f-3d10-4466-9e33-6202bb9b7a93	5-A
fe9dd14b-1560-4cbf-8f4e-274173cbc5ce	6-A
e9353051-d7be-40ae-b2f0-dd1e1536a50e	1-B
1ca642c1-8686-435e-b163-b169d3be5bce	2-B
a3b95a65-fa76-466b-a82e-6cc092462955	3-B
55e34e7a-10e0-43a9-b4ed-e3799a5e9396	4-B
f819a484-4106-492f-8ebe-353a2d267b71	5-B
e25335da-309b-4bb4-9044-de3204fa8279	6-B
\.


--
-- Data for Name: student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student (id, "ClassroomsId", name, last_name, age, fecha_de_nacimiento) FROM stdin;
64c7ecf5-e91f-45bc-80bc-130c0d65b9dd	a28dfaf8-6bb3-4069-8ec5-b35f67ecc8e9	marcos	moodle	21	2002-12-31 21:00:00-03
741e26fa-fbe6-46be-9fc2-80c654e83f6b	a28dfaf8-6bb3-4069-8ec5-b35f67ecc8e9	martin	diaz	24	1999-12-31 21:00:00-03
a8ab8eb6-66c9-4c4b-b995-a82c75e3b2a4	a28dfaf8-6bb3-4069-8ec5-b35f67ecc8e9	exsajasklfjñkajsdlkfjñalsdjkf	pro	44	1979-12-31 21:00:00-03
d96ac2ce-5fa5-4585-a04e-35abe2653f3d	a28dfaf8-6bb3-4069-8ec5-b35f67ecc8e9	mauricio	mugi	26	1997-12-31 21:00:00-03
\.


--
-- Data for Name: task; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.task (id, title, content, important, create_at, limit_at, student_id, teacher_id, classroom_id) FROM stdin;
\.


--
-- Data for Name: teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teacher (id, "ClassroomsId", school_subject, schedule, name, last_name, age, fecha_de_nacimiento) FROM stdin;
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

