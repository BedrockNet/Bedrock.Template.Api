CREATE TABLE [dbo].[RockType] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (200) NOT NULL,
    [SortOrder]   INT           NOT NULL,
    CONSTRAINT [PK_RockType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_RockType_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

