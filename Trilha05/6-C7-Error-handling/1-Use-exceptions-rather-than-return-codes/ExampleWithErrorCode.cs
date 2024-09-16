public class ExceptionHandlingExample
{
    public void main()
    {
        Password password = new Password("Local12%");
        var result = this.CheckPasswordIsValid(password);

        if(result == -1)
            Console.Write("U have to add at least 1 numeric character.");
        
        if(result == -2)
            Console.Write("U have to add at least 1 special character.");
        
        if(result == -3)
            Console.Write("U have to add at least 1 Upper case letter.");
        
        console.Write("It is a stronger password.");
    }

    private int CheckPasswordIsValid(Password password) 
    {

        if(!password.HasNumericCharacter()) 
        {
            return -1;
        }

        if(!password.HasSpecialCharacter()) 
        {
            return -2;
        }

        if(!password.HasAnyUpperCaseLetter()) 
        {
            return -3;
        }
        
        // If all is OK, return "the successful code" 1
        return 1;
    }

    public class Password
    {
        public string Password { get; }

        public Password(string password)
        {
            this.Password = password;
        }

        public bool HasNumericCharacter() { return true; }
        public bool HasSpecialCharacter() { return true; }
        public bool HasAnyUpperCaseLetter() { return true; }
    }
}
