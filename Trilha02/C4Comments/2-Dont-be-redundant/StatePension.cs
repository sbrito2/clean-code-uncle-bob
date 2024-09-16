using System;

public namespace C4COMMENTS.example
{
    public class Employee
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string contributionYearsTotal  { get; set; }
        public bool validatedInformation { get; set; }

        public bool IsEligibleForStatePension()
        {
            if(this.Age > 65 && this.contributionYearsTotal > 25 && this.validatedInformation)
                return true;
            
            return false;
        }
    }
    public class Programa
    {
        public void main()
        {
            // Utility method that returns true when employee is eligible to ask
            // state pension, otherwise return false 
            if(Employee.IsEligibleForStatePension)
                return true;
            
        }
    }
}