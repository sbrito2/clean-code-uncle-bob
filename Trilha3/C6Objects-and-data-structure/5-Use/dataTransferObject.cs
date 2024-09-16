public class AddressDTO 
{  
    public String street { get; }  
    public String streetExtra { get; }   
    public String city { get; }    
    public String state { get; }    
    public String zip { get; } 
     
    public Address(String street, String streetExtra, String city, String state, String zip) 
    {    
        this.street = street;    
        this.streetExtra = streetExtra;    
        this.city = city;    
        this.state = state;    
        this.zip = zip;  
    }
}
 