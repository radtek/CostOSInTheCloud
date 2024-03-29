﻿CREATE TABLE [dbo].[QUOTETEMPLATE] (
    [ID]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [XCELLFILE]  VARBINARY (MAX) NULL,
    [EDITORID]   NVARCHAR (255)  NULL,
    [CREATEDATE] DATETIME2 (7)   NULL,
    [LASTUPDATE] DATETIME2 (7)   NULL,
    [TITLE]      NVARCHAR (MAX)  NULL,
    [ISMATERIAL] BIT             NULL,
    [LAYOUTID]   BIGINT          NULL,
    [DFLT]       BIT             NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

