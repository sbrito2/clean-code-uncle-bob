class MLINQ
{        
    static void Main()
    {
        // string collection
        IList<string> stringList = new List<string>() { 
            "C# Tutorials",
            "VB.NET Tutorials",
            "Learn C++",
            "MVC Tutorials" ,
            "Java" 
        };

        // LINQ Query Syntax
        var result = stringList.Where(s => s.Contains("Tutorials"));
    }
}