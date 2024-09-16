using System;

public namespace C4COMMENTS.example
{
    public class Program
    {
        public void main()
        {
            if(isPrime(5))
                return Console.Writeln("É primo");
            
            return Console.Writeln("Nao é primo");
        }

        public int isPrime(int num)
        {
            int result = 0;

            for (i = 2; i <= num / 2; i++) {
                
                if (num % i == 0) {
                    result++;
                    break;
                } //if
            } //for

            if (resultado == 0)
            {
                return true;
            }//if
            
            return false;
        }
    }
}