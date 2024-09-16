using System;

public namespace C4Formatting.example
{
   public class Quadratic 
   {  
        public static double root1(double a, double b, double c) 
        {    
            double determinant = determinant(a, b, c);    
            return (-b + Math.sqrt(determinant)) / (2*a);  
        }
        
        public static double root2(int a, int b, int c) 
        {    
            double determinant = determinant(a, b, c);    
            return (-b - Math.sqrt(determinant)) / (2*a);   
        }

        private static double determinant(double a, double b, double c) 
        {    
            return b*b - 4*a*c;  
        } 
   } 
}