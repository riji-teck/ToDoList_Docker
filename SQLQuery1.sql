CREATE TABLE [dbo].[ToDoList] (
    [Id] INT NOT NULL IDENTITY PRIMARY KEY,
    [StartDate] DATE NULL,
    [EndDate]   DATE NULL,
    [IsActive]  BIT  NULL,
    [Content] NVARCHAR(MAX) NULL
);
