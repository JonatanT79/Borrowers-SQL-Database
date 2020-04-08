CREATE TABLE [dbo].[Orders] (
    [OrdersID]         INT           NULL,
    [CustomerID]       INT           NULL,
    [LåneID]           INT           NULL,
    [ExemplarID]       VARCHAR (255) NULL,
    [Lånedatum]        DATE          NULL,
    [InlämmningsDatum] DATE          NULL,
    [Borttappad]       VARCHAR (255) NULL,
    [SummaAttBetala]   INT           NULL,
    [LånadesUtAv]      INT           NULL,
    [LämnadesIn]       VARCHAR (255) NULL,
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Användare] ([ID]),
    FOREIGN KEY ([ExemplarID]) REFERENCES [dbo].[Exemplar] ([Indificationsvärde]),
    FOREIGN KEY ([LånadesUtAv]) REFERENCES [dbo].[Personal] ([ID]),
    FOREIGN KEY ([LåneID]) REFERENCES [dbo].[Products] ([ID]),
    CONSTRAINT [FK_Orders_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Användare] ([ID]) ON DELETE CASCADE
);

