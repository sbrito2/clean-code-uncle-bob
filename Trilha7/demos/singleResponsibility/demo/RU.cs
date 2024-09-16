using System;

namespace demo
{
    public class RU
    {
        public static string PayValue()
        {
            //Valor RU
            Console.Write("Entre com 5,00:");
            string input = Console.ReadLine();
        
            return input;
        }

        public static string GetPassword(Person person)
        {
            //cria a senha para o estudante
            return $"Sua senha: {DateTime.Now}{person.RA}";
        }
        
    }
}