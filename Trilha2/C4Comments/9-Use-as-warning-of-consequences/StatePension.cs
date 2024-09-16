public namespace C4COMMENTS.example
{
    public class Programa
    {
        // Don't run unless you 
        // have some time to kill. 
        public void _testWithReallyBigFile() { 

            writeLinesToFile(10000000);
            response.setBody(testFile); 
            response.readyToSend(this); 
            String responseString = output.toString(); 
            assertSubString("Content-Length: 1000000000", responseString); 
            assertTrue(bytesSent > 1000000000);
        } 
    }
}