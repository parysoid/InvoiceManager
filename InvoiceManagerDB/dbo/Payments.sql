CREATE TABLE [dbo].[Payments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EmployeeId] INT NULL FOREIGN KEY REFERENCES dbo.Employees(Id), 
    [Value] SMALLMONEY NULL, 
    [Date] DATETIME NULL, 
    [Description] NVARCHAR(150) NULL, 
    [CreatedAt] DATETIME NULL, 
    [UpdatedAt] DATETIME NULL
)
