/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     06/11/2023 8:01:54 CH                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.DONDATHANG') and o.name = 'FK_DONDATHA_LAY_NHACUNGC')
alter table dbo.DONDATHANG
   drop constraint FK_DONDATHA_LAY_NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.DONTHANHTOAN') and o.name = 'FK_DONTHANH_DUARA_NHACUNGC')
alter table dbo.DONTHANHTOAN
   drop constraint FK_DONTHANH_DUARA_NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.DONTHANHTOAN') and o.name = 'FK_DONTHANH_KIEMTRA_DONDATHA')
alter table dbo.DONTHANHTOAN
   drop constraint FK_DONTHANH_KIEMTRA_DONDATHA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SANPHAM') and o.name = 'FK_SANPHAM_CUNGCAP_NHACUNGC')
alter table dbo.SANPHAM
   drop constraint FK_SANPHAM_CUNGCAP_NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SANPHAM') and o.name = 'FK_SANPHAM_LUUTRU_KEHANG')
alter table dbo.SANPHAM
   drop constraint FK_SANPHAM_LUUTRU_KEHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.THONGTINBAOCAO') and o.name = 'FK_THONGTIN_THONGTINB_BANBAOCA')
alter table dbo.THONGTINBAOCAO
   drop constraint FK_THONGTIN_THONGTINB_BANBAOCA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.THONGTINBAOCAO') and o.name = 'FK_THONGTIN_THONGTINB_SANPHAM')
alter table dbo.THONGTINBAOCAO
   drop constraint FK_THONGTIN_THONGTINB_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.THONGTINDDH') and o.name = 'FK_THONGTIN_THONGTIND_DONDATHA')
alter table dbo.THONGTINDDH
   drop constraint FK_THONGTIN_THONGTIND_DONDATHA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.THONGTINDDH') and o.name = 'FK_THONGTIN_THONGTIND_SANPHAM')
alter table dbo.THONGTINDDH
   drop constraint FK_THONGTIN_THONGTIND_SANPHAM
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

alter table dbo.DONDATHANG
   drop constraint PK_DONDATHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.DONDATHANG')
            and   type = 'U')
   drop table dbo.DONDATHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.DONTHANHTOAN')
            and   type = 'U')
   drop table dbo.DONTHANHTOAN
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

alter table dbo.THONGTINBAOCAO
   drop constraint PK_THONGTINBAOCAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.THONGTINBAOCAO')
            and   type = 'U')
   drop table dbo.THONGTINBAOCAO
go

alter table dbo.THONGTINDDH
   drop constraint PK_THONGTINDDH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.THONGTINDDH')
            and   type = 'U')
   drop table dbo.THONGTINDDH
go

drop schema dbo
go

/*==============================================================*/
/* Table: BANBAOCAO                                             */
/*==============================================================*/
create table BANBAOCAO (
   MA_BAOCAO            varchar(10)          not null,
   NGAYBAOCAO           datetime             null,
   constraint PK_BANBAOCAO primary key nonclustered (MA_BAOCAO)
)
go

/*==============================================================*/
/* Table: DONDATHANG                                            */
/*==============================================================*/
create table DONDATHANG (
   MA_DATHANG           varchar(10)          not null,
   MA_NCCAP             varchar(10)          not null,
   LOAISP               nvarchar(100)        null,
   NGAY_DATHANG         datetime             null,
   constraint PK_DONDATHANG primary key nonclustered (MA_DATHANG)
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
/* Table: KEHANG                                                */
/*==============================================================*/
create table KEHANG (
   MA_KEHANG            varchar(10)          not null,
   LOAISP               nvarchar(100)        null,
   VITRI                nvarchar(20)         null,
   constraint PK_KEHANG primary key nonclustered (MA_KEHANG)
)
go

/*==============================================================*/
/* Table: NHACUNGCAP                                            */
/*==============================================================*/
create table NHACUNGCAP (
   MA_NCCAP             varchar(10)          not null,
   TEN_NCCAP            nvarchar(100)        null,
   LOAISP               nvarchar(100)        null,
   SDT                  numeric(10)          null,
   DIACHI               nchar(200)           null,
   EMAIL                nchar(100)           null,
   NGAYTAO              datetime             null,
   NGAYCAPNHAT          datetime             null,
   constraint PK_NHACUNGCAP primary key nonclustered (MA_NCCAP)
)
go

/*==============================================================*/
/* Table: SANPHAM                                               */
/*==============================================================*/
create table SANPHAM (
   MASP                 varchar(10)          not null,
   MA_KEHANG            varchar(10)          not null,
   MA_NCCAP             varchar(10)          not null,
   TENSP                nvarchar(100)        null,
   LOAISP               nvarchar(100)        null,
   TENTOMTAT            varchar(100)         null,
   SOLUONG              int                  null,
   NGAYTAO              datetime             null,
   NGAYCAPNHAT          datetime             null,
   NGAYHETHAN           datetime             null,
   GIATIEN              decimal(18)          null,
   TRANGTHAI            tinyint              null,
   constraint PK_SANPHAM primary key nonclustered (MASP)
)
go

/*==============================================================*/
/* Index: CUNGCAP_FK                                            */
/*==============================================================*/
create index CUNGCAP_FK on SANPHAM (
MA_NCCAP ASC
)
go

/*==============================================================*/
/* Index: LUUTRU_FK                                             */
/*==============================================================*/
create index LUUTRU_FK on SANPHAM (
MA_KEHANG ASC
)
go

/*==============================================================*/
/* Table: THONGTINBAOCAO                                        */
/*==============================================================*/
create table THONGTINBAOCAO (
   MASP                 varchar(10)          not null,
   MA_BAOCAO            varchar(10)          not null,
   TENSP                nvarchar(100)        null,
   SOLUONG              int                  null,
   constraint PK_THONGTINBAOCAO primary key nonclustered (MASP, MA_BAOCAO)
)
go

/*==============================================================*/
/* Index: THONGTINBAOCAO2_FK                                    */
/*==============================================================*/
create index THONGTINBAOCAO2_FK on THONGTINBAOCAO (
MASP ASC
)
go

/*==============================================================*/
/* Index: THONGTINBAOCAO_FK                                     */
/*==============================================================*/
create index THONGTINBAOCAO_FK on THONGTINBAOCAO (
MA_BAOCAO ASC
)
go

/*==============================================================*/
/* Table: THONGTINDDH                                           */
/*==============================================================*/
create table THONGTINDDH (
   MA_DATHANG           varchar(10)          not null,
   MASP                 varchar(10)          not null,
   SOLUONG              int                  null,
   constraint PK_THONGTINDDH primary key nonclustered (MA_DATHANG, MASP)
)
go

/*==============================================================*/
/* Index: THONGTINDDH2_FK                                       */
/*==============================================================*/
create index THONGTINDDH2_FK on THONGTINDDH (
MA_DATHANG ASC
)
go

/*==============================================================*/
/* Index: THONGTINDDH_FK                                        */
/*==============================================================*/
create index THONGTINDDH_FK on THONGTINDDH (
MASP ASC
)
go

alter table DONDATHANG
   add constraint FK_DONDATHA_LAY_NHACUNGC foreign key (MA_NCCAP)
      references NHACUNGCAP (MA_NCCAP)
go

alter table SANPHAM
   add constraint FK_SANPHAM_CUNGCAP_NHACUNGC foreign key (MA_NCCAP)
      references NHACUNGCAP (MA_NCCAP)
go

alter table SANPHAM
   add constraint FK_SANPHAM_LUUTRU_KEHANG foreign key (MA_KEHANG)
      references KEHANG (MA_KEHANG)
go

alter table THONGTINBAOCAO
   add constraint FK_THONGTIN_THONGTINB_BANBAOCA foreign key (MA_BAOCAO)
      references BANBAOCAO (MA_BAOCAO)
go

alter table THONGTINBAOCAO
   add constraint FK_THONGTIN_THONGTINB_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table THONGTINDDH
   add constraint FK_THONGTIN_THONGTIND_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table THONGTINDDH
   add constraint FK_THONGTIN_THONGTIND_DONDATHA foreign key (MA_DATHANG)
      references DONDATHANG (MA_DATHANG)
go


create trigger CLR_TRIGGER_DONDATHANG on DONDATHANG  insert as
external name %Assembly.GeneratedName%.
go


create trigger CLR_TRIGGER_SANPHAM on SANPHAM  insert as
external name %Assembly.GeneratedName%.
go

