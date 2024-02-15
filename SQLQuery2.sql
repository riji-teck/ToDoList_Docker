DROP TABLE ToDoList;

CREATE TABLE [dbo].[ToDoList] (
    [Id]      INT  NOT NULL IDENTITY(1,1),
    [Content] TEXT NOT NULL,
    CONSTRAINT [PK_ToDoList] PRIMARY KEY CLUSTERED ([Id] ASC)
);


SET IDENTITY_INSERT [dbo].[ToDoList].[Id] ON
go
