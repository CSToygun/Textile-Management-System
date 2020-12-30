CREATE TABLE public.urun
(
    urun_id SERIAL NOT NULL ,
    urunname character varying(255) COLLATE  NOT NULL,
    price integer NOT NULL,
    kategori character varying(40) COLLATE  NOT NULL,
    malzeme character varying(255) COLLATE  NOT NULL,
    stok character varying(40) COLLATE  NOT NULL,
    adet integer NOT NULL,
    note character varying(255) ,
    tarih character varying(255)  NOT NULL,
	urunpicture character varying(255) NOT NULL,
    CONSTRAINT urun_pkey PRIMARY KEY (urun_id) ,
	CONSTRAINT urun2_fkey FOREIGN KEY (malzeme) REFERENCES "Malzeme"("malzemename") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT urun3_fkey FOREIGN KEY (tarih) REFERENCES "Malzeme"("uruntarihi") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT urun4_fkey FOREIGN KEY (urunpicture) REFERENCES "UrunResimler"("urunpicture") ON DELETE CASCADE  ON UPDATE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE public.urun
    OWNER to postgres;
	
CREATE TABLE public.Tarih
(
	tarih_id SERIAL NOT NULL ,
    tarihdate character varying(255) NOT NULL,
    malzemetarihi character varying(255) NOT NULL,
    uruntarihi character varying(40) COLLATE  NOT NULL,
	CONSTRAINT tarih_pkey PRIMARY KEY (tarih_id)
)


CREATE TABLE public.Program
(
	data_id SERIAL NOT NULL ,
    kisi_id character varying(255) NOT NULL,
    urun_id character varying(255) NOT NULL,
    malzeme_id character varying(40) COLLATE  NOT NULL,
	CONSTRAINT program_pkey PRIMARY KEY (data_id),
	CONSTRAINT program_fkey FOREIGN KEY (kisi_id ) REFERENCES "Eleman"("kisi_id") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT program2_fkey FOREIGN KEY (urun_id) REFERENCES "Urun"("urun_id") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT program3_fkey FOREIGN KEY (malzeme_id) REFERENCES "Malzeme"("malzeme_id") ON DELETE CASCADE ON UPDATE CASCADE
)



CREATE TABLE public.Malzeme
(
    malzeme_id SERIAL NOT NULL ,
    malzemename character varying(255) NOT NULL,
    malzemecinsi character varying(40) NOT NULL,
	miktarcinsi character varying(40) NOT NULL,
    malzememiktari INT NOT NULL,
	tarih character varying(255) NOT NULL,
    alisfiyat integer  NOT NULL,
    note character varying(255),
	pictureadress character varying(255),
    CONSTRAINT malzeme_pkey PRIMARY KEY (malzeme_id)
	CONSTRAINT malzeme_fkey FOREIGN KEY (tarih) REFERENCES "Malzeme"("malzemetarihi") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT malzeme2_fkey FOREIGN KEY (pictureadress) REFERENCES "MalzemeResimler"("pictureadress")ON DELETE CASCADE ON UPDATE CASCADE
	CONSTRAINT "malzemeCheck" CHECK("malzememiktari" >= 0)
)

CREATE TABLE public.Eleman
(
    kisi_id SERIAL NOT NULL ,
    elemanname character varying(80) NOT NULL,
    elemansurname character varying(40) NOT NULL,
	telefon BIGINT ,
	cinsiyet character varying(40) NOT NULL,
	calissaat character varying(255) NOT NULL,
    dogumtarih character varying(85) NOT NULL,
    aylikucret INT ,
	birim  character varying(55) NOT NULL,
	mesaiucret INT ,
    adress character varying(255) NOT NULL,
	elemanpicture character varying(255) NOT NULL,
    CONSTRAINT Eleman_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Eleman_fkey FOREIGN KEY (adress) REFERENCES "Adress"("adress")ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT "telefon_unqkey" UNIQUE (telefon);
	
)

CREATE TABLE public.Adress
( 
    adress character varying(150) NOT NULL,
    mahalle character varying(80) NOT NULL,
	ilce character varying(40) NOT NULL,
	CONSTRAINT adress_pkey PRIMARY KEY (adress)
)

CREATE TABLE public.Denge
(
	denge_id SERIAL NOT NULL ,
	alisfiyat_toplam character varying(150) NOT NULL,
    urunfiyat_toplam character varying(80) NOT NULL,
	toplamdenge character varying(40) NOT NULL,
	CONSTRAINT denge_pkey PRIMARY KEY (denge_id)
)













IF OBJECT_ID('dbo.user_main') is null
BEGIN
	-- master user table
	CREATE TABLE user_main (
			[user_key] int, -- IDENTITY(1,1) REMOVED handling with proc (spgetNextUserKey)
			[user_id] varchar(50) not null,
			[first_name] varchar(15) not null,
			[last_name] varchar(20) not null,
			[create_date] datetime not null,
		PRIMARY KEY NONCLUSTERED 
		(
			[user_key] ASC
		) ON [PRIMARY]
	)

		ALTER TABLE user_main
			ADD CONSTRAINT def_createDate DEFAULT (GETDATE()) FOR [create_date]
END


IF OBJECT_ID('dbo.pass_main') is null
BEGIN
	-- master user / pass table
	CREATE TABLE pass_main (
			[user_key] int, 
			[pass_hash] varchar(max) not null, -- hashed in C# app
			[pass_salt] varchar(max) not null, -- HASHBYTES()
			CONSTRAINT fk_userPass FOREIGN KEY (user_key) REFERENCES user_main(user_key)
	)

		CREATE UNIQUE NONCLUSTERED INDEX natKey_passMain ON pass_main (
			[user_key]
		)

END

GO


/* --- AUDIT TABLES --- */

IF OBJECT_ID('dbo.login_audit') is null
BEGIN
	-- login auditing
	CREATE TABLE login_audit (
			[user_key] int not null,
			[login_status] int not null, -- 1 success / 0 fail
			[curr_session_id] varchar(max) not null, -- gen'd using NEWID() with proc (spcreateSession)
			[last_login] datetime not null,
		CONSTRAINT fk_loginAudit FOREIGN KEY (user_key) REFERENCES user_main(user_key)
	)

		CREATE UNIQUE NONCLUSTERED INDEX natKey_loginAudit ON login_audit (
			[user_key]
		)

		ALTER TABLE login_audit
			ADD CONSTRAINT def_lastLoginDate DEFAULT (GETDATE()) FOR [last_login]

		ALTER TABLE login_audit
			ADD CONSTRAINT def_loginStatus DEFAULT (0) FOR [login_status]
END

GO

IF OBJECT_ID('dbo.logout_audit') is null
BEGIN
	-- logout auditing
	CREATE TABLE logout_audit (
			[user_key] int not null,
			[logout_status] int not null, -- 1 success / 0 fail
			[last_logout] datetime not null,
			[last_session_id] varchar(max) not null,
		CONSTRAINT fk_logoutAudit FOREIGN KEY (user_key) REFERENCES user_main(user_key)
	)

		CREATE UNIQUE NONCLUSTERED INDEX natKey_loutAudit ON logout_audit (
			[user_key]
		)

		ALTER TABLE logout_audit
			ADD CONSTRAINT def_lastLogoutDate DEFAULT (GETDATE()) FOR [last_logout]

		ALTER TABLE logout_audit
			ADD CONSTRAINT def_logoutStatus DEFAULT (0) FOR [logout_status]
END

GO

/* KEY TABLES (opting out of using IDENTITY() on user_main PK) */

IF OBJECT_ID('dbo.user_key_store') is null
BEGIN
	-- user key value store
	CREATE TABLE user_key_store (
			[user_key] int not null,
		PRIMARY KEY NONCLUSTERED 
		(
			[user_key] ASC
		) ON [PRIMARY]
	)

	ALTER TABLE user_key_store
		ADD CONSTRAINT def_userKey DEFAULT (0) FOR [user_key]

END

GO
