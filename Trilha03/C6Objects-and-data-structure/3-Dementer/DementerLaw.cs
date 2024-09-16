
public class Program
{
    public void main()
    {
    }

    class EmployeeService 
    {
        public ImageService imageService;
        public EmployeeService()
        {

        }

        /* o método deve chamar apenas: 1) os métodos da mesma classe*/
        public void function1()
        {
            function2();
        }

        /* 2) or object created by this function */
        public void function2()
        {
            Email email = new Email();
            email.Subject = "function2";
            email.Email = this.Email;
            email.sendEmail();
        }

        
        public bool function3(Employee employee, Image rg)
        {
            
            /* 3) or um object passed as an argument to this function */
            if(!employee.IsCpfValid(employee.Cpf))
                return false;

            /* 4) An held in an instance variable of C */
            ImageService.UploadImage(rg);

            return true;
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public Date Birth { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public List<Address> Addresses { get; }
    }

    class Address
    {
        public string Cnpj { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Steet { get; set; }
        public string Number { get; set; }

        public bool VerifyAddressByCnpj()
        {
            return true;
        }
    }

    class ImageService
    {
        public bool UploadImage()
        {
            return true;
        }

        public bool DownloadImage()
        {
            return true;
        }
    }
}
    

    

   