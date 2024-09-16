using System;
using System.Collections.Generic;

public class Programa
{
    public void main()
    {
        ReportCard card = new ReportCard();
        card.RA = "AB2020";
        card.Grades = new List<double> { 9.0, 5.5, 8.4, 7.7}; 

        Console.WriteLine("Average: {0}.", card.GetAverage());           
    }
}

public class ReportCard
{
    public string RA { get; set; }
    public List<double> Grades { get; set; }

    public double GetAverage()
    {
            return Grades.Average();
    }
}

public class ReportCardWrongWay
{
    public string RA { get; set; }
    //Number-series naming (a1, a2, .. aN) is the opposite of intentional naming. they are noninformative. 
    public double G1 { get; set; }
    public double G2 { get; set; }

    public double GetAverage()
    {
            return (this.G1 + this.G2) / 2;
    }
}
