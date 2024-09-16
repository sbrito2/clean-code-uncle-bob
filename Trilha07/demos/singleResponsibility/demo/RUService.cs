using System;

namespace demo
{
    public class RUService
    {
        public static bool ValidatePayment(string value)
        {
            decimal result;
             //verifica se deu as informações
            try
            {
                decimal.TryParse(value, out result);
            }
            catch
            {
                Console.WriteLine("Valor em branco");
                return false;
            }

            if(result != 5)
            {
                return false;
            }

            return true;
        }
    }
}