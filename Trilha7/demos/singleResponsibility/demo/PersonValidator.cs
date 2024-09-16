using System;

namespace demo
{
    public class PersonValidator
    {
        public static bool Validate(Person person)
        {
            if(string.IsNullOrEmpty(person.Name))
            {
                Console.Write("RA em branco, mão foi possível identificalo.");
                StandardMessage.EndConsole();
                return false;
            }

            if(string.IsNullOrEmpty(person.Course))
            {
                Console.Write("Curso em branco, não foi possível confirmar seu cadastro.");
                Console.ReadLine();
                return false;
            }

            return true;
        }
    }
}