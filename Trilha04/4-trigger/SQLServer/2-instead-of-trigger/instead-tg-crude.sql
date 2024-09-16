
------- instead of trigger (no lugar do sql)
CREATE TRIGGER delete_question
ON QUESTAO
instead of DELETE
AS
Begin
	DECLARE @QuestaoId INT;
	SELECT @QuestaoId = QUE_ID FROM deleted

	UPDATE QUESTAO 
	SET QUE_TREINO = 1
	where QUE_ID = @QuestaoId
end

SELECT * FROM delete_question

SELECT * FROM sys.triggers

ALTER TRIGGER delete_question
ON QUESTAO
instead of DELETE
AS
Begin
	DECLARE @QuestaoId INT;
	SELECT @QuestaoId = QUE_ID FROM deleted

	UPDATE QUESTAO 
	SET QUE_TREINO = 1
	where QUE_ID = @QuestaoId
end

--test
select * from QUESTAO
delete QUESTAO
where QUE_ID = 2

DROP TRIGGER IF EXISTS delete_question;

ENABLE TRIGGER IF EXISTS delete_question;

DISABLE TRIGGER IF EXISTS delete_question;


