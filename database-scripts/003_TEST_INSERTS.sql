USE [Customer]
GO

INSERT INTO [dbo].[Customer]
           ([name]
           ,[surname]
           ,[birthdate]
           ,[cuit]
           ,[address]
           ,[phone]
           ,[email]
           ,[active]
           ,[createdBy]
           ,[createdAt])
     VALUES
           ('Pedro'
           ,'De la Torre'
           ,DATEFROMPARTS(1998, 10, 20)
           ,'33401231233'
           ,'Calle falsa 123'
           ,'1112341234'
           ,'pedrodelatorre@mail.com'
           ,1
           ,'SCRIPT'
           ,GETDATE())
GO


