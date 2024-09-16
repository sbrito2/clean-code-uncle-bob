
using System;
using System.Collections.Generic;
using API.Domain.Entities;
using API.Domain.Notification;
using API.Domain.Queries;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.UnitOfWork;
using API.CrossCutting.Utils.Security.Exceptions;
using Microsoft.Extensions.Configuration;

namespace API.Application.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IPropertyService propertyService;
        private readonly IEmailService emailService;
        private readonly int itensPerPageDefault;

        public CustomerService(ICustomerRepository customerRepository, IConfiguration config, IPropertyService propertyService, IUnitOfWork unitOfWork, IEmailService emailService, NotificationContext notificationContext)
        : base(customerRepository, unitOfWork, notificationContext)
        {
            this.customerRepository = customerRepository;
            this.propertyService = propertyService;
            this.emailService = emailService;
            this.itensPerPageDefault = config.GetValue<int>("ItensPerPageDefault");
        }

        public PaginatedQueryResult<Customer> Index(int page, string filter)
        {
            var query = new GenericPaginatedQuery<string>(page, itensPerPageDefault, filter);
            var users = customerRepository.GetAll(query);

            return users;
        }

        public override void Add(Customer customer)
        {
            var property = propertyService.Find(customer.PropertyId);

            if(property == null)
            {
                notificationContext.AddNotFoundNotification("Imóvel de interesse não encontrado.");
                return;
            }

            customer.Active = true;
            customer.CreatedAt = DateTime.Now;
            unitOfWork.Add(customer);

            unitOfWork.SaveChanges();

            string title = "Email de registro de interesse - Mestre dos leilões";
            string messagem = $" Nome: {customer.Name} \n Email: {customer.Email} \n Mensagem: {customer.Message} \n Imóvel: {property.Title}";
            
            emailService.Send(title, messagem);

            return;
        }

        public List<Customer> GetAll()
        {
            return customerRepository.GetAllAndTheirChosenProperty();
        }

        public override void Update(Customer customer)
        {
            if(!propertyService.Any(customer.PropertyId))
            {
                notificationContext.AddNotFoundNotification("Imóvel de interesse não encontrado.");
                return;
            }
            
            unitOfWork.Update(customer);

            unitOfWork.SaveChanges();
        }
    }
}
