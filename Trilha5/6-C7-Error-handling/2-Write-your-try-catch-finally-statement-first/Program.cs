public class Program
{
    public void main()
    {
      Cursor cursor = new Cursor(2,3);

    }

    public static DoLengthyProcessing(this Control control, Action<Control> action)
    {
        Cursor oldCursor = control.Cursor;

        try
        {
            control.Cursor = Cursors.WaitCursor;
            action(control);
        }
        catch (Exception ex)
        {
            ErrorHandler.Current.Handler(ex);
        }
        finally
        {
            control.Cursor = oldCursor;
        }
    }

    public class Cursor
    {
        public int x { get; set; }
        public int y { get; set; }

        public Cursor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
