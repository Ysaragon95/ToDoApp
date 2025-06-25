CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreateDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdateDate DATETIME NULL,
    OperationRegister NVARCHAR(255) NOT NULL DEFAULT 'Registro del sistema',
    StatusRegister BIT NOT NULL DEFAULT 1
);

-- �ndice �nico para evitar correos duplicados
CREATE UNIQUE INDEX IX_Users_Email ON Users (Email);

-- �ndice no �nico para optimizar b�squedas por apellido
CREATE INDEX IX_Users_LastName ON Users (LastName);

-- �ndice para filtrar registros activos/inactivos r�pidamente
CREATE INDEX IX_Users_StatusRegister ON Users (StatusRegister);

