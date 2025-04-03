IF OBJECT_ID(N'[dbo].[__EFMigrationHistory]') IS NULL
BEGIN
    CREATE TABLE [dbo].[__EFMigrationHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [dbo].[__EFMigrationHistory] WHERE [MigrationId] = N'20250403192243_initial01')
BEGIN
    CREATE TABLE [dbo].[Tests] (
        [TestId] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Created] datetime2 NOT NULL,
        [Modified] datetime2 NULL,
        [Deleted] datetime2 NULL,
        CONSTRAINT [PK_Tests] PRIMARY KEY ([TestId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [dbo].[__EFMigrationHistory] WHERE [MigrationId] = N'20250403192243_initial01')
BEGIN
    INSERT INTO [dbo].[__EFMigrationHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250403192243_initial01', N'7.0.0');
END;
GO

COMMIT;
GO

