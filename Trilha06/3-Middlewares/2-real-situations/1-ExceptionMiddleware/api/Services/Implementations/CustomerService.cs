using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Interfaces;

namespace api.Implementations
{
    public class CustomerService : ICustomerService
    {
        public async Task<Customer> Add(Customer Customer)
        {
            var context = new contextEntities();
            
            if(Customer == null)
            {
                return null;
            }

            context.Add(Customer);

            await context.SaveChangesAsync();

            return Customer;


        }

        public async Task<Customer> Find(int id)
        {
            var context = new contextEntities();
            
            var coffe = await context.Customer.FindAsync(id);

            return coffe;
        }

        public Task<List<Customer>> GetAll()
        {
            var context = new contextEntities();
            
            var Customers = context.Customer.ToList();

            return Task.FromResult(Customers);
        }

        public Task<Customer> Update(Customer Customer)
        {
            var context = new contextEntities();

            if(Customer == null)
            {
                return null;
            }

            var response = context.Customer.Any(x => x.CusId == Customer.CusId);
            if(!response)
            {
                return null;
            }

            context.Customer.Update(Customer);
                
            context.SaveChangesAsync();

            return Task.FromResult(Customer);
        }

        public Task<bool> Delete(int id)
        {
            var context = new contextEntities();

            var Customer = context.Customer.Find(id);
            if(Customer == null)
            {
                return Task.FromResult(false);
            }
            
            context.Remove(Customer);

            context.SaveChangesAsync();

            return Task.FromResult(true);
        }

        public Task<bool> UpdateCpf(int id, string cpf)
        {
            var context = new contextEntities();

            if(cpf == null)
            {
                return Task.FromResult(false);;
            }

            var customer = context.Customer.Find(id);
            if(customer == null)
            {
                return Task.FromResult(false);;
            }

            customer.CarCpf = cpf;
                
            context.SaveChangesAsync();

            return Task.FromResult(true);;
        }
    }
}