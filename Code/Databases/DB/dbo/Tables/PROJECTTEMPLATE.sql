﻿CREATE TABLE [dbo].[PROJECTTEMPLATE] (
    [ID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [TEMPLATEID]      BIGINT         NULL,
    [TITLE]           NVARCHAR (255) NULL,
    [EDITORID]        NVARCHAR (255) NULL,
    [USERID]          NVARCHAR (255) NULL,
    [LASTUPDATE]      DATETIME2 (7)  NULL,
    [CREATEDATE]      DATETIME2 (7)  NULL,
    [CREATEUSER]      NVARCHAR (255) NULL,
    [DATABASEID]      BIGINT         NULL,
    [DBCREATEDATE]    BIGINT         NULL,
    [PBLK]            BIT            NULL,
    [HASBUILDUPS]     BIT            NULL,
    [HASDISTRIBUTORS] BIT            NULL,
    [ALLOWVIEWERS]    BIT            NULL,
    [DESCRIPTION]     NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FKD8968A734DF865AC] FOREIGN KEY ([TEMPLATEID]) REFERENCES [dbo].[XCELLFILE] ([XCELLID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_MDBID]
    ON [dbo].[PROJECTTEMPLATE]([DATABASEID] ASC);

