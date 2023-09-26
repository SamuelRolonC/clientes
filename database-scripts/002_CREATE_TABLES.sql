USE [Customer]
GO

CREATE TABLE [Customer] (
  [id] INTEGER IDENTITY(1,1) PRIMARY KEY,
  [name] NVARCHAR(255),
  [surname] NVARCHAR(255),
  [birthdate] DATE,
  [cuit] NVARCHAR(20) NOT NULL UNIQUE,
  [address] NVARCHAR(255),
  [phone] NVARCHAR(255),
  [email] NVARCHAR(255) NOT NULL UNIQUE,
  [active] BIT NOT NULL DEFAULT 0,
  [createdBy] NVARCHAR(100) NOT NULL,
  [createdAt] DATETIME2 NOT NULL,
  [updatedBy] NVARCHAR(100),
  [updatedAt] DATETIME2
)
GO

 