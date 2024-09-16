using System;
public class IEmployeeService
{
   public Employee Add(Employee employee);
   public Employee Find(int id);
   public Employee Update(Employee employee);
   public Employee Delete(int id);

}

public class IUserService
{
   //avoid use new words for the same concept that already has a key word or phrase
   public User Create();
   public User Find();
   public User Update();
   public User Delete();
}

public class Employee
{
}

public class User
{
}