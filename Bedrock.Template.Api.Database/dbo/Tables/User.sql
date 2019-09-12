CREATE TABLE [dbo].[User] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Username]    VARCHAR (100)    NOT NULL,
    [GlobalKey]   UNIQUEIDENTIFIER NOT NULL,
    [CreatedBy]   INT              NOT NULL,
    [CreatedDate] DATETIME2 (3)    NOT NULL,
    [UpdatedBy]   INT              NULL,
    [UpdatedDate] DATETIME2 (3)    NULL,
    [DeletedBy]   INT              NULL,
    [DeletedDate] DATETIME2 (3)    NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_User_GlobalKey_DeletedDate] UNIQUE NONCLUSTERED ([GlobalKey] ASC, [DeletedDate] ASC),
    CONSTRAINT [UK_User_Username_DeletedDate] UNIQUE NONCLUSTERED ([Username] ASC, [DeletedDate] ASC)
);

