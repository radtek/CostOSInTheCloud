﻿CREATE TABLE [dbo].[WSDATAMAPPING] (
    [ID]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [TITLE]         NVARCHAR (255) NULL,
    [CELLDTINGN]    NVARCHAR (MAX) NULL,
    [GROUPCOL]      INT            NULL,
    [TREEMAPPING]   NVARCHAR (MAX) NULL,
    [COMMENTDETECT] BIT            NULL,
    [TREEDETECT]    BIT            NULL,
    [TABLEPREFER]   NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
