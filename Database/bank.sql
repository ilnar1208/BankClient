--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3 (Debian 16.3-1.pgdg120+1)
-- Dumped by pg_dump version 16.3

-- Started on 2024-07-01 15:07:54

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
-- TOC entry 3385 (class 1262 OID 16384)
-- Name: bank; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE bank WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE bank OWNER TO postgres;

\connect bank

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
-- TOC entry 6 (class 2615 OID 16389)
-- Name: bank_client; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA bank_client;


ALTER SCHEMA bank_client OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 222 (class 1259 OID 32770)
-- Name: account_type; Type: TABLE; Schema: bank_client; Owner: postgres
--

CREATE TABLE bank_client.account_type (
    id bigint NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE bank_client.account_type OWNER TO postgres;

--
-- TOC entry 3386 (class 0 OID 0)
-- Dependencies: 222
-- Name: TABLE account_type; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON TABLE bank_client.account_type IS 'Тип счета';


--
-- TOC entry 3387 (class 0 OID 0)
-- Dependencies: 222
-- Name: COLUMN account_type.id; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client.account_type.id IS 'Идентификатор';


--
-- TOC entry 3388 (class 0 OID 0)
-- Dependencies: 222
-- Name: COLUMN account_type.name; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client.account_type.name IS 'Наименование';


--
-- TOC entry 221 (class 1259 OID 32769)
-- Name: account_type_id_seq; Type: SEQUENCE; Schema: bank_client; Owner: postgres
--

CREATE SEQUENCE bank_client.account_type_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE bank_client.account_type_id_seq OWNER TO postgres;

--
-- TOC entry 3389 (class 0 OID 0)
-- Dependencies: 221
-- Name: account_type_id_seq; Type: SEQUENCE OWNED BY; Schema: bank_client; Owner: postgres
--

ALTER SEQUENCE bank_client.account_type_id_seq OWNED BY bank_client.account_type.id;


--
-- TOC entry 217 (class 1259 OID 16391)
-- Name: user; Type: TABLE; Schema: bank_client; Owner: postgres
--

CREATE TABLE bank_client."user" (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    surname character varying(100) NOT NULL,
    patronymic character varying(100),
    phone_number character varying(20) NOT NULL,
    password character varying(128) NOT NULL,
    salt character varying(50) NOT NULL
);


ALTER TABLE bank_client."user" OWNER TO postgres;

--
-- TOC entry 3390 (class 0 OID 0)
-- Dependencies: 217
-- Name: TABLE "user"; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON TABLE bank_client."user" IS 'Пользователь';


--
-- TOC entry 3391 (class 0 OID 0)
-- Dependencies: 217
-- Name: COLUMN "user".id; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client."user".id IS 'Идентификатор';


--
-- TOC entry 3392 (class 0 OID 0)
-- Dependencies: 217
-- Name: COLUMN "user".name; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client."user".name IS 'Имя';


--
-- TOC entry 3393 (class 0 OID 0)
-- Dependencies: 217
-- Name: COLUMN "user".surname; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client."user".surname IS 'Фамилия';


--
-- TOC entry 3394 (class 0 OID 0)
-- Dependencies: 217
-- Name: COLUMN "user".patronymic; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client."user".patronymic IS 'Отчество';


--
-- TOC entry 3395 (class 0 OID 0)
-- Dependencies: 217
-- Name: COLUMN "user".phone_number; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client."user".phone_number IS 'Номер телефона';


--
-- TOC entry 3396 (class 0 OID 0)
-- Dependencies: 217
-- Name: COLUMN "user".password; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client."user".password IS 'Пароль';


--
-- TOC entry 3397 (class 0 OID 0)
-- Dependencies: 217
-- Name: COLUMN "user".salt; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client."user".salt IS 'Соль';


--
-- TOC entry 220 (class 1259 OID 16401)
-- Name: user_account; Type: TABLE; Schema: bank_client; Owner: postgres
--

CREATE TABLE bank_client.user_account (
    id bigint NOT NULL,
    user_id bigint NOT NULL,
    account_number character varying(20) NOT NULL,
    account_type_id bigint NOT NULL
);


ALTER TABLE bank_client.user_account OWNER TO postgres;

--
-- TOC entry 3398 (class 0 OID 0)
-- Dependencies: 220
-- Name: TABLE user_account; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON TABLE bank_client.user_account IS 'Счет пользователя';


--
-- TOC entry 3399 (class 0 OID 0)
-- Dependencies: 220
-- Name: COLUMN user_account.id; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client.user_account.id IS 'Идентификатор';


--
-- TOC entry 3400 (class 0 OID 0)
-- Dependencies: 220
-- Name: COLUMN user_account.user_id; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client.user_account.user_id IS 'Пользователь';


--
-- TOC entry 3401 (class 0 OID 0)
-- Dependencies: 220
-- Name: COLUMN user_account.account_number; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client.user_account.account_number IS 'Номер счета';


--
-- TOC entry 3402 (class 0 OID 0)
-- Dependencies: 220
-- Name: COLUMN user_account.account_type_id; Type: COMMENT; Schema: bank_client; Owner: postgres
--

COMMENT ON COLUMN bank_client.user_account.account_type_id IS 'Тип счета';


--
-- TOC entry 218 (class 1259 OID 16399)
-- Name: user_account_id_seq; Type: SEQUENCE; Schema: bank_client; Owner: postgres
--

CREATE SEQUENCE bank_client.user_account_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE bank_client.user_account_id_seq OWNER TO postgres;

--
-- TOC entry 3403 (class 0 OID 0)
-- Dependencies: 218
-- Name: user_account_id_seq; Type: SEQUENCE OWNED BY; Schema: bank_client; Owner: postgres
--

ALTER SEQUENCE bank_client.user_account_id_seq OWNED BY bank_client.user_account.id;


--
-- TOC entry 219 (class 1259 OID 16400)
-- Name: user_account_user_id_seq; Type: SEQUENCE; Schema: bank_client; Owner: postgres
--

CREATE SEQUENCE bank_client.user_account_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE bank_client.user_account_user_id_seq OWNER TO postgres;

--
-- TOC entry 3404 (class 0 OID 0)
-- Dependencies: 219
-- Name: user_account_user_id_seq; Type: SEQUENCE OWNED BY; Schema: bank_client; Owner: postgres
--

ALTER SEQUENCE bank_client.user_account_user_id_seq OWNED BY bank_client.user_account.user_id;


--
-- TOC entry 216 (class 1259 OID 16390)
-- Name: user_id_seq; Type: SEQUENCE; Schema: bank_client; Owner: postgres
--

CREATE SEQUENCE bank_client.user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE bank_client.user_id_seq OWNER TO postgres;

--
-- TOC entry 3405 (class 0 OID 0)
-- Dependencies: 216
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: bank_client; Owner: postgres
--

ALTER SEQUENCE bank_client.user_id_seq OWNED BY bank_client."user".id;


--
-- TOC entry 3217 (class 2604 OID 32773)
-- Name: account_type id; Type: DEFAULT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client.account_type ALTER COLUMN id SET DEFAULT nextval('bank_client.account_type_id_seq'::regclass);


--
-- TOC entry 3215 (class 2604 OID 16394)
-- Name: user id; Type: DEFAULT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client."user" ALTER COLUMN id SET DEFAULT nextval('bank_client.user_id_seq'::regclass);


--
-- TOC entry 3216 (class 2604 OID 16404)
-- Name: user_account id; Type: DEFAULT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client.user_account ALTER COLUMN id SET DEFAULT nextval('bank_client.user_account_id_seq'::regclass);


--
-- TOC entry 3379 (class 0 OID 32770)
-- Dependencies: 222
-- Data for Name: account_type; Type: TABLE DATA; Schema: bank_client; Owner: postgres
--

INSERT INTO bank_client.account_type VALUES (1, 'Расчтеный');
INSERT INTO bank_client.account_type VALUES (2, 'Кредитный');
INSERT INTO bank_client.account_type VALUES (3, 'Депозитный');


--
-- TOC entry 3374 (class 0 OID 16391)
-- Dependencies: 217
-- Data for Name: user; Type: TABLE DATA; Schema: bank_client; Owner: postgres
--

INSERT INTO bank_client."user" VALUES (1, 'Тест', 'Тестовый', 'Тестович', '79000000000', 'd7a3a95e79c36894cd6272e1ca9d7573c3dc21562729a72e1a25e9ae4b64638e3c2ad0fdf254cb3fefb8d44703aff5568608664a65c514125518226d587ad36b', '##mZbNDPF9ZF^UwH%1TqVNrTy4)CkB&Pp8P0KSTuvuj9CW+YEG');


--
-- TOC entry 3377 (class 0 OID 16401)
-- Dependencies: 220
-- Data for Name: user_account; Type: TABLE DATA; Schema: bank_client; Owner: postgres
--

INSERT INTO bank_client.user_account VALUES (1, 1, '00000000000000000000', 1);
INSERT INTO bank_client.user_account VALUES (5, 1, '11111111111111111111', 2);
INSERT INTO bank_client.user_account VALUES (6, 1, '22222222222222222222', 3);


--
-- TOC entry 3406 (class 0 OID 0)
-- Dependencies: 221
-- Name: account_type_id_seq; Type: SEQUENCE SET; Schema: bank_client; Owner: postgres
--

SELECT pg_catalog.setval('bank_client.account_type_id_seq', 3, true);


--
-- TOC entry 3407 (class 0 OID 0)
-- Dependencies: 218
-- Name: user_account_id_seq; Type: SEQUENCE SET; Schema: bank_client; Owner: postgres
--

SELECT pg_catalog.setval('bank_client.user_account_id_seq', 7, true);


--
-- TOC entry 3408 (class 0 OID 0)
-- Dependencies: 219
-- Name: user_account_user_id_seq; Type: SEQUENCE SET; Schema: bank_client; Owner: postgres
--

SELECT pg_catalog.setval('bank_client.user_account_user_id_seq', 1, true);


--
-- TOC entry 3409 (class 0 OID 0)
-- Dependencies: 216
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: bank_client; Owner: postgres
--

SELECT pg_catalog.setval('bank_client.user_id_seq', 1, true);


--
-- TOC entry 3227 (class 2606 OID 32775)
-- Name: account_type account_type_pkey; Type: CONSTRAINT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client.account_type
    ADD CONSTRAINT account_type_pkey PRIMARY KEY (id);


--
-- TOC entry 3223 (class 2606 OID 16409)
-- Name: user_account user_account_pk; Type: CONSTRAINT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client.user_account
    ADD CONSTRAINT user_account_pk PRIMARY KEY (id);


--
-- TOC entry 3220 (class 2606 OID 16398)
-- Name: user user_pk; Type: CONSTRAINT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (id);


--
-- TOC entry 3218 (class 1259 OID 24577)
-- Name: user__phone_number__un; Type: INDEX; Schema: bank_client; Owner: postgres
--

CREATE UNIQUE INDEX user__phone_number__un ON bank_client."user" USING btree (phone_number);


--
-- TOC entry 3221 (class 1259 OID 40961)
-- Name: user_account__account_type__idx; Type: INDEX; Schema: bank_client; Owner: postgres
--

CREATE INDEX user_account__account_type__idx ON bank_client.user_account USING btree (user_id, account_type_id) WITH (deduplicate_items='false');


--
-- TOC entry 3224 (class 1259 OID 24578)
-- Name: user_acount__account_number__un; Type: INDEX; Schema: bank_client; Owner: postgres
--

CREATE UNIQUE INDEX user_acount__account_number__un ON bank_client.user_account USING btree (account_number);


--
-- TOC entry 3225 (class 1259 OID 24579)
-- Name: user_acount__user__idx; Type: INDEX; Schema: bank_client; Owner: postgres
--

CREATE INDEX user_acount__user__idx ON bank_client.user_account USING btree (user_id);


--
-- TOC entry 3228 (class 2606 OID 32777)
-- Name: user_account user_account__account_type__fk; Type: FK CONSTRAINT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client.user_account
    ADD CONSTRAINT user_account__account_type__fk FOREIGN KEY (account_type_id) REFERENCES bank_client.account_type(id) ON DELETE RESTRICT;


--
-- TOC entry 3229 (class 2606 OID 24580)
-- Name: user_account user_account__user__fk; Type: FK CONSTRAINT; Schema: bank_client; Owner: postgres
--

ALTER TABLE ONLY bank_client.user_account
    ADD CONSTRAINT user_account__user__fk FOREIGN KEY (user_id) REFERENCES bank_client."user"(id) ON DELETE RESTRICT;


-- Completed on 2024-07-01 15:07:55

--
-- PostgreSQL database dump complete
--

