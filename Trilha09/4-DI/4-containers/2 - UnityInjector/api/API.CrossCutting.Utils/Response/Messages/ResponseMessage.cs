using System.Collections.Generic;

namespace API.CrossCutting.Utils.Response.Messages
{
    public static class ResponseMessages
    {
        public static IDictionary<ResponseStatus, string> Messages = new Dictionary<ResponseStatus, string>()
        {
            { ResponseStatus.Error, "Erro interno de servidor" },
            { ResponseStatus.Success, "Sucesso" },
            { ResponseStatus.NoModified, "Não foi possivel modificar" },
            { ResponseStatus.NotFound, "Não encontrado" },
            { ResponseStatus.BadRequest, "Verifique os campos" },
            { ResponseStatus.Unprocessable, "Parâmetros inválidos" },
            { ResponseStatus.Forbidden, "Usuário não tem permissão" },
            { ResponseStatus.Conflict, "Conflito" },
            { ResponseStatus.Unauthorized, "Acesso não autorizado" }
        };
    }

}