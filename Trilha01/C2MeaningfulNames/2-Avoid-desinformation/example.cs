using System;
using System.Collections.Generic;

public class WrongExample
{
    //If you want to name a group of accounts use accounts try to avoid accountList 
    //(maybe its type is not a List)
    public List<string> AccountList { get; set; }

    //would be poor variable names because they are the names of Unix platforms or variant
    public int hp { get; set; }
}

public class RightExample
{
    public List<string> Accounts { get; set; }
    public int Hypotenuse  { get; set; }
}
