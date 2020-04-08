CREATE TABLE [dbo].[Användare] (
    [ID]        INT           NOT NULL,
    [Förnamn]   VARCHAR (255) NULL,
    [Efternamn] VARCHAR (255) NULL,
    [Ålder]     INT           NULL,
    [RollID]    INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([RollID]) REFERENCES [dbo].[Roller] ([ID])
);

