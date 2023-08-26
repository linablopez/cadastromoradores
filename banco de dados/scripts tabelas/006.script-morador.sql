IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[morador]') AND type in (N'U'))
BEGIN
    CREATE TABLE morador (
        id BIGINT PRIMARY KEY IDENTITY(1,1),
        numerodocumento VARCHAR(20) UNIQUE,
		tipodocumento_id BIGINT,
        nome VARCHAR(200),
        datanascimento DATE,
        idade INT,
        sexo_id INT,
		telefone VARCHAR(20),
        email VARCHAR(100),
        FOREIGN KEY (sexo_id) REFERENCES sexo(id),
        FOREIGN KEY (tipodocumento_id) REFERENCES tipodocumento(id)
    );
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'morador_apartamento') AND type in ('U'))
BEGIN
    CREATE TABLE morador_apartamento (
        id BIGINT PRIMARY KEY IDENTITY(1,1),
        morador_id BIGINT,
        apartamento_id BIGINT,
        FOREIGN KEY (morador_id) REFERENCES morador(id),
        FOREIGN KEY (apartamento_id) REFERENCES apartamento(id)
    );
END

--Inserts Moradores

INSERT INTO morador (numerodocumento, tipodocumento_id, nome, datanascimento, idade, sexo_id, telefone, email)
SELECT '3689654', 
       (SELECT id FROM tipodocumento WHERE descricao = 'RG'),
       'Lina', '1990-05-15', 31,
       (SELECT id FROM sexo WHERE descricao = 'Feminino'),
       '(11) 3034-5678', 'lina@email.com'
WHERE NOT EXISTS (SELECT 1 FROM morador WHERE numerodocumento = '3689654');

--Insere o morador ao apartamento
INSERT INTO morador_apartamento (morador_id, apartamento_id)
SELECT (SELECT id FROM morador WHERE numerodocumento = '3689654'),
       (SELECT id FROM apartamento WHERE numero_apto = 301)
WHERE NOT EXISTS 
(SELECT 1 FROM morador_apartamento WHERE morador_id = (SELECT id FROM morador WHERE numerodocumento = '3689654')
AND apartamento_id = (SELECT id FROM apartamento WHERE numero_apto = 301));