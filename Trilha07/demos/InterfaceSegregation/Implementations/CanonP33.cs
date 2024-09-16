using System;
using demo.interfaces;

namespace demo.Implementations
{
    public class CanonP33 : IPrintDuplex
    {
        public bool PrintDuplexContext(string context)
        {
            Console.WriteLine("Print Duplex done");
            return true;
        }
    }
}