using System;
using demo.interfaces;

namespace demo.Implementations.Prints
{
    public class HPLazerJet : IPrintTasks
    {
        public bool FaxContext(string context)
        {
            Console.WriteLine("Fax done");
            return true;
        }

        public bool PhotoCopyContext(string context)
        {
            Console.WriteLine("Photo copy done");
            return true;
        }

        public bool PrintContext(string context)
        {
            Console.WriteLine("Print done");
            return true;
        }

        public bool PrintDuplexContext(string context)
        {
            throw new NotImplementedException();
        }

        public bool ScanContext(string context)
        {
            Console.WriteLine("Scan done");
            return true;
        }
    }
}