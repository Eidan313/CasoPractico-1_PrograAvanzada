
USE master;
GO

IF DB_ID(N'CasoPractico1Productos') IS NOT NULL
BEGIN
    ALTER DATABASE CasoPractico1Productos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CasoPractico1Productos;
END
GO

CREATE DATABASE CasoPractico1Productos;
GO

USE CasoPractico1Productos;
GO

CREATE TABLE dbo.Productos (
    Id          INT IDENTITY(1,1)   NOT NULL,
    Codigo      NVARCHAR(12)        NOT NULL,
    Nombre      NVARCHAR(80)        NOT NULL,
    Categoria   NVARCHAR(40)        NOT NULL,
    UnidadMedida INT                NOT NULL,
    Precio      DECIMAL(18,2)       NOT NULL,
    Existencia  DECIMAL(10,3)       NOT NULL,
    Activo      BIT                 NOT NULL,
    CONSTRAINT PK_Productos PRIMARY KEY (Id),
    CONSTRAINT CK_Productos_Existencia CHECK ([Existencia] BETWEEN 0 AND 9999),
    CONSTRAINT CK_Productos_Precio CHECK ([Precio] > 0),
    CONSTRAINT CK_Productos_UnidadMedida CHECK ([UnidadMedida] IN (1, 2, 3))
);
GO

CREATE UNIQUE INDEX IX_Productos_Codigo ON dbo.Productos (Codigo);
GO

CREATE INDEX IX_Productos_Nombre ON dbo.Productos (Nombre);
GO