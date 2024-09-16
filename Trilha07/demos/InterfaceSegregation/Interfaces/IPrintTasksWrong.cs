namespace demo.interfaces
{
    public interface IPrintTasks
    {
        bool PrintContext(string context);
        bool ScanContext (string context);
        bool FaxContext(string context);
        bool PhotoCopyContext(string context);
        bool PrintDuplexContext(string context);
    }    
}