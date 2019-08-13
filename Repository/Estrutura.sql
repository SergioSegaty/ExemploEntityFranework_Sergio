DROP TABLE IF EXISTS computadores_pecas, computadores, contatos, pecas, clientes, categorias;

CREATE TABLE categorias(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	registro_ativo BIT
	);

CREATE TABLE pecas (
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	preco DECIMAL(8,2),
	registro_ativo BIT
	);

CREATE TABLE clientes (
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	cpf VARCHAR(14),
	registro_ativo BIT
	);

CREATE TABLE contatos (
	id INT PRIMARY KEY IDENTITY(1,1),

	id_cliente INT,
	FOREIGN KEY(id_cliente) REFERENCES clientes(id),

	tipo VARCHAR(20),
	valor VARCHAR(50),
	registro_ativo BIT
	);

CREATE TABLE computadores(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_categoria INT,
	FOREIGN KEY(id_categoria) REFERENCES categorias(id),

	nome VARCHAR(100),
	preco DECIMAL(8,2),
	registro_ativo BIT
	);

CREATE TABLE computadores_pecas (
	id INT PRIMARY KEY IDENTITY(1,1),

	id_computador INT,
	FOREIGN KEY(id_computador) REFERENCES computadores(id),

	id_peca INT,
	FOREIGN KEY(id_peca) REFERENCES pecas(id),
	registro_ativo BIT
	);

INSERT INTO categorias (nome, registro_ativo) VALUES
('Noob', 1),
('Semi-Pro', 1),
('Pro', 1);
