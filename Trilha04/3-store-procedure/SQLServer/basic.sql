----PROCEDURE
CREATE PROCEDURE teste
AS
SELECT 'Olá Mundo' As Nome

EXEC teste

--para vizualisar o resultado de um procedure (esse é outro procedure)
EXEC sp_helptext teste


--criptografado
CREATE PROCEDURE teste2
WITH encryption
AS
SELECT 'Olá Mundo' As Nome

EXEC teste2

--para vizualisar o resultado de um procedure (esse é outro procedure)
EXEC sp_helptext teste2
