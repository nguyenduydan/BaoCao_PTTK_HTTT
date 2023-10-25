/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     24/10/2023 5:14:21 CH                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.BANBAOCAO') and o.name = 'FK_BANBAOCA_BAOCAO_SANPHAM')
alter table dbo.BANBAOCAO
   drop constraint FK_BANBAOCA_BAOCAO_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.DATVAO') and o.name = 'FK_DATVAO_DATVAO2_KEHANG')
alter table dbo.DATVAO
   drop constraint FK_DATVAO_DATVAO2_KEHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.DATVAO') and o.name = 'FK_DATVAO_DATVAO_SANPHAM')
alter table dbo.DATVAO
   drop constraint FK_DATVAO_DATVAO_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.DONDATHANG') and o.name = 'FK_DONDATHA_DATHANG_SANPHAM')
alter table dbo.DONDATHANG
   drop constraint FK_DONDATHA_DATHANG_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.DONDATHANG') and o.name = 'FK_DONDATHA_LAY_NHACUNGC')
alter table dbo.DONDATHANG
   drop constraint FK_DONDATHA_LAY_NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.HANGTON') and o.name = 'FK_HANGTON_LUUTRU_SANPHAM')
alter table dbo.HANGTON
   drop constraint FK_HANGTON_LUUTRU_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.KIEMTRA') and o.name = 'FK_KIEMTRA_KIEMTRA2_DONDATHA')
alter table dbo.KIEMTRA
   drop constraint FK_KIEMTRA_KIEMTRA2_DONDATHA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.KIEMTRA') and o.name = 'FK_KIEMTRA_KIEMTRA_DONTHANH')
alter table dbo.KIEMTRA
   drop constraint FK_KIEMTRA_KIEMTRA_DONTHANH
go

alter table dbo.BANBAOCAO
   drop constraint PK_BANBAOCAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.BANBAOCAO')
            and   type = 'U')
   drop table dbo.BANBAOCAO
go

alter table dbo.DATVAO
   drop constraint PK_DATVAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.DATVAO')
            and   type = 'U')
   drop table dbo.DATVAO
go

alter table dbo.DONDATHANG
   drop constraint PK_DONDATHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.DONDATHANG')
            and   type = 'U')
   drop table dbo.DONDATHANG
go

alter table dbo.DONTHANHTOAN
   drop constraint PK_DONTHANHTOAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.DONTHANHTOAN')
            and   type = 'U')
   drop table dbo.DONTHANHTOAN
go

alter table dbo.HANGTON
   drop constraint PK_HANGTON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.HANGTON')
            and   type = 'U')
   drop table dbo.HANGTON
go

alter table dbo.KEHANG
   drop constraint PK_KEHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.KEHANG')
            and   type = 'U')
   drop table dbo.KEHANG
go

alter table dbo.KIEMTRA
   drop constraint PK_KIEMTRA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.KIEMTRA')
            and   type = 'U')
   drop table dbo.KIEMTRA
go

alter table dbo.NHACUNGCAP
   drop constraint PK_NHACUNGCAP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.NHACUNGCAP')
            and   type = 'U')
   drop table dbo.NHACUNGCAP
go

alter table dbo.SANPHAM
   drop constraint PK_SANPHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SANPHAM')
            and   type = 'U')
   drop table dbo.SANPHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sysdiagrams')
            and   type = 'U')
   drop table dbo.sysdiagrams
go

drop schema dbo
go

/*==============================================================*/
/* Table: BANBAOCAO                                             */
/*==============================================================*/
create table BANBAOCAO (
   MA_BAOCAO            varchar(10)          not null,
   MASP                 varchar(10)          not null,
   SOLUONG              numeric(5)           null,
   NGAYBAOCAO           datetime             null,
   constraint PK_BANBAOCAO primary key nonclustered (MA_BAOCAO)
)
go

/*==============================================================*/
/* Index: ASSOCIATION_10_FK                                     */
/*==============================================================*/
create index ASSOCIATION_10_FK on BANBAOCAO (
MASP ASC
)
go

/*==============================================================*/
/* Table: DATVAO                                                */
/*==============================================================*/
create table DATVAO (
   MASP                 varchar(10)          not null,
   MA_KEHANG            varchar(10)          not null,
   SOLUONG              numeric              null,
   constraint PK_DATVAO primary key nonclustered (MASP, MA_KEHANG)
)
go

/*==============================================================*/
/* Index: DATVAO2_FK                                            */
/*==============================================================*/
create index DATVAO2_FK on DATVAO (
MASP ASC
)
go

/*==============================================================*/
/* Index: DATVAO_FK                                             */
/*==============================================================*/
create index DATVAO_FK on DATVAO (
MA_KEHANG ASC
)
go

/*==============================================================*/
/* Table: DONDATHANG                                            */
/*==============================================================*/
create table DONDATHANG (
   MA_DATHANG           varchar(10)          not null,
   MASP                 varchar(10)          not null,
   TEN_SP               nvarchar(100)        null,
   MA_NCCAP             varchar(10)          not null,
   SOLUONG              numeric(5)           null,
   NGAY_DATHANG         datetime             null,
   constraint PK_DONDATHANG primary key nonclustered (MA_DATHANG)
)
go

/*==============================================================*/
/* Index: ASSOCIATION_7_FK                                      */
/*==============================================================*/
create index ASSOCIATION_7_FK on DONDATHANG (
MASP ASC
)
go

/*==============================================================*/
/* Index: LAY_FK                                                */
/*==============================================================*/
create index LAY_FK on DONDATHANG (
MA_NCCAP ASC
)
go

/*==============================================================*/
/* Table: DONTHANHTOAN                                          */
/*==============================================================*/
create table DONTHANHTOAN (
   MATT                 varchar(10)          not null,
   TENSP                nvarchar(100)        null,
   NGAYTHANHTOAN        datetime             null,
   SOLUONG              numeric(5)           null,
   GIACA                decimal(18)          null,
   constraint PK_DONTHANHTOAN primary key nonclustered (MATT)
)
go

/*==============================================================*/
/* Table: HANGTON                                               */
/*==============================================================*/
create table HANGTON (
   MA_HANGTON           varchar(10)          not null,
   MASP                 varchar(10)          not null,
   SOLUONG              numeric(5)           null,
   MOTA_HANGTON         nvarchar(1000)       null,
   constraint PK_HANGTON primary key nonclustered (MA_HANGTON, MASP)
)
go

/*==============================================================*/
/* Table: KEHANG                                                */
/*==============================================================*/
create table KEHANG (
   MA_KEHANG            varchar(10)          not null,
   TEN_KEHANG           nvarchar(100)        null,
   MOTA_KEHANG          nvarchar(1000)       null,
   constraint PK_KEHANG primary key nonclustered (MA_KEHANG)
)
go

/*==============================================================*/
/* Table: KIEMTRA                                               */
/*==============================================================*/
create table KIEMTRA (
   MATT                 varchar(10)          not null,
   MA_DATHANG           varchar(10)          not null,
   constraint PK_KIEMTRA primary key nonclustered (MATT, MA_DATHANG)
)
go

/*==============================================================*/
/* Index: KIEMTRA2_FK                                           */
/*==============================================================*/
create index KIEMTRA2_FK on KIEMTRA (
MATT ASC
)
go

/*==============================================================*/
/* Index: KIEMTRA_FK                                            */
/*==============================================================*/
create index KIEMTRA_FK on KIEMTRA (
MA_DATHANG ASC
)
go

/*==============================================================*/
/* Table: NHACUNGCAP                                            */
/*==============================================================*/
create table NHACUNGCAP (
   MA_NCCAP             varchar(10)          not null,
   TEN_NCCAP            nvarchar(100)        null,
   LOASP                nvarchar(100)        null,
   SDT                  numeric(10)          null,
   DIACHI               nchar(200)           null,
   EMAIL                nchar(100)           null,
   GIACA                decimal(18)          null,
   constraint PK_NHACUNGCAP primary key nonclustered (MA_NCCAP)
)
go

/*==============================================================*/
/* Table: SANPHAM                                               */
/*==============================================================*/
create table SANPHAM (
   MASP                 varchar(10)          not null,
   TENSP                nvarchar(100)        null,
   LOAISP               nvarchar(100)        null,
   TENTOMTAT            varchar(100)         null,
   SOLUONG              numeric(5)           null,
   NGAYTAO              datetime             null,
   NGAYCAPNHAT          datetime             null,
   NGAYHETHAN           datetime             null,
   GIACA                decimal(18)          null,
   constraint PK_SANPHAM primary key nonclustered (MASP)
)
go

alter table BANBAOCAO
   add constraint FK_BANBAOCA_BAOCAO_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table DATVAO
   add constraint FK_DATVAO_DATVAO_KEHANG foreign key (MA_KEHANG)
      references KEHANG (MA_KEHANG)
go

alter table DATVAO
   add constraint FK_DATVAO_DATVAO2_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table DONDATHANG
   add constraint FK_DONDATHA_DATHANG_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table DONDATHANG
   add constraint FK_DONDATHA_LAY_NHACUNGC foreign key (MA_NCCAP)
      references NHACUNGCAP (MA_NCCAP)
go

alter table HANGTON
   add constraint FK_HANGTON_LUUTRU_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table KIEMTRA
   add constraint FK_KIEMTRA_KIEMTRA_DONDATHA foreign key (MA_DATHANG)
      references DONDATHANG (MA_DATHANG)
go

alter table KIEMTRA
   add constraint FK_KIEMTRA_KIEMTRA2_DONTHANH foreign key (MATT)
      references DONTHANHTOAN (MATT)
go

