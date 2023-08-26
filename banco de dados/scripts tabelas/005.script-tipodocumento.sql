IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipodocumento]') AND type in (N'U'))
BEGIN
    CREATE TABLE tipodocumento (
        id BIGINT PRIMARY KEY IDENTITY(1,1),
        descricao VARCHAR(50)
    );
END

INSERT INTO tipodocumento (descricao)
SELECT 'RG'
WHERE NOT EXISTS (SELECT 1 FROM tipodocumento WHERE descricao = 'RG');

INSERT INTO tipodocumento (descricao)
SELECT 'CPF'
WHERE NOT EXISTS (SELECT 1 FROM tipodocumento WHERE descricao = 'CPF');