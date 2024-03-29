﻿CREATE TABLE [dbo].[BC_GROUP] (
    [ID]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [DESCRIPTION] NVARCHAR (1024) NULL,
    [GLOBALID]    NVARCHAR (256)  NULL,
    [NAME]        NVARCHAR (256)  NULL,
    [TYPE]        NVARCHAR (256)  NULL,
    [MODEL_ID]    BIGINT          NULL,
    [PARENT_ID]   BIGINT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK467A74E14160E6D4] FOREIGN KEY ([MODEL_ID]) REFERENCES [dbo].[BC_MODEL] ([ID]),
    CONSTRAINT [FK467A74E1B0A6081D] FOREIGN KEY ([PARENT_ID]) REFERENCES [dbo].[BC_GROUP] ([ID])
);

