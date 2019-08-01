﻿CREATE TABLE [dbo].[PRJDBMS] (
    [ID]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [HNAME]  VARCHAR (255) NULL,
    [HPORT]  VARCHAR (255) NULL,
    [HDBMS]  INT           NULL,
    [HINST]  VARCHAR (255) NULL,
    [HUSER]  VARCHAR (255) NULL,
    [HPASS]  VARCHAR (255) NULL,
    [DBNAME] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

