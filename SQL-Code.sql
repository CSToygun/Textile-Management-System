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
	CONSTRAINT urun4_fkey FOREIGN KEY (urunpicture) REFERENCES "Resimlersc"."UrunResimler"("urunpicture") ON DELETE CASCADE  ON UPDATE CASCADE
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
	CONSTRAINT program_fkey FOREIGN KEY (kisi_id ) REFERENCES "Elemansc"."Eleman"("kisi_id") ON DELETE CASCADE ON UPDATE CASCADE,
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
	CONSTRAINT malzeme2_fkey FOREIGN KEY (pictureadress) REFERENCES "Resimlersc"."MalzemeResimler"("pictureadress")ON DELETE CASCADE ON UPDATE CASCADE
	CONSTRAINT "malzemeCheck" CHECK("malzememiktari" >= 0)
)

CREATE TABLE public.Denge
(
	denge_id SERIAL NOT NULL ,
	alisfiyat_toplam integer NOT NULL,
    urunfiyat_toplam integer NOT NULL,
	aylikucret_toplam integer NOT NULL,
	toplamdenge integer NOT NULL,
	CONSTRAINT denge_pkey PRIMARY KEY (denge_id),
	CONSTRAINT denge_fkey FOREIGN KEY (alisfiyat_toplam) REFERENCES "Malzeme"("alisfiyat")ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT denge_f2key FOREIGN KEY (aylikucret_toplam) REFERENCES "Elemansc"."Eleman"("aylikucret")ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT denge_f2key FOREIGN KEY (urunfiyat_toplam) REFERENCES "urun"("price")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE SCHEMA "Elemansc";

CREATE TABLE "Elemansc"."Eleman"
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
	CONSTRAINT Eleman_f2key FOREIGN KEY (elemanpicture) REFERENCES "Resimlersc"."ElemanResimler"("elemanpicture")ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT "telefon_unqkey" UNIQUE (telefon)
)

CREATE TABLE public.Adress
( 
    adress character varying(150) NOT NULL,
    mahalle character varying(80) NOT NULL,
	ilce character varying(40) NOT NULL,
	CONSTRAINT adress_pkey PRIMARY KEY (adress)
)

CREATE SCHEMA "Resimlersc";

CREATE TABLE "Resimlersc"."Resimler" ( 
	"resim_id" SERIAL,
	"resimtur" CHARACTER VARYING(40) NOT NULL,
	CONSTRAINT "resimlerlPK" PRIMARY KEY ("resim_id")
);

CREATE TABLE "Resimlersc"."ElemanResimler" ( 
	"resim_id" INT,
	"elemanpicture" CHARACTER VARYING(40) NOT NULL,
	CONSTRAINT "ElemanResimlerPK" PRIMARY KEY ("resim_id") ,
	CONSTRAINT Elemanpic_fkey FOREIGN KEY (resim_id) REFERENCES "Resimlersc"."Resimler"("resim_id")ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE "Resimlersc"."MalzemeResimler" ( 
	"resim_id" INT,
	"pictureadress" CHARACTER VARYING(40) NOT NULL,
	CONSTRAINT "MalzemeResimlerPK" PRIMARY KEY ("resim_id"), 
	CONSTRAINT malzemepic_fkey FOREIGN KEY (resim_id) REFERENCES "Resimlersc"."Resimler"("resim_id")ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE "Resimlersc"."UrunResimler" ( 
	"resim_id" INT,
	"urunpicture" CHARACTER VARYING(40) NOT NULL,
	CONSTRAINT "UrunResimlerPK" PRIMARY KEY ("resim_id"),
	CONSTRAINT urunpic_fkey FOREIGN KEY (resim_id) REFERENCES "Resimlersc"."Resimler"("resim_id")ON DELETE CASCADE ON UPDATE CASCADE,
);

--------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------

CREATE TABLE "Elemansc"."Yonetici"	
(
    kisi_id INT NOT NULL ,
    adminkey SERIAL NOT NULL,
    CONSTRAINT Yonetici_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Yonetici_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT Yonetici_f2key FOREIGN KEY (adminkey) REFERENCES "Admin"("admin_key")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE "Elemansc"."Kesim"	
(
    kisi_id INT NOT NULL ,
    calismasa CHARACTER VARYING(40) NOT NULL,
    CONSTRAINT Kesim_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Kesim_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE,
)
CREATE TABLE "Elemansc"."Makine"	
(
    kisi_id INT NOT NULL ,
    calismakine CHARACTER VARYING(40) NOT NULL,
    CONSTRAINT  Makine_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Makine_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE
	
)
CREATE TABLE "Elemansc"."Teknisyen"	
(
    kisi_id INT NOT NULL ,
    gorevi CHARACTER VARYING(80) NOT NULL,
    CONSTRAINT Teknisyen_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Teknisyen_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE "Elemansc"."Utu"	
(
    kisi_id INT NOT NULL ,
    calisacagiutu CHARACTER VARYING(80) NOT NULL,
    CONSTRAINT Utu_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Utu_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE "Elemansc"."Dikis"	
(
    kisi_id INT NOT NULL ,
    makineno CHARACTER VARYING(80) NOT NULL,
    CONSTRAINT Dikis_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Dikis_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE "Elemansc"."Ayakci"	
(
    kisi_id INT NOT NULL ,
    yardımetbirim CHARACTER VARYING(80) NOT NULL,
    CONSTRAINT Ayakci_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Ayakci_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE "Elemansc"."Temizlik"	
(
    kisi_id INT NOT NULL ,
    caliskat CHARACTER VARYING(80) NOT NULL,
    CONSTRAINT Yonetici_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Teknisyen_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE "Elemansc"."Sofor"	
(
    kisi_id INT NOT NULL ,
    araba_id SERIAL NOT NULL,
	plaka_no CHARACTER VARYING(20) NOT NULL,
    CONSTRAINT Sofor_pkey PRIMARY KEY (kisi_id),
	CONSTRAINT Sofor_unqkey UNIQUE KEY (plaka_no),
	CONSTRAINT Sofor_fkey FOREIGN KEY (kisi_id) REFERENCES "Elemansc"."Eleman"("kisi_id")ON DELETE CASCADE ON UPDATE CASCADE
	CONSTRAINT Sofor_f2key FOREIGN KEY (araba_id) REFERENCES "Araba"("araba_id")ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE "Araba"	
(
    araba_id SERIAL NOT NULL ,
    araba_model CHARACTER VARYING(40) NOT NULL
	araba_tur CHARACTER VARYING(20) NOT NULL,
    CONSTRAINT araba_pkey PRIMARY KEY (araba_id),
)


CREATE TABLE "Admin"	
(
    admin_key var NOT NULL ,
    admin_id SERIAL NOT NULL
	adminname CHARACTER VARYING(20) NOT NULL,
	create_date DATE NOT NULL,
	last_login DATE NOT NULL,
	login_status BOOLEAN ,
	CONSTRAINT Admin_pkey PRIMARY KEY (admin_key),
)
CREATE TABLE "Password"	
(
    admin_key var NOT NULL ,
    admin_id INT NOT NULL
	pashhash character varying(512) NOT NULL,
	pass_salt character varying(80) NOT NULL,
	CONSTRAINT Pasword_pkey PRIMARY KEY (admin_key),
)
