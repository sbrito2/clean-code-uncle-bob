using System.Collections.Generic;
using System.Net;

namespace api.Messages
{
    public class ResponseMessages
    {
        public static IDictionary<HttpStatusCode, string> Messages = new Dictionary<HttpStatusCode, string>()
        {
            { HttpStatusCode.OK, "Sucesso" },
            { HttpStatusCode.Created, "Criado com sucesso" },
            { HttpStatusCode.NotFound, "Identificador invalido, não encontrado" },
            { HttpStatusCode.Unauthorized, "Você precisa se identificar para realizar esse request!" },
            { HttpStatusCode.BadRequest, "O request esta invalido" },
            { HttpStatusCode.InternalServerError, "Erro interno de servidor" },
            
        };
    }
}