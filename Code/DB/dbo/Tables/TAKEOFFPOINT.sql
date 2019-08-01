﻿CREATE TABLE [dbo].[TAKEOFFPOINT] (
    [ID]         BIGINT           IDENTITY (1, 1) NOT NULL,
    [ZPOS]       NUMERIC (30, 10) NULL,
    [XPOS]       NUMERIC (30, 10) NULL,
    [YPOS]       NUMERIC (30, 10) NULL,
    [PID]        BIGINT           NULL,
    [SID]        BIGINT           NULL,
    [CID]        BIGINT           NULL,
    [POLYCOUNT]  INT              NULL,
    [POINTCOUNT] INT              NULL,
    [ELEVCOUNT]  INT              NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FKDDC25B083EBE9FEE] FOREIGN KEY ([CID]) REFERENCES [dbo].[TAKEOFFCON] ([ID]),
    CONSTRAINT [FKDDC25B08412B92EF] FOREIGN KEY ([PID]) REFERENCES [dbo].[TAKEOFFAREA] ([ID]),
    CONSTRAINT [FKDDC25B08DC1D472B] FOREIGN KEY ([SID]) REFERENCES [dbo].[TAKEOFFLINE] ([ID])
);

