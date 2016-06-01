
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2016 16:09:19
-- Generated from EDMX file: C:\Users\diogo\Desktop\College\TDIN\Trabalho 2\StockMarket\StockServiceHost\StockServiceModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StockMarketDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StockOrderOrderType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockOrders] DROP CONSTRAINT [FK_StockOrderOrderType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StockOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockOrders];
GO
IF OBJECT_ID(N'[dbo].[OrderTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StockOrders'
CREATE TABLE [dbo].[StockOrders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [StockValue] float  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Company] nvarchar(max)  NOT NULL,
    [RequestDate] nvarchar(max)  NOT NULL,
    [ExecutionDate] nvarchar(max)  NOT NULL,
    [Type_Id] int  NOT NULL
);
GO

-- Creating table 'OrderTypes'
CREATE TABLE [dbo].[OrderTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StockOrders'
ALTER TABLE [dbo].[StockOrders]
ADD CONSTRAINT [PK_StockOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderTypes'
ALTER TABLE [dbo].[OrderTypes]
ADD CONSTRAINT [PK_OrderTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Type_Id] in table 'StockOrders'
ALTER TABLE [dbo].[StockOrders]
ADD CONSTRAINT [FK_StockOrderOrderType]
    FOREIGN KEY ([Type_Id])
    REFERENCES [dbo].[OrderTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockOrderOrderType'
CREATE INDEX [IX_FK_StockOrderOrderType]
ON [dbo].[StockOrders]
    ([Type_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------