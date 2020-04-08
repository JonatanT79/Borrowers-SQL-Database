CREATE TABLE [dbo].[Products] (
    [ID]          INT           NOT NULL,
    [LåneProdukt] VARCHAR (255) NULL,
    [Beskrivning] VARCHAR (255) NULL,
    [Kategori]    VARCHAR (255) NULL,
    [Pris]        INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [idx_ProduktNamn]
    ON [dbo].[Products]([LåneProdukt] ASC);

