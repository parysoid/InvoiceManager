CREATE TABLE [dbo].[Invoices]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] INT NULL, 
    [Description] NVARCHAR(150) NULL, 
    [Value] INT NULL, 
    [CreatedAt] DATETIME NULL, 
    [UpdatedAt] DATETIME NULL, 
    [Date] DATE NULL

)
