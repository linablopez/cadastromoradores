IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[predio]') AND type in (N'U'))
BEGIN
    CREATE TABLE predio (
        id BIGINT PRIMARY KEY IDENTITY(1,1),
        nome_predio VARCHAR(200),
        rua VARCHAR(200),
        numero INT,
        bairro VARCHAR(100),
        cidade VARCHAR(100),
        estado VARCHAR(50),
        pais VARCHAR(50),
        cep VARCHAR(20),
        data_construcao DATETIME,
        num_andares INT
    );
END

INSERT INTO predio (nome_predio, rua, numero, bairro, cidade, estado, pais, cep, data_construcao, num_andares)
SELECT 'Edifício Parati', 'Rua Eclísio Viviani', 111, 'Centro', 'Osasco', 'São Paulo', 'Brasil', '06018-140', '2020-08-25 10:00:00', 10
WHERE NOT EXISTS (SELECT 1 FROM predio WHERE nome_predio = 'Edifício Parati');