CREATE TABLE [dbo].[Roller] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [Nuvarande Roll] VARCHAR (255) NULL,
    [Rättnivå]       VARCHAR (255) NULL,
    [DåvarandeJobb]  VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

