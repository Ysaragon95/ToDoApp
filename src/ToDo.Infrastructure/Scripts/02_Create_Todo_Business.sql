CREATE TABLE Todos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Status INT NOT NULL,
    IsCompleted BIT NOT NULL DEFAULT 0,
	IdUserCreate INT NOT NULL,
    CreateDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdateDate DATETIME NULL,
    OperationRegister NVARCHAR(255) NOT NULL DEFAULT 'Registro del sistema',
    StatusRegister BIT NOT NULL DEFAULT 1
);

-- Índices para mejorar el rendimiento de búsqueda y filtros comunes

-- Índice para búsquedas por estado
CREATE INDEX IX_Todo_Status ON Todos (Status);

-- Índice para búsquedas por completado
CREATE INDEX IX_Todo_IsCompleted ON Todos (IsCompleted);

-- Índice para búsquedas por fecha de creación (útil para ordenamientos)
CREATE INDEX IX_Todo_CreateDate ON Todos (CreateDate);

-- Índice para consultar por usuario
CREATE INDEX IX_Todo_IdUserCreate ON Todos (IdUserCreate);