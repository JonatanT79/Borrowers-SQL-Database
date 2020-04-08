CREATE TABLE [dbo].[Exemplar] (
    [ProduktID]          INT           NULL,
    [Indificationsvärde] VARCHAR (255) NOT NULL,
    [Status_Exemplar]    VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Indificationsvärde] ASC)
);

