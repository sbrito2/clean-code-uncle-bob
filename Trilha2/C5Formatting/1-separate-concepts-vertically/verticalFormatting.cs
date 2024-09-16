using System;

public namespace C4Formatting.example
{
    public class Example1
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public double Somar()  
        {  
            var result = (this.FirstNumber + this.SecondNumber);  
            return result;
        }  
        
        public double Subtrair()  
        {  
            var result = (this.FirstNumber - this.SecondNumber);  
            return result; 
        }  

        public double Multiplicar()  
        {  
            var result = (this.FirstNumber * this.SecondNumber);  
            return result;  
        }  
            
        public double Dividir () 
        {  
            if (this.SecondNumber == 0)  
            {  
                return 0;
            }  
            else  
            {  
                var result = (this.FirstNumber / this.SecondNumber);  
                return result;  
            }  
        } 
    }

    public class Programa
    {
        public void main()
        {
            Calculator calculator = new Calculator();
            calculator.FirstNumber = 2.0;
            calculator.SecondNumber = 1.0;

            Console.WriteLine(calculator.Somar());
        }
    }
}