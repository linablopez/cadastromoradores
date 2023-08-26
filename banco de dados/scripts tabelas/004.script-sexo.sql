IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('sexo') AND type in ('U'))
BEGIN
    CREATE TABLE sexo (
        id INT PRIMARY KEY IDENTITY(1,1),
        descricao VARCHAR(20)
    );
END

INSERT INTO sexo (descricao)
SELECT 'Masculino'
WHERE NOT EXISTS (SELECT 1 FROM sexo WHERE descricao = 'Masculino');

INSERT INTO sexo (descricao)
SELECT 'Feminino'
WHERE NOT EXISTS (SELECT 1 FROM sexo WHERE descricao = 'Feminino');

INSERT INTO sexo (descricao)
SELECT 'Outro'
WHERE NOT EXISTS (SELECT 1 FROM sexo WHERE descricao = 'Outro');