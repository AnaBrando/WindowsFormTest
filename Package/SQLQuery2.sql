CREATE TABLE [dbo].[users] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [nome] VARCHAR (50) NOT NULL,
    [pwd]  VARCHAR (15) NOT NULL,
    [user] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_users_ToClient] FOREIGN KEY ([user]) REFERENCES [dbo].[cliente] ([Id])
);
select * from cliente;
select * from users; 

insert into users(nome,pwd,cliente)
values("nome","pwd",1);

select * from users;