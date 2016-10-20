CREATE TABLE [dbo].[Employments] (
    [Id]        SMALLINT DEFAULT (newsequentialid()) NOT NULL,
    [Name]      NVARCHAR (MAX)   NULL,
    [Price]     DECIMAL (18, 2)  NOT NULL,
    [Category]  NVARCHAR (MAX)   NULL,
    [person_Id] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_dbo.Employments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Employments_dbo.People_person_Id] FOREIGN KEY ([person_Id]) REFERENCES [dbo].[People] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_person_Id]
    ON [dbo].[Employments]([person_Id] ASC);

