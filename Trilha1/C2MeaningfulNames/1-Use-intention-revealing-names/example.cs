using System;

class Program1
{
    static void Main(string[] args)
    {
        String a = (Console.ReadLine());
        Double b = (Convert.ToDouble(Console.ReadLine())), 
            c = (Convert.ToDouble(Console.ReadLine())); 
        Console.WriteLine("TOTAL = R$ " + ((Convert.ToDouble(c) * 0.15) + b).ToString("0.00"));
    }
}

class Program2WithRevealingNames
{
    static void Main(string[] args)
    {

        Double cpf = (Console.ReadLine());
        Double salary = (Convert.ToDouble(Console.ReadLine())); 
        Double overtime = (Convert.ToDouble(Console.ReadLine())); 

        Console.WriteLine("TOTAL = R$ " + GetPayment(salary, overtime).ToString("0.00"));
    }

    public decimal GetPayment(double salary, double overtime)
    {
        return Convert.ToDouble(overtime) * 0.15 + salary;
    }
}