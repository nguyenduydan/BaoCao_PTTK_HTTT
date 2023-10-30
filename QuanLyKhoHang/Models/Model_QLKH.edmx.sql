
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/30/2023 11:10:09
-- Generated from EDMX file: E:\HK1_2024\PTTKHTTT\tt\QuanLyKhoHang\Models\Model_QLKH.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BANBAOCAO'
CREATE TABLE [dbo].[BANBAOCAO] (
    [MA_BAOCAO] varchar(10)  NOT NULL,
    [SOLUONG] decimal(5,0)  NULL,
    [NGAYBAOCAO] datetime  NULL
);
GO

-- Creating table 'DATVAO'
CREATE TABLE [dbo].[DATVAO] (
    [MASP] varchar(10)  NOT NULL,
    [MA_KEHANG] varchar(10)  NOT NULL,
    [SOLUONG] decimal(18,0)  NULL
);
GO

-- Creating table 'DONDATHANG'
CREATE TABLE [dbo].[DONDATHANG] (
    [MA_DATHANG] varchar(10)  NOT NULL,
    [TEN_SP] nvarchar(100)  NULL,
    [MA_NCCAP] varchar(10)  NOT NULL,
    [SOLUONG] decimal(5,0)  NULL,
    [NGAY_DATHANG] datetime  NULL
);
GO

-- Creating table 'DONTHANHTOAN'
CREATE TABLE [dbo].[DONTHANHTOAN] (
    [MATT] varchar(10)  NOT NULL,
    [TENSP] nvarchar(100)  NULL,
    [NGAYTHANHTOAN] datetime  NULL,
    [SOLUONG] decimal(5,0)  NULL,
    [GIACA] decimal(18,0)  NULL
);
GO

-- Creating table 'HANGTON'
CREATE TABLE [dbo].[HANGTON] (
    [MASP] varchar(10)  NOT NULL,
    [MA_HANGTON] varchar(10)  NOT NULL,
    [SOLUONG] decimal(5,0)  NULL,
    [MOTA_HANGTON] nvarchar(1000)  NULL,
    [NGAYHETHAN] datetime  NULL
);
GO

-- Creating table 'KEHANG'
CREATE TABLE [dbo].[KEHANG] (
    [MA_KEHANG] varchar(10)  NOT NULL,
    [TEN_KEHANG] nvarchar(100)  NULL,
    [MOTA_KEHANG] nvarchar(1000)  NULL
);
GO

-- Creating table 'NHACUNGCAP'
CREATE TABLE [dbo].[NHACUNGCAP] (
    [MA_NCCAP] varchar(10)  NOT NULL,
    [TEN_NCCAP] nvarchar(100)  NULL,
    [LOAISP] nvarchar(100)  NULL,
    [SDT] decimal(10,0)  NULL,
    [DIACHI] nchar(200)  NULL,
    [EMAIL] nchar(100)  NULL
);
GO

-- Creating table 'SANPHAM'
CREATE TABLE [dbo].[SANPHAM] (
    [MASP] varchar(10)  NOT NULL,
    [MA_DATHANG] varchar(10)  NOT NULL,
    [MA_BAOCAO] varchar(10)  NOT NULL,
    [TENSP] nvarchar(100)  NULL,
    [LOAISP] nvarchar(100)  NULL,
    [TENTOMTAT] varchar(100)  NULL,
    [SOLUONG] decimal(5,0)  NULL,
    [NGAYTAO] datetime  NULL,
    [NGAYCAPNHAT] datetime  NULL,
    [NGAYHETHAN] datetime  NULL,
    [GIACA] decimal(18,0)  NULL,
    [MA_NCCAP] varchar(10)  NOT NULL
);
GO

-- Creating table 'KIEMTRA'
CREATE TABLE [dbo].[KIEMTRA] (
    [DONDATHANG_MA_DATHANG] varchar(10)  NOT NULL,
    [DONTHANHTOAN_MATT] varchar(10)  NOT NULL
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

-- Creating primary key on [MASP], [MA_KEHANG] in table 'DATVAO'
ALTER TABLE [dbo].[DATVAO]
ADD CONSTRAINT [PK_DATVAO]
    PRIMARY KEY CLUSTERED ([MASP], [MA_KEHANG] ASC);
GO

-- Creating primary key on [MA_DATHANG] in table 'DONDATHANG'
ALTER TABLE [dbo].[DONDATHANG]
ADD CONSTRAINT [PK_DONDATHANG]
    PRIMARY KEY CLUSTERED ([MA_DATHANG] ASC);
GO

-- Creating primary key on [MATT] in table 'DONTHANHTOAN'
ALTER TABLE [dbo].[DONTHANHTOAN]
ADD CONSTRAINT [PK_DONTHANHTOAN]
    PRIMARY KEY CLUSTERED ([MATT] ASC);
GO

-- Creating primary key on [MASP], [MA_HANGTON] in table 'HANGTON'
ALTER TABLE [dbo].[HANGTON]
ADD CONSTRAINT [PK_HANGTON]
    PRIMARY KEY CLUSTERED ([MASP], [MA_HANGTON] ASC);
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

-- Creating primary key on [DONDATHANG_MA_DATHANG], [DONTHANHTOAN_MATT] in table 'KIEMTRA'
ALTER TABLE [dbo].[KIEMTRA]
ADD CONSTRAINT [PK_KIEMTRA]
    PRIMARY KEY CLUSTERED ([DONDATHANG_MA_DATHANG], [DONTHANHTOAN_MATT] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MA_BAOCAO] in table 'SANPHAM'
ALTER TABLE [dbo].[SANPHAM]
ADD CONSTRAINT [FK_SANPHAM_BAOCAO_BANBAOCA]
    FOREIGN KEY ([MA_BAOCAO])
    REFERENCES [dbo].[BANBAOCAO]
        ([MA_BAOCAO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SANPHAM_BAOCAO_BANBAOCA'
CREATE INDEX [IX_FK_SANPHAM_BAOCAO_BANBAOCA]
ON [dbo].[SANPHAM]
    ([MA_BAOCAO]);
GO

-- Creating foreign key on [MA_KEHANG] in table 'DATVAO'
ALTER TABLE [dbo].[DATVAO]
ADD CONSTRAINT [FK_DATVAO_DATVAO_KEHANG]
    FOREIGN KEY ([MA_KEHANG])
    REFERENCES [dbo].[KEHANG]
        ([MA_KEHANG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DATVAO_DATVAO_KEHANG'
CREATE INDEX [IX_FK_DATVAO_DATVAO_KEHANG]
ON [dbo].[DATVAO]
    ([MA_KEHANG]);
GO

-- Creating foreign key on [MASP] in table 'DATVAO'
ALTER TABLE [dbo].[DATVAO]
ADD CONSTRAINT [FK_DATVAO_DATVAO2_SANPHAM]
    FOREIGN KEY ([MASP])
    REFERENCES [dbo].[SANPHAM]
        ([MASP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
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

-- Creating foreign key on [MA_DATHANG] in table 'SANPHAM'
ALTER TABLE [dbo].[SANPHAM]
ADD CONSTRAINT [FK_SANPHAM_DATHANG_DONDATHA]
    FOREIGN KEY ([MA_DATHANG])
    REFERENCES [dbo].[DONDATHANG]
        ([MA_DATHANG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SANPHAM_DATHANG_DONDATHA'
CREATE INDEX [IX_FK_SANPHAM_DATHANG_DONDATHA]
ON [dbo].[SANPHAM]
    ([MA_DATHANG]);
GO

-- Creating foreign key on [MASP] in table 'HANGTON'
ALTER TABLE [dbo].[HANGTON]
ADD CONSTRAINT [FK_HANGTON_LUUTRU_SANPHAM]
    FOREIGN KEY ([MASP])
    REFERENCES [dbo].[SANPHAM]
        ([MASP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DONDATHANG_MA_DATHANG] in table 'KIEMTRA'
ALTER TABLE [dbo].[KIEMTRA]
ADD CONSTRAINT [FK_KIEMTRA_DONDATHANG]
    FOREIGN KEY ([DONDATHANG_MA_DATHANG])
    REFERENCES [dbo].[DONDATHANG]
        ([MA_DATHANG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DONTHANHTOAN_MATT] in table 'KIEMTRA'
ALTER TABLE [dbo].[KIEMTRA]
ADD CONSTRAINT [FK_KIEMTRA_DONTHANHTOAN]
    FOREIGN KEY ([DONTHANHTOAN_MATT])
    REFERENCES [dbo].[DONTHANHTOAN]
        ([MATT])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KIEMTRA_DONTHANHTOAN'
CREATE INDEX [IX_FK_KIEMTRA_DONTHANHTOAN]
ON [dbo].[KIEMTRA]
    ([DONTHANHTOAN_MATT]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------