﻿CREATE TABLE [dbo].[alcUserGroups] (
    [UserId]  UNIQUEIDENTIFIER NOT NULL,
    [GroupId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [alcUserGroups_I00] PRIMARY KEY CLUSTERED ([UserId] ASC, [GroupId] ASC)
);

