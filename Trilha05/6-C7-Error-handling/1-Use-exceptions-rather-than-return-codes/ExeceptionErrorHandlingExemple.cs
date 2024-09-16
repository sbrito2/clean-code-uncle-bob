public class ExceptionHandlingExample
{
    public void main()
    {
        Password password = new Password("Local12%");
        var result = this.CheckPasswordIsValid(password);

        Console.Write("It is a strong Password");
    }

    private void CheckPasswordIsValid(Password password) 
    {
        //the algorithm for the action from the function and error handling, are now separated.

        if(!password.HasNumericCharacter()) 
        {
            throw new System.Exception("Please, add at least 1 numeric character.");
        }

        if(!password.HasSpecialCharacter()) 
        {
            throw new System.Exception("Please, add at least 1 special character.");
        }

        if(!password.HasAnyUpperCaseLetter()) 
        {
            throw new System.Exception("Please, add at least 1 upper case letter.");
        }
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
