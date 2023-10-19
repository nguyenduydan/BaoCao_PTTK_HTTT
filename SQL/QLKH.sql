/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     18/10/2023 10:24:36 SA                       */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INVOICE_PAYMENT') and o.name = 'FK_INVOICE__BILLS_SUPPLIER')
alter table INVOICE_PAYMENT
   drop constraint FK_INVOICE__BILLS_SUPPLIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INVOICE_PAYMENT') and o.name = 'FK_INVOICE__DETAILS_P_ORDERS_D')
alter table INVOICE_PAYMENT
   drop constraint FK_INVOICE__DETAILS_P_ORDERS_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ITEMS') and o.name = 'FK_ITEMS_ITEMS_SUPPLIER')
alter table ITEMS
   drop constraint FK_ITEMS_ITEMS_SUPPLIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ITEMS') and o.name = 'FK_ITEMS_ITEMS2_PRODUCTS')
alter table ITEMS
   drop constraint FK_ITEMS_ITEMS2_PRODUCTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTS') and o.name = 'FK_PRODUCTS_REPORT_REPORT_F')
alter table PRODUCTS
   drop constraint FK_PRODUCTS_REPORT_REPORT_F
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTS2') and o.name = 'FK_PRODUCTS_PRODUCTS_PRODUCTS')
alter table PRODUCTS2
   drop constraint FK_PRODUCTS_PRODUCTS_PRODUCTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTS2') and o.name = 'FK_PRODUCTS_PRODUCTS2_SHELF')
alter table PRODUCTS2
   drop constraint FK_PRODUCTS_PRODUCTS2_SHELF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUANTITIES_OF_PRODUCT') and o.name = 'FK_QUANTITI_QUANTITIE_PRODUCTS')
alter table QUANTITIES_OF_PRODUCT
   drop constraint FK_QUANTITI_QUANTITIE_PRODUCTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUANTITIES_OF_PRODUCT') and o.name = 'FK_QUANTITI_QUANTITIE_ORDERS_D')
alter table QUANTITIES_OF_PRODUCT
   drop constraint FK_QUANTITI_QUANTITIE_ORDERS_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SEND') and o.name = 'FK_SEND_SEND_ORDERS_D')
alter table SEND
   drop constraint FK_SEND_SEND_ORDERS_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SEND') and o.name = 'FK_SEND_SEND2_SUPPLIER')
alter table SEND
   drop constraint FK_SEND_SEND2_SUPPLIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STORAGE') and o.name = 'FK_STORAGE_STORAGE_PRODUCTS')
alter table STORAGE
   drop constraint FK_STORAGE_STORAGE_PRODUCTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STORAGE') and o.name = 'FK_STORAGE_STORAGE2_INVENTOR')
alter table STORAGE
   drop constraint FK_STORAGE_STORAGE2_INVENTOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INVENTORY_LEVEL')
            and   type = 'U')
   drop table INVENTORY_LEVEL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('INVOICE_PAYMENT')
            and   name  = 'BILLS_FK'
            and   indid > 0
            and   indid < 255)
   drop index INVOICE_PAYMENT.BILLS_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('INVOICE_PAYMENT')
            and   name  = 'DETAILS_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index INVOICE_PAYMENT.DETAILS_PRODUCT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INVOICE_PAYMENT')
            and   type = 'U')
   drop table INVOICE_PAYMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ITEMS')
            and   name  = 'ITEMS2_FK'
            and   indid > 0
            and   indid < 255)
   drop index ITEMS.ITEMS2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ITEMS')
            and   name  = 'ITEMS_FK'
            and   indid > 0
            and   indid < 255)
   drop index ITEMS.ITEMS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ITEMS')
            and   type = 'U')
   drop table ITEMS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ORDERS_DETAIL')
            and   type = 'U')
   drop table ORDERS_DETAIL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTS')
            and   name  = 'REPORT_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTS.REPORT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTS')
            and   type = 'U')
   drop table PRODUCTS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTS2')
            and   name  = 'PRODUCTS2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTS2.PRODUCTS2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTS2')
            and   name  = 'PRODUCTS_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTS2.PRODUCTS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTS2')
            and   type = 'U')
   drop table PRODUCTS2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QUANTITIES_OF_PRODUCT')
            and   name  = 'QUANTITIES_OF_PRODUCT2_FK'
            and   indid > 0
            and   indid < 255)
   drop index QUANTITIES_OF_PRODUCT.QUANTITIES_OF_PRODUCT2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QUANTITIES_OF_PRODUCT')
            and   name  = 'QUANTITIES_OF_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index QUANTITIES_OF_PRODUCT.QUANTITIES_OF_PRODUCT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QUANTITIES_OF_PRODUCT')
            and   type = 'U')
   drop table QUANTITIES_OF_PRODUCT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REPORT_FORM')
            and   type = 'U')
   drop table REPORT_FORM
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SEND')
            and   name  = 'SEND2_FK'
            and   indid > 0
            and   indid < 255)
   drop index SEND.SEND2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SEND')
            and   name  = 'SEND_FK'
            and   indid > 0
            and   indid < 255)
   drop index SEND.SEND_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SEND')
            and   type = 'U')
   drop table SEND
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SHELF')
            and   type = 'U')
   drop table SHELF
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('STORAGE')
            and   name  = 'STORAGE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index STORAGE.STORAGE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('STORAGE')
            and   name  = 'STORAGE_FK'
            and   indid > 0
            and   indid < 255)
   drop index STORAGE.STORAGE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('STORAGE')
            and   type = 'U')
   drop table STORAGE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SUPPLIER')
            and   type = 'U')
   drop table SUPPLIER
go

/*==============================================================*/
/* Table: INVENTORY_LEVEL                                       */
/*==============================================================*/
create table INVENTORY_LEVEL (
   PRODUCT_ID           int                  not null,
   LEVEL_ID             int                  not null,
   NAME                 text                 null,
   AMOUNT               numeric(5)           null,
   PRODUCT_DESCRIPTION  text                 null,
   constraint PK_INVENTORY_LEVEL primary key nonclustered (PRODUCT_ID, LEVEL_ID)
)
go

/*==============================================================*/
/* Table: INVOICE_PAYMENT                                       */
/*==============================================================*/
create table INVOICE_PAYMENT (
   PAYMENT_ID           int                  not null,
   SUPPLIER_ID          int                  not null,
   ORDER_ID             int                  not null,
   NAME_PRODUCT         text                 null,
   ORDERID              int                  null,
   DATE                 datetime             null,
   PRICE                decimal(18)          null,
   AMOUNT               numeric(5)           null,
   TOTAL                decimal(18)          null,
   constraint PK_INVOICE_PAYMENT primary key nonclustered (PAYMENT_ID)
)
go

/*==============================================================*/
/* Index: DETAILS_PRODUCT_FK                                    */
/*==============================================================*/
create index DETAILS_PRODUCT_FK on INVOICE_PAYMENT (
ORDER_ID ASC
)
go

/*==============================================================*/
/* Index: BILLS_FK                                              */
/*==============================================================*/
create index BILLS_FK on INVOICE_PAYMENT (
SUPPLIER_ID ASC
)
go

/*==============================================================*/
/* Table: ITEMS                                                 */
/*==============================================================*/
create table ITEMS (
   SUPPLIER_ID          int                  not null,
   PRODUCTS_ID          int                  not null,
   constraint PK_ITEMS primary key (SUPPLIER_ID, PRODUCTS_ID)
)
go

/*==============================================================*/
/* Index: ITEMS_FK                                              */
/*==============================================================*/
create index ITEMS_FK on ITEMS (
SUPPLIER_ID ASC
)
go

/*==============================================================*/
/* Index: ITEMS2_FK                                             */
/*==============================================================*/
create index ITEMS2_FK on ITEMS (
PRODUCTS_ID ASC
)
go

/*==============================================================*/
/* Table: ORDERS_DETAIL                                         */
/*==============================================================*/
create table ORDERS_DETAIL (
   ORDER_ID             int                  not null,
   PRODUC_ID            int                  null,
   SUPPLIERID           int                  null,
   NAME_PRODUCT         text                 null,
   AMOUNT               numeric(5)           null,
   DATE                 datetime             null,
   constraint PK_ORDERS_DETAIL primary key nonclustered (ORDER_ID)
)
go

/*==============================================================*/
/* Table: PRODUCTS                                              */
/*==============================================================*/
create table PRODUCTS (
   PRODUCTS_ID          int                  not null,
   REPORT_ID            int                  not null,
   NAME                 text                 null,
   TYPE_PRODUCT         text                 null,
   AMOUNT               numeric(5)           null,
   SHELF_NUMBER         numeric(2)           null,
   UPDATE_AT            datetime             null,
   EXPIRATION_DATE      datetime             null,
   BUY_PRICE            decimal(18)          null,
   ID_SUPPLIER          int                  null,
   constraint PK_PRODUCTS primary key nonclustered (PRODUCTS_ID)
)
go

/*==============================================================*/
/* Index: REPORT_FK                                             */
/*==============================================================*/
create index REPORT_FK on PRODUCTS (
REPORT_ID ASC
)
go

/*==============================================================*/
/* Table: PRODUCTS2                                             */
/*==============================================================*/
create table PRODUCTS2 (
   PRODUCTS_ID          int                  not null,
   SHELF_ID             int                  not null,
   constraint PK_PRODUCTS2 primary key (PRODUCTS_ID, SHELF_ID)
)
go

/*==============================================================*/
/* Index: PRODUCTS_FK                                           */
/*==============================================================*/
create index PRODUCTS_FK on PRODUCTS2 (
PRODUCTS_ID ASC
)
go

/*==============================================================*/
/* Index: PRODUCTS2_FK                                          */
/*==============================================================*/
create index PRODUCTS2_FK on PRODUCTS2 (
SHELF_ID ASC
)
go

/*==============================================================*/
/* Table: QUANTITIES_OF_PRODUCT                                 */
/*==============================================================*/
create table QUANTITIES_OF_PRODUCT (
   PRODUCTS_ID          int                  not null,
   ORDER_ID             int                  not null,
   constraint PK_QUANTITIES_OF_PRODUCT primary key (PRODUCTS_ID, ORDER_ID)
)
go

/*==============================================================*/
/* Index: QUANTITIES_OF_PRODUCT_FK                              */
/*==============================================================*/
create index QUANTITIES_OF_PRODUCT_FK on QUANTITIES_OF_PRODUCT (
PRODUCTS_ID ASC
)
go

/*==============================================================*/
/* Index: QUANTITIES_OF_PRODUCT2_FK                             */
/*==============================================================*/
create index QUANTITIES_OF_PRODUCT2_FK on QUANTITIES_OF_PRODUCT (
ORDER_ID ASC
)
go

/*==============================================================*/
/* Table: REPORT_FORM                                           */
/*==============================================================*/
create table REPORT_FORM (
   REPORT_ID            int                  not null,
   ID_PRODUCT           int                  null,
   NAME_PRODUCT         text                 null,
   INVENTORY_LEVEL      int                  null,
   AMOUNT               numeric(5)           null,
   DATE                 datetime             null,
   constraint PK_REPORT_FORM primary key nonclustered (REPORT_ID)
)
go

/*==============================================================*/
/* Table: SEND                                                  */
/*==============================================================*/
create table SEND (
   ORDER_ID             int                  not null,
   SUPPLIER_ID          int                  not null,
   constraint PK_SEND primary key (ORDER_ID, SUPPLIER_ID)
)
go

/*==============================================================*/
/* Index: SEND_FK                                               */
/*==============================================================*/
create index SEND_FK on SEND (
ORDER_ID ASC
)
go

/*==============================================================*/
/* Index: SEND2_FK                                              */
/*==============================================================*/
create index SEND2_FK on SEND (
SUPPLIER_ID ASC
)
go

/*==============================================================*/
/* Table: SHELF                                                 */
/*==============================================================*/
create table SHELF (
   SHELF_ID             int                  not null,
   NAME_SHELF           text                 null,
   TYPE_PRODUCT         text                 null,
   IDPRODUCT            int                  null,
   constraint PK_SHELF primary key nonclustered (SHELF_ID)
)
go

/*==============================================================*/
/* Table: STORAGE                                               */
/*==============================================================*/
create table STORAGE (
   PRODUCTS_ID          int                  not null,
   PRODUCT_ID           int                  not null,
   LEVEL_ID             int                  not null,
   constraint PK_STORAGE primary key (PRODUCTS_ID, PRODUCT_ID, LEVEL_ID)
)
go

/*==============================================================*/
/* Index: STORAGE_FK                                            */
/*==============================================================*/
create index STORAGE_FK on STORAGE (
PRODUCTS_ID ASC
)
go

/*==============================================================*/
/* Index: STORAGE2_FK                                           */
/*==============================================================*/
create index STORAGE2_FK on STORAGE (
PRODUCT_ID ASC,
LEVEL_ID ASC
)
go

/*==============================================================*/
/* Table: SUPPLIER                                              */
/*==============================================================*/
create table SUPPLIER (
   SUPPLIER_ID          int                  not null,
   NAME                 text                 null,
   TYPE_PRODUCT         text                 null,
   HOTLINE              numeric(10)          null,
   ADDRESS              text                 null,
   EMAIL                text                 null,
   PRICE                decimal(18)          null,
   constraint PK_SUPPLIER primary key nonclustered (SUPPLIER_ID)
)
go

alter table INVOICE_PAYMENT
   add constraint FK_INVOICE__BILLS_SUPPLIER foreign key (SUPPLIER_ID)
      references SUPPLIER (SUPPLIER_ID)
go

alter table INVOICE_PAYMENT
   add constraint FK_INVOICE__DETAILS_P_ORDERS_D foreign key (ORDER_ID)
      references ORDERS_DETAIL (ORDER_ID)
go

alter table ITEMS
   add constraint FK_ITEMS_ITEMS_SUPPLIER foreign key (SUPPLIER_ID)
      references SUPPLIER (SUPPLIER_ID)
go

alter table ITEMS
   add constraint FK_ITEMS_ITEMS2_PRODUCTS foreign key (PRODUCTS_ID)
      references PRODUCTS (PRODUCTS_ID)
go

alter table PRODUCTS
   add constraint FK_PRODUCTS_REPORT_REPORT_F foreign key (REPORT_ID)
      references REPORT_FORM (REPORT_ID)
go

alter table PRODUCTS2
   add constraint FK_PRODUCTS_PRODUCTS_PRODUCTS foreign key (PRODUCTS_ID)
      references PRODUCTS (PRODUCTS_ID)
go

alter table PRODUCTS2
   add constraint FK_PRODUCTS_PRODUCTS2_SHELF foreign key (SHELF_ID)
      references SHELF (SHELF_ID)
go

alter table QUANTITIES_OF_PRODUCT
   add constraint FK_QUANTITI_QUANTITIE_PRODUCTS foreign key (PRODUCTS_ID)
      references PRODUCTS (PRODUCTS_ID)
go

alter table QUANTITIES_OF_PRODUCT
   add constraint FK_QUANTITI_QUANTITIE_ORDERS_D foreign key (ORDER_ID)
      references ORDERS_DETAIL (ORDER_ID)
go

alter table SEND
   add constraint FK_SEND_SEND_ORDERS_D foreign key (ORDER_ID)
      references ORDERS_DETAIL (ORDER_ID)
go

alter table SEND
   add constraint FK_SEND_SEND2_SUPPLIER foreign key (SUPPLIER_ID)
      references SUPPLIER (SUPPLIER_ID)
go

alter table STORAGE
   add constraint FK_STORAGE_STORAGE_PRODUCTS foreign key (PRODUCTS_ID)
      references PRODUCTS (PRODUCTS_ID)
go

alter table STORAGE
   add constraint FK_STORAGE_STORAGE2_INVENTOR foreign key (PRODUCT_ID, LEVEL_ID)
      references INVENTORY_LEVEL (PRODUCT_ID, LEVEL_ID)
go

