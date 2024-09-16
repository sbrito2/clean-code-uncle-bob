namespace demo.interfaces
{
    interface IPrintScanContent
    {
        bool PrintContext(string context);
        bool ScanContext(string context);
        bool PhotoCopyContext(string context);   
    }

    interface IFaxContext
    {
        bool FaxContext(string context);
    }

    interface IPrintDuplex
    {
        bool PrintDuplexContext(string context);
    }
}