CREATE TABLE [dbo].[Log] (
    [Id]                    BIGINT         IDENTITY (1, 1) NOT NULL,
    [LogDateTime]           DATETIME       NOT NULL,
    [MachineName]           VARCHAR (50)   NULL,
    [Application]           VARCHAR (50)   NULL,
    [Identity]              VARCHAR (100)  NULL,
    [LoggerName]            VARCHAR (200)  NULL,
    [LogLevel]              VARCHAR (20)   NULL,
    [Message]               VARCHAR (MAX)  NULL,
    [ExceptionSource]       VARCHAR (200)  NULL,
    [ExceptionClass]        VARCHAR (200)  NULL,
    [ExceptionMethod]       VARCHAR (200)  NULL,
    [ExceptionError]        VARCHAR (1000) NULL,
    [ExceptionStackTrace]   VARCHAR (MAX)  NULL,
    [ExceptionInnerMessage] VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([Id] ASC)
);



