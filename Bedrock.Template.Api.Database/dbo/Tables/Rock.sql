CREATE TABLE [dbo].[Rock] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [RockTypeId]  INT             NOT NULL,
    [Name]        VARCHAR (100)   NOT NULL,
    [Description] VARCHAR (200)   NOT NULL,
    [Weight]      DECIMAL (10, 2) NOT NULL,
    [CreatedBy]   INT             NOT NULL,
    [CreatedDate] DATETIME2 (3)   NOT NULL,
    [UpdatedBy]   INT             NOT NULL,
    [UpdatedDate] DATETIME2 (3)   NOT NULL,
    [DeletedBy]   INT             NULL,
    [DeletedDate] DATETIME2 (3)   NULL,
    CONSTRAINT [PK_Rock] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rock_RockType] FOREIGN KEY ([RockTypeId]) REFERENCES [dbo].[RockType] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Rock_RockTypeId]
    ON [dbo].[Rock]([RockTypeId] ASC);

