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

-- Índice único para evitar correos duplicados
CREATE UNIQUE INDEX IX_Users_Email ON Users (Email);

-- Índice no único para optimizar búsquedas por apellido
CREATE INDEX IX_Users_LastName ON Users (LastName);

-- Índice para filtrar registros activos/inactivos rápidamente
CREATE INDEX IX_Users_StatusRegister ON Users (StatusRegister);

