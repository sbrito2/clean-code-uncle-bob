
public class ExempleWithChainMethod
{
    public void main()
    {
        //chain method
        customer.getMailingAddress().getLine1();
        employee.getHomeAddress().getLine2();
    }
    class Address 
    {
        String getLine1();
        String getLine2();
    }

    class Customer 
    {
        Address getMailingAddress();
        Address getShippingAddress();
    }

    class Employee 
    {
        Address getHomeAddress();
    }
}


public class AfterDemeterizing
{
    public void main()
    {
        customer.getMailingAddressLine1();
        employee.getHomeAddressLine1();
    }

    class Address 
    {
        String getLine1();
        String getLine2();
    }

    //The advantage of this, I guess, is that clients don't need to know that customer has a mailing address.
    class Customer 
    {
        Address getMailingAddress();
        Address getShippingAddress();

        String getMailingAddressLine1();
        String getMailingAddressLine2();

        String getShippingAddressLine1();
        String getShippingAddressLine2();
    }

    class Employee 
    {
        Address getHomeAddress();
        String getHomeAddressLine1();
        String getHomeAddressLine2();
    }
}

