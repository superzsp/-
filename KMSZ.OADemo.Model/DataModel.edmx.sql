
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2016 15:32:59
-- Generated from EDMX file: D:\Program Files\Mvc\KMSZOADemo\KMSZ.OADemo\KMSZ.OADemo.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Book];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActioinInfoRole_ActioinInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActioinInfoRole] DROP CONSTRAINT [FK_ActioinInfoRole_ActioinInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActioinInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActioinInfoRole] DROP CONSTRAINT [FK_ActioinInfoRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoR_User_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_ActionInfo] DROP CONSTRAINT [FK_ActionInfoR_User_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentRole_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartmentRole] DROP CONSTRAINT [FK_DepartmentRole_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartmentRole] DROP CONSTRAINT [FK_DepartmentRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoDepartment_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoDepartment] DROP CONSTRAINT [FK_UserInfoDepartment_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoDepartment_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoDepartment] DROP CONSTRAINT [FK_UserInfoDepartment_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoR_User_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_ActionInfo] DROP CONSTRAINT [FK_UserInfoR_User_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRole] DROP CONSTRAINT [FK_UserInfoRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRole_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRole] DROP CONSTRAINT [FK_UserInfoRole_UserInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ActioinInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActioinInfoRole];
GO
IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[ActionInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfoRole];
GO
IF OBJECT_ID(N'[dbo].[Demo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Demo];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[DepartmentRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentRole];
GO
IF OBJECT_ID(N'[dbo].[R_User_ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_User_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfoDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoDepartment];
GO
IF OBJECT_ID(N'[dbo].[UserInfoMeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoMeta];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRole];
GO
IF OBJECT_ID(N'[dbo].[WorkTime]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkTime];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Pwd] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [DelFlag] smallint  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL,
    [SubBy] int  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [DelFlag] smallint  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL,
    [SubBy] int  NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DepName] nvarchar(max)  NOT NULL,
    [ParentId] int  NOT NULL,
    [DepMasterId] nvarchar(max)  NOT NULL,
    [DepNo] nvarchar(max)  NOT NULL,
    [IsLeaf] bit  NOT NULL,
    [Lever] int  NOT NULL,
    [TreePath] nvarchar(max)  NULL,
    [DelFlag] smallint  NULL,
    [SubTime] datetime  NULL,
    [SubBy] int  NULL
);
GO

-- Creating table 'WorkTime'
CREATE TABLE [dbo].[WorkTime] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubTime] datetime  NOT NULL,
    [OffTime] datetime  NOT NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DelFlag] smallint  NULL,
    [SubBy] int  NULL,
    [SubTime] datetime  NOT NULL,
    [Url] nvarchar(512)  NULL,
    [HttpMethod] varchar(32)  NULL,
    [ActionName] nvarchar(32)  NULL,
    [Remark] nvarchar(128)  NULL,
    [Controller] nvarchar(max)  NULL,
    [ActionMethod] nvarchar(max)  NULL
);
GO

-- Creating table 'R_User_ActionInfo'
CREATE TABLE [dbo].[R_User_ActionInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsPass] bit  NOT NULL,
    [UserInfoId] int  NOT NULL,
    [ActionInfoId] int  NOT NULL,
    [DelFlag] smallint  NULL
);
GO

-- Creating table 'UserInfoMeta'
CREATE TABLE [dbo].[UserInfoMeta] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [QQ] nvarchar(max)  NOT NULL,
    [Msn] nvarchar(max)  NOT NULL,
    [UserInfoId] int  NOT NULL,
    [DelFlag] smallint  NULL,
    [SubBy] int  NULL,
    [SubTime] datetime  NULL
);
GO

-- Creating table 'Demo'
CREATE TABLE [dbo].[Demo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(128)  NULL,
    [SubBy] int  NULL
);
GO

-- Creating table 'MenuInfo'
CREATE TABLE [dbo].[MenuInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MenuName] nvarchar(32)  NOT NULL,
    [ActionInfoId] int  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(128)  NULL,
    [SubBy] int  NULL,
    [Sort] int  NOT NULL,
    [IsVisable] bit  NOT NULL,
    [DialogHeight] int  NOT NULL,
    [DialogWidth] int  NOT NULL,
    [IconUrl] nvarchar(512)  NOT NULL,
    [ParentId] int  NOT NULL
);
GO

-- Creating table 'UserInfoRole'
CREATE TABLE [dbo].[UserInfoRole] (
    [UserInfo_Id] int  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'ActionInfoRole'
CREATE TABLE [dbo].[ActionInfoRole] (
    [ActionInfo_Id] int  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'UserInfoDepartment'
CREATE TABLE [dbo].[UserInfoDepartment] (
    [UserInfo_Id] int  NOT NULL,
    [Department_Id] int  NOT NULL
);
GO

-- Creating table 'DepartmentRole'
CREATE TABLE [dbo].[DepartmentRole] (
    [Department_Id] int  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'ActioinInfoRole'
CREATE TABLE [dbo].[ActioinInfoRole] (
    [ActionInfo1_Id] int  NOT NULL,
    [Role1_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkTime'
ALTER TABLE [dbo].[WorkTime]
ADD CONSTRAINT [PK_WorkTime]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'R_User_ActionInfo'
ALTER TABLE [dbo].[R_User_ActionInfo]
ADD CONSTRAINT [PK_R_User_ActionInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserInfoMeta'
ALTER TABLE [dbo].[UserInfoMeta]
ADD CONSTRAINT [PK_UserInfoMeta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Demo'
ALTER TABLE [dbo].[Demo]
ADD CONSTRAINT [PK_Demo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MenuInfo'
ALTER TABLE [dbo].[MenuInfo]
ADD CONSTRAINT [PK_MenuInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserInfo_Id], [Role_Id] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [PK_UserInfoRole]
    PRIMARY KEY CLUSTERED ([UserInfo_Id], [Role_Id] ASC);
GO

-- Creating primary key on [ActionInfo_Id], [Role_Id] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [PK_ActionInfoRole]
    PRIMARY KEY CLUSTERED ([ActionInfo_Id], [Role_Id] ASC);
GO

-- Creating primary key on [UserInfo_Id], [Department_Id] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [PK_UserInfoDepartment]
    PRIMARY KEY CLUSTERED ([UserInfo_Id], [Department_Id] ASC);
GO

-- Creating primary key on [Department_Id], [Role_Id] in table 'DepartmentRole'
ALTER TABLE [dbo].[DepartmentRole]
ADD CONSTRAINT [PK_DepartmentRole]
    PRIMARY KEY CLUSTERED ([Department_Id], [Role_Id] ASC);
GO

-- Creating primary key on [ActionInfo1_Id], [Role1_Id] in table 'ActioinInfoRole'
ALTER TABLE [dbo].[ActioinInfoRole]
ADD CONSTRAINT [PK_ActioinInfoRole]
    PRIMARY KEY CLUSTERED ([ActionInfo1_Id], [Role1_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_Id] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_UserInfo]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_Id] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRole_Role'
CREATE INDEX [IX_FK_UserInfoRole_Role]
ON [dbo].[UserInfoRole]
    ([Role_Id]);
GO

-- Creating foreign key on [ActionInfo_Id] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_ActionInfo]
    FOREIGN KEY ([ActionInfo_Id])
    REFERENCES [dbo].[ActionInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_Id] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoRole_Role'
CREATE INDEX [IX_FK_ActionInfoRole_Role]
ON [dbo].[ActionInfoRole]
    ([Role_Id]);
GO

-- Creating foreign key on [UserInfoId] in table 'R_User_ActionInfo'
ALTER TABLE [dbo].[R_User_ActionInfo]
ADD CONSTRAINT [FK_UserInfoR_User_ActionInfo]
    FOREIGN KEY ([UserInfoId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_User_ActionInfo'
CREATE INDEX [IX_FK_UserInfoR_User_ActionInfo]
ON [dbo].[R_User_ActionInfo]
    ([UserInfoId]);
GO

-- Creating foreign key on [ActionInfoId] in table 'R_User_ActionInfo'
ALTER TABLE [dbo].[R_User_ActionInfo]
ADD CONSTRAINT [FK_ActionInfoR_User_ActionInfo]
    FOREIGN KEY ([ActionInfoId])
    REFERENCES [dbo].[ActionInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoR_User_ActionInfo'
CREATE INDEX [IX_FK_ActionInfoR_User_ActionInfo]
ON [dbo].[R_User_ActionInfo]
    ([ActionInfoId]);
GO

-- Creating foreign key on [UserInfo_Id] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [FK_UserInfoDepartment_UserInfo]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Department_Id] in table 'UserInfoDepartment'
ALTER TABLE [dbo].[UserInfoDepartment]
ADD CONSTRAINT [FK_UserInfoDepartment_Department]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[Department]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoDepartment_Department'
CREATE INDEX [IX_FK_UserInfoDepartment_Department]
ON [dbo].[UserInfoDepartment]
    ([Department_Id]);
GO

-- Creating foreign key on [Department_Id] in table 'DepartmentRole'
ALTER TABLE [dbo].[DepartmentRole]
ADD CONSTRAINT [FK_DepartmentRole_Department]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[Department]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_Id] in table 'DepartmentRole'
ALTER TABLE [dbo].[DepartmentRole]
ADD CONSTRAINT [FK_DepartmentRole_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentRole_Role'
CREATE INDEX [IX_FK_DepartmentRole_Role]
ON [dbo].[DepartmentRole]
    ([Role_Id]);
GO

-- Creating foreign key on [ActionInfo1_Id] in table 'ActioinInfoRole'
ALTER TABLE [dbo].[ActioinInfoRole]
ADD CONSTRAINT [FK_ActioinInfoRole_ActionInfo]
    FOREIGN KEY ([ActionInfo1_Id])
    REFERENCES [dbo].[ActionInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role1_Id] in table 'ActioinInfoRole'
ALTER TABLE [dbo].[ActioinInfoRole]
ADD CONSTRAINT [FK_ActioinInfoRole_Role]
    FOREIGN KEY ([Role1_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActioinInfoRole_Role'
CREATE INDEX [IX_FK_ActioinInfoRole_Role]
ON [dbo].[ActioinInfoRole]
    ([Role1_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------