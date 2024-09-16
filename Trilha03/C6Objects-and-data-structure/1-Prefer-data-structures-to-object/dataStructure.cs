using System;

public namespace C4COMMENTS.example
{
    public class Point 
    {  
        public int x;  
        public int y; 

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public interface Shape 
    {  
        double Area();
    }

    public class Square : Shape
    {  
        public Point topLeft { get; set; }  
        public double side { get; set; } 

        public double Area()
        {
            return side * side;
        }
    }
    public class Rectangle : Shape
    {  
        public Point topLeft { get; set; }  
        public double height { get; set; }  
        public double width { get; set; } 

        public double Area()
        {
            return height * width;
        }
    }

    public class Circle : Shape
    {  
        public double PI = 3.141592653589793;
        public Point center { get; set; }  
        public double radius { get; set; } 

        public double Area()
        {
            return PI * radius * radius;
        }
    }

    public class Programa
    {
        public void main()
        {
            Square s = (Square)shape; 
            s.topLeft = 5;
            s.side = 5;
        }
    }
}