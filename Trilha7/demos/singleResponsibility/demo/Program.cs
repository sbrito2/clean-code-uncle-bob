using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardMessage.WelcomeMessage();

            Person ronaldinho = PersonService.CreatePerson();

            bool isPersonValid = PersonValidator.Validate(ronaldinho);

            string value = RU.PayValue();
            bool isValueValid = RUService.ValidatePayment(value);

            if(!isPersonValid || !isValueValid)
            {
                StandardMessage.EndConsole();
                return;
            }

            Console.Write(RU.GetPassword(ronaldinho));
            StandardMessage.EndConsole();
        }
    }
}
