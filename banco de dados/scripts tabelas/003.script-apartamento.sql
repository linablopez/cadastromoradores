IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('apartamento') AND type in ('U'))
BEGIN
    CREATE TABLE apartamento (
        id BIGINT PRIMARY KEY IDENTITY(1,1),
        numero_apto INT,
        andar INT,
        predio_id BIGINT,
        FOREIGN KEY (predio_id) REFERENCES predio(id)
    );
END

--Andar 1
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 101, 1, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 101);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 102, 1, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 102);

-- Andar 2
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 201, 2, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 201);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 202, 2, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 202);

-- Andar 3
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 301, 3, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 301);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 302, 3, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 302);

-- Andar 4
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 401, 4, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 401);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 402, 4, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 402);

-- Andar 5
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 501, 5, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 501);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 502, 5, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 502);

-- Andar 6
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 601, 6, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 601);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 602, 6, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 602);

-- Andar 7
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 701, 7, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 701);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 702, 7, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 702);

-- Andar 8
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 801, 8, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 801);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 802, 8, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 802);

-- Andar 9
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 901, 9, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 901);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 902, 9, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 902);

-- Andar 10
INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 1001, 10, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 1001);

INSERT INTO apartamento (numero_apto, andar, predio_id)
SELECT 1002, 10, p.id
FROM predio p
WHERE p.nome_predio = 'Edifício Parati' AND NOT EXISTS (SELECT 1 FROM apartamento WHERE numero_apto = 1002);
