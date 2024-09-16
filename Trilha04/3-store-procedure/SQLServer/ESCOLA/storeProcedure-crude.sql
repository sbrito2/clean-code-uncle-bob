CREATE PROCEDURE sp_add_nota_participacao (@RA int, @Pontuacao decimal(2,2))
AS
begin 
	update RESUlTADO 
	set RES_NOTA = RES_NOTA * @Pontuacao
	where ALU_RA = @RA
end

EXEC sp_add_nota_participacao(3, 2.3)