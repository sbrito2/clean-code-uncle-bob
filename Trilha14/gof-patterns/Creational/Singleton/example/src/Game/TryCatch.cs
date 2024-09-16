using System;

namespace Game 
{
    public static class TryCatch 
    {
        public static void Do(Action act) 
        {
            try 
            {
                act();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.GetType()} : {ex.Message}");
            }
        }
    }
}