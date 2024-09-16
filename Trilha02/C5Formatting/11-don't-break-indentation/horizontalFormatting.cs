using System;

public namespace C4Formatting.example
{
    public class Example1
    {
        private FitNesseContext context; public FitNesseServer(FitNesseContext context) { this.context = context; } public void serve(Socket s) { serve(s, 10000); } public void serve(Socket s, long requestTimeout) { try { FitNesseExpediter sender = new FitNesseExpediter(s, context); sender.setRequestParsingTimeLimit(requestTimeout); sender.start(); } catch(Exception e) { e.printStackTrace(); } } 

    }

    public class Example2
    {
        private FitNesseContext context;
        public FitNesseServer(FitNesseContext context) {    this.context = context;  }
        public void serve(Socket s) {    serve(s, 10000);  }
        public void serve(Socket s, long requestTimeout) 
        {    
            try {      
                FitNesseExpediter sender = new FitNesseExpediter(s, context);      
                sender.setRequestParsingTimeLimit(requestTimeout);      
                sender.start();    
            }    
            catch (Exception e) 
            {      
                e.printStackTrace();    
            }  
        }
    }
}