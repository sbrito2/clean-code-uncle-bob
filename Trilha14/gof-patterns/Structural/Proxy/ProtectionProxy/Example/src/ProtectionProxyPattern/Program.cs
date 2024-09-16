using System;
using ProtectionProxyPattern.Services;

namespace ProtectionProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var userService = new UserService();

            Console.WriteLine("Teste 1: Sem proxy");
            Console.WriteLine(userService.Research());
            Console.WriteLine();

            var proxy =  new ProxyUserService();

            Console.WriteLine("Teste 2: Com proxy, sem autenticar");
            Console.WriteLine(proxy.Research());
            Console.WriteLine();

            Console.WriteLine("Teste 3: Com proxy, autenticando com senha incorreta");
            Console.WriteLine(proxy.Uthenticate("senhaErrada"));
            Console.WriteLine(proxy.Research());
            Console.WriteLine();

            Console.WriteLine("Teste 4: Com proxy, autenticando com senha correta");
            Console.WriteLine(proxy.Uthenticate("53NH4"));
            Console.WriteLine(proxy.Research());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
