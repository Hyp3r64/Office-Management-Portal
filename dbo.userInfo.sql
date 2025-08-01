CREATE TABLE [dbo].[userInfo] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [name]   VARCHAR (50) NOT NULL,
    [uname]  VARCHAR (50) NOT NULL,
    [email]  VARCHAR (50) NOT NULL,
    [gender] VARCHAR (50) NULL,
    [pass]   VARCHAR (50) NOT NULL,
    [type]   VARCHAR (50) NOT NULL,
    [salary] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

