

CREATE TRIgger TR_ADD_PRESENÇA ON PROVA_ALUNO
AFTER INSERT, UPDATE
AS 
BEGIN
	DECLARE @RA INT,	@ProvaId INT;
	SELECT @RA = ALU_RA, @ProvaId = PRO_ID FROM inserted

	UPDATE PRESENÇA 
	SET 
		ALU_RA = @RA,
		PRO_ID = @ProvaId,
		PRE_TOTAL_RESPONDIDA =  PRE_TOTAL_RESPONDIDA + 1
	WHERE ALU_RA = @RA and PRO_ID = @ProvaId;

	PRINT 'AFTER INSERT,UPDATE trigger done!'
END
GO


SELECT * FROM delete_question
GO

SELECT * FROM sys.triggers
GO

ALTER TRIgger TR_ADD_PRESENÇA ON PROVA_ALUNO
AFTER INSERT, UPDATE
AS 
BEgin
	DECLARE @RA INT,	@ProvaId INT, @TotalRespondida INT;
	SELECT @RA = ALU_RA, @ProvaId = PRO_ID FROM inserted

	SET @TotalRespondida = (SELECT PRE_TOTAL_RESPONDIDA FROM PRESENÇA WHERE ALU_RA = @RA and PRO_ID = @ProvaId)

	IF(@TotalRespondida > 0)
		UPDATE PRESENÇA 
		SET 
			ALU_RA = @RA,
			PRO_ID = @ProvaId,
			PRE_TOTAL_RESPONDIDA =  PRE_TOTAL_RESPONDIDA + 1
		WHERE ALU_RA = @RA and PRO_ID = @ProvaId
	ELSE
		INSERT INTO PRESENÇA VALUES (@RA, @ProvaId, 1)

	PRINT 'AFTER INSERT,UPDATE trigger done!'
END
GO


INSERT INTO PROVA_ALUNO values (1, 23, 1, 1, 'bem...', 50 )

------- after trigger Example (depois do sql)
CREATE TRIGGER TR_ADD_PRESENÇA ON PROVA_ALUNO
AFTER INSERT, UPDATE
AS 
BEgin
	DECLARE @RA INT,	@ProvaId INT;
	SELECT @RA = ALU_RA, @ProvaId = PRO_ID FROM inserted

	UPDATE PRESENÇA 
	SET 
		ALU_RA = @RA,
		PRO_ID = @ProvaId,
		PRE_TOTAL_RESPONDIDA =  PRE_TOTAL_RESPONDIDA + 1
	WHERE ALU_RA = @RA and PRO_ID = @ProvaId;

	PRINT 'AFTER INSERT,UPDATE trigger done!'
END
GO

DROP TRIGGER IF EXISTS delete_question;

ENABLE TRIGGER IF EXISTS delete_question;

DISABLE TRIGGER IF EXISTS delete_question;
