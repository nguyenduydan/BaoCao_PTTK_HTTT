
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2023 19:38:12
-- Generated from EDMX file: E:\HK1_Nam3\PTTK HTTH\Web_Admin\BaoCao_PTTK_HTTT\QuanLyKhoHang\Models\Model_QLKH.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLKH];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DONDATHA_LAY_NHACUNGC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DONDATHANG] DROP CONSTRAINT [FK_DONDATHA_LAY_NHACUNGC];
GO
IF OBJECT_ID(N'[dbo].[FK_SANPHAM_CUNGCAP_NHACUNGC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SANPHAM] DROP CONSTRAINT [FK_SANPHAM_CUNGCAP_NHACUNGC];
GO
IF OBJECT_ID(N'[dbo].[FK_SANPHAM_LUUTRU_KEHANG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SANPHAM] DROP CONSTRAINT [FK_SANPHAM_LUUTRU_KEHANG];
GO
IF OBJECT_ID(N'[dbo].[FK_THONGTIN_THONGTINB_BANBAOCA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[THONGTINBAOCAO] DROP CONSTRAINT [FK_THONGTIN_THONGTINB_BANBAOCA];
GO
IF OBJECT_ID(N'[dbo].[FK_THONGTIN_THONGTINB_SANPHAM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[THONGTINBAOCAO] DROP CONSTRAINT [FK_THONGTIN_THONGTINB_SANPHAM];
GO
IF OBJECT_ID(N'[dbo].[FK_THONGTIN_THONGTIND_DONDATHA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[THONGTINDDH] DROP CONSTRAINT [FK_THONGTIN_THONGTIND_DONDATHA];
GO
IF OBJECT_ID(N'[dbo].[FK_THONGTIN_THONGTIND_SANPHAM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[THONGTINDDH] DROP CONSTRAINT [FK_THONGTIN_THONGTIND_SANPHAM];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BANBAOCAO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BANBAOCAO];
GO
IF OBJECT_ID(N'[dbo].[DONDATHANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DONDATHANG];
GO
IF OBJECT_ID(N'[dbo].[KEHANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KEHANG];
GO
IF OBJECT_ID(N'[dbo].[NHACUNGCAP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NHACUNGCAP];
GO
IF OBJECT_ID(N'[dbo].[SANPHAM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SANPHAM];
GO
IF OBJECT_ID(N'[dbo].[THONGTINBAOCAO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[THONGTINBAOCAO];
GO
IF OBJECT_ID(N'[dbo].[THONGTINDDH]', 'U') IS NOT NULL
    DROP TABLE [dbo].[THONGTINDDH];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BANBAOCAO'
CREATE TABLE [dbo].[BANBAOCAO] (
    [MA_BAOCAO] varchar(10)  NOT NULL,
    [NGAYBAOCAO] datetime  NULL
);
GO

-- Creating table 'DONDATHANG'
CREATE TABLE [dbo].[DONDATHANG] (
    [MA_DATHANG] varchar(10)  NOT NULL,
    [MA_NCCAP] varchar(10)  NOT NULL,
    [NGAY_DATHANG] datetime  NULL
);
GO

-- Creating table 'KEHANG'
CREATE TABLE [dbo].[KEHANG] (
    [MA_KEHANG] varchar(10)  NOT NULL,
    [LOAISP] nvarchar(100)  NULL,
    [VITRI] nvarchar(20)  NULL
);
GO

-- Creating table 'NHACUNGCAP'
CREATE TABLE [dbo].[NHACUNGCAP] (
    [MA_NCCAP] varchar(10)  NOT NULL,
    [TEN_NCCAP] nvarchar(100)  NULL,
    [LOAISP] nvarchar(100)  NULL,
    [SDT] decimal(10,0)  NULL,
    [DIACHI] nchar(200)  NULL,
    [EMAIL] nchar(100)  NULL,
    [NGAYTAO] datetime  NULL,
    [NGAYCAPNHAT] datetime  NULL
);
GO

-- Creating table 'SANPHAM'
CREATE TABLE [dbo].[SANPHAM] (
    [MASP] varchar(10)  NOT NULL,
    [MA_KEHANG] varchar(10)  NOT NULL,
    [MA_NCCAP] varchar(10)  NOT NULL,
    [TENSP] nvarchar(100)  NULL,
    [LOAISP] nvarchar(100)  NULL,
    [TENTOMTAT] varchar(100)  NULL,
    [SOLUONG] int  NULL,
    [NGAYTAO] datetime  NULL,
    [NGAYCAPNHAT] datetime  NULL,
    [NGAYHETHAN] datetime  NULL,
    [GIATIEN] decimal(18,0)  NULL,
    [TRANGTHAI] tinyint  NULL
);
GO

-- Creating table 'THONGTINBAOCAO'
CREATE TABLE [dbo].[THONGTINBAOCAO] (
    [MASP] varchar(10)  NOT NULL,
    [MA_BAOCAO] varchar(10)  NOT NULL,
    [TENSP] nvarchar(100)  NULL,
    [SOLUONG] int  NULL
);
GO

-- Creating table 'THONGTINDDH'
CREATE TABLE [dbo].[THONGTINDDH] (
    [MA_DATHANG] varchar(10)  NOT NULL,
    [MASP] varchar(10)  NOT NULL,
    [SOLUONG] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MA_BAOCAO] in table 'BANBAOCAO'
ALTER TABLE [dbo].[BANBAOCAO]
ADD CONSTRAINT [PK_BANBAOCAO]
    PRIMARY KEY CLUSTERED ([MA_BAOCAO] ASC);
GO

-- Creating primary key on [MA_DATHANG] in table 'DONDATHANG'
ALTER TABLE [dbo].[DONDATHANG]
ADD CONSTRAINT [PK_DONDATHANG]
    PRIMARY KEY CLUSTERED ([MA_DATHANG] ASC);
GO

-- Creating primary key on [MA_KEHANG] in table 'KEHANG'
ALTER TABLE [dbo].[KEHANG]
ADD CONSTRAINT [PK_KEHANG]
    PRIMARY KEY CLUSTERED ([MA_KEHANG] ASC);
GO

-- Creating primary key on [MA_NCCAP] in table 'NHACUNGCAP'
ALTER TABLE [dbo].[NHACUNGCAP]
ADD CONSTRAINT [PK_NHACUNGCAP]
    PRIMARY KEY CLUSTERED ([MA_NCCAP] ASC);
GO

-- Creating primary key on [MASP] in table 'SANPHAM'
ALTER TABLE [dbo].[SANPHAM]
ADD CONSTRAINT [PK_SANPHAM]
    PRIMARY KEY CLUSTERED ([MASP] ASC);
GO

-- Creating primary key on [MASP], [MA_BAOCAO] in table 'THONGTINBAOCAO'
ALTER TABLE [dbo].[THONGTINBAOCAO]
ADD CONSTRAINT [PK_THONGTINBAOCAO]
    PRIMARY KEY CLUSTERED ([MASP], [MA_BAOCAO] ASC);
GO

-- Creating primary key on [MA_DATHANG], [MASP] in table 'THONGTINDDH'
ALTER TABLE [dbo].[THONGTINDDH]
ADD CONSTRAINT [PK_THONGTINDDH]
    PRIMARY KEY CLUSTERED ([MA_DATHANG], [MASP] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MA_BAOCAO] in table 'THONGTINBAOCAO'
ALTER TABLE [dbo].[THONGTINBAOCAO]
ADD CONSTRAINT [FK_THONGTIN_THONGTINB_BANBAOCA]
    FOREIGN KEY ([MA_BAOCAO])
    REFERENCES [dbo].[BANBAOCAO]
        ([MA_BAOCAO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_THONGTIN_THONGTINB_BANBAOCA'
CREATE INDEX [IX_FK_THONGTIN_THONGTINB_BANBAOCA]
ON [dbo].[THONGTINBAOCAO]
    ([MA_BAOCAO]);
GO

-- Creating foreign key on [MA_NCCAP] in table 'DONDATHANG'
ALTER TABLE [dbo].[DONDATHANG]
ADD CONSTRAINT [FK_DONDATHA_LAY_NHACUNGC]
    FOREIGN KEY ([MA_NCCAP])
    REFERENCES [dbo].[NHACUNGCAP]
        ([MA_NCCAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DONDATHA_LAY_NHACUNGC'
CREATE INDEX [IX_FK_DONDATHA_LAY_NHACUNGC]
ON [dbo].[DONDATHANG]
    ([MA_NCCAP]);
GO

-- Creating foreign key on [MA_DATHANG] in table 'THONGTINDDH'
ALTER TABLE [dbo].[THONGTINDDH]
ADD CONSTRAINT [FK_THONGTIN_THONGTIND_DONDATHA]
    FOREIGN KEY ([MA_DATHANG])
    REFERENCES [dbo].[DONDATHANG]
        ([MA_DATHANG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MA_KEHANG] in table 'SANPHAM'
ALTER TABLE [dbo].[SANPHAM]
ADD CONSTRAINT [FK_SANPHAM_LUUTRU_KEHANG]
    FOREIGN KEY ([MA_KEHANG])
    REFERENCES [dbo].[KEHANG]
        ([MA_KEHANG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SANPHAM_LUUTRU_KEHANG'
CREATE INDEX [IX_FK_SANPHAM_LUUTRU_KEHANG]
ON [dbo].[SANPHAM]
    ([MA_KEHANG]);
GO

-- Creating foreign key on [MA_NCCAP] in table 'SANPHAM'
ALTER TABLE [dbo].[SANPHAM]
ADD CONSTRAINT [FK_SANPHAM_CUNGCAP_NHACUNGC]
    FOREIGN KEY ([MA_NCCAP])
    REFERENCES [dbo].[NHACUNGCAP]
        ([MA_NCCAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SANPHAM_CUNGCAP_NHACUNGC'
CREATE INDEX [IX_FK_SANPHAM_CUNGCAP_NHACUNGC]
ON [dbo].[SANPHAM]
    ([MA_NCCAP]);
GO

-- Creating foreign key on [MASP] in table 'THONGTINBAOCAO'
ALTER TABLE [dbo].[THONGTINBAOCAO]
ADD CONSTRAINT [FK_THONGTIN_THONGTINB_SANPHAM]
    FOREIGN KEY ([MASP])
    REFERENCES [dbo].[SANPHAM]
        ([MASP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MASP] in table 'THONGTINDDH'
ALTER TABLE [dbo].[THONGTINDDH]
ADD CONSTRAINT [FK_THONGTIN_THONGTIND_SANPHAM]
    FOREIGN KEY ([MASP])
    REFERENCES [dbo].[SANPHAM]
        ([MASP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_THONGTIN_THONGTIND_SANPHAM'
CREATE INDEX [IX_FK_THONGTIN_THONGTIND_SANPHAM]
ON [dbo].[THONGTINDDH]
    ([MASP]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------