IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('usuario') AND type in ('U'))
BEGIN
    CREATE TABLE usuario (
        id BIGINT PRIMARY KEY IDENTITY(1,1),
        usuario VARCHAR(100),
        senha VARCHAR(MAX),
        nome_usuario VARCHAR(200),
        datacriacao DATETIME
    );
END

INSERT INTO usuario (usuario, senha, nome_usuario, datacriacao)
SELECT 'lina', '123', 'Lina Lopez', GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM usuario WHERE usuario = 'lina');