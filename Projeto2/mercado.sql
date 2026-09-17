CREATE DATABASE mercado
GO

USE mercado
GO

CREATE TABLE [usuario] (
  [usuarioid] uniqueidentifier PRIMARY KEY DEFAULT (newid()),
  [email] varchar(255) UNIQUE NOT NULL,
  [senha] varchar(255) NOT NULL
)
GO

CREATE TABLE [item] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [nomeitem] varchar(255) NOT NULL,
  [quantidade] int NOT NULL DEFAULT (0)
)
GO

INSERT INTO usuario (email, senha)
VALUES
('caique@gmail.com', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2)),
('teste@gmail.com', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2)),
('admin@gmail.com', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2));
GO

INSERT INTO item (nomeitem, quantidade)
VALUES
('Arroz', 5),
('Feijão', 3),
('Macarrão', 10),
('Café', 4),
('Açúcar', 2),
('Leite', 6),
('Pão', 8),
('Bolacha', 12),
('Óleo', 3),
('Sal', 5);
GO


SELECT * FROM usuario
SELECT * FROM item