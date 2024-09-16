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
    public class Square 
    {  
        public Point topLeft;  
        public double side; 
    }
    public class Rectangle 
    {  
        public Point topLeft;  
        public double height;  
        public double width; 
    }

    public class Circle 
    {  
        public Point center;  
        public double radius; 
    }

    public class Geometry 
    {  
        public double PI = 3.141592653589793;
        public double area  { get;}

        public Geometry(object shape)
        {
            if(shape.GetType() == Square)
            {
                Square s = (Square)shape; 
                this.area = s.side * s.side;
            }

            if(shape.GetType() == Rectangle)
            {   
                Rectangle r = (RectanglRectanglee)shape; 
                this.area = s.height * s.width;
            }

            if(shape.GetType() == Circle)
            {
                Circle c = (Circle)shape;
                this.area = PI * radius * radius;
            }
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