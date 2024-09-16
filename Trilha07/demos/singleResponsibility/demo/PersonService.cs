using System;

namespace demo
{
    public class PersonService
    {
        public static Person CreatePerson()
        {
            Person person = new Person();

            //pede as informações do estudante
            Console.Write("Qual o seu RA: ");
            person.Name = Console.ReadLine();

            Console.Write("Qual o seu curso:");
            person.Course = Console.ReadLine();

            return person;
        }
    }
}