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

-- �ndices para mejorar el rendimiento de b�squeda y filtros comunes

-- �ndice para b�squedas por estado
CREATE INDEX IX_Todo_Status ON Todos (Status);

-- �ndice para b�squedas por completado
CREATE INDEX IX_Todo_IsCompleted ON Todos (IsCompleted);

-- �ndice para b�squedas por fecha de creaci�n (�til para ordenamientos)
CREATE INDEX IX_Todo_CreateDate ON Todos (CreateDate);

-- �ndice para consultar por usuario
CREATE INDEX IX_Todo_IdUserCreate ON Todos (IdUserCreate);