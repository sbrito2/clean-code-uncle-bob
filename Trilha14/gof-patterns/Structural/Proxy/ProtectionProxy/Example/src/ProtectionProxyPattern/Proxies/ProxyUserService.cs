using System;
using ProtectionProxyPattern.interfaces;
using ProtectionProxyPattern.Services;

namespace ProtectionProxyPattern
{
    public class ProxyUserService : IUserService
    {
        //ISubject
        UserService userService;
        String senha = "53NH4";


        //Request
        public String Research()
        {
            String retorno = "autentique-se";

            if (this.userService != null)
                retorno = userService.Research();

            return retorno;
        }


        public String Uthenticate(String s)
        {
            String retorno = "sem acesso";

            if (s == this.senha)
            {
                this.userService = new UserService();
                retorno = "usuário autenticado";
            }

            return retorno;
        }
    }
}