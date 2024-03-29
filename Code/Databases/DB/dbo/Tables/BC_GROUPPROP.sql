﻿CREATE TABLE [dbo].[BC_GROUPPROP] (
    [ID]       BIGINT           IDENTITY (1, 1) NOT NULL,
    [GRPNAME]  NVARCHAR (256)   NULL,
    [NAME]     NVARCHAR (256)   NULL,
    [ISNUM]    BIT              NULL,
    [NUMVAL]   NUMERIC (30, 10) NULL,
    [QTYTYPE]  INT              NULL,
    [TXTVAL]   NVARCHAR (MAX)   NULL,
    [GROUP_ID] BIGINT           NULL,
    [MODEL_ID] BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FKE8A8B7C44160E6D4] FOREIGN KEY ([MODEL_ID]) REFERENCES [dbo].[BC_MODEL] ([ID]),
    CONSTRAINT [FKE8A8B7C4536DCE28] FOREIGN KEY ([GROUP_ID]) REFERENCES [dbo].[BC_GROUP] ([ID])
);

