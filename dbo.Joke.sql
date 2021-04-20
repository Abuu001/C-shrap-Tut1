CREATE TABLE [dbo].[Joke] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [JokeAnswer]   INT NOT NULL,
    [JokeQuestion] INT NOT NULL,
    CONSTRAINT [PK_Joke] PRIMARY KEY CLUSTERED ([Id] ASC)
);

 