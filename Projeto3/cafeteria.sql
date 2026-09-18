ALTER DATABASE cafeteria
SET SINGLE_USER 
WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE cafeteria
GO

CREATE DATABASE cafeteria
GO

USE cafeteria
GO

CREATE TABLE usuario(
	usuarioid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	email VARCHAR(255) UNIQUE NOT NULL,
	senha VARCHAR(255) NOT NULL
)
GO

CREATE TABLE item(
	id INT PRIMARY KEY IDENTITY(1,1),
	nomeItem VARCHAR(255),
	preco DECIMAL(10,2),
	descricao VARCHAR(255)
)
GO


INSERT INTO usuario(email, senha)
VALUES
('caique@gmail.com', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2))
GO

INSERT INTO item(nomeItem, preco, descricao)
VALUES
('Cafe', 10.00, 'Cafe arabe fermentado nas montanhas do Himalaia'),
('Pao de queijo', 10.00, 'Pao de queijo com queijo especial'),
('Cha verde', 5.00, 'Cha verde da China')
GO

SELECT * FROM usuario
SELECT * FROM item