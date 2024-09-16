using Microsoft.Extensions.DependencyInjection;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Infraestructure.Data;
using API.Application.Services;
using API.Domain.UnitOfWork;
using API.Infraestructure.Data.Context;
using API.Domain.Notification;

namespace PDG.CrossCutting
{
    public static class NativeDotNetInjector
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            AddRepositories(serviceCollection);
            AddServices(serviceCollection);
            AddContextAdministrators(serviceCollection);
        }

        private static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<JwtTokenGeneratorService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IPropertyService, PropertyService>();
            serviceCollection.AddTransient<IPropertyTypeService, PropertyTypeService>();
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<IImageService, ImageService>();
            serviceCollection.AddTransient<IResourceService, ResourceService>();
            serviceCollection.AddTransient<IResourceTypeService, ResourceTypeService>();
            serviceCollection.AddTransient<IActionTypeService, ActionTypeService>();
            serviceCollection.AddTransient<IProfileService, ProfileService>();
            serviceCollection.AddTransient<IEmailService, EmailService>();
            serviceCollection.AddTransient<ICityService, CityService>();
            serviceCollection.AddTransient<IStateService, StateService>();
        }

        private static void AddRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IPropertyRepository, PropertyRepository>();
            serviceCollection.AddTransient<IPropertyTypeRepository, PropertyTypeRepository>();
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<IResourceRepository, ResourceRepository>();
            serviceCollection.AddTransient<IResourceTypeRepository, ResourceTypeRepository>();
            serviceCollection.AddTransient<IActionTypeRepository, ActionTypeRepository>();
            serviceCollection.AddTransient<ICityRepository, CityRepository>();
            serviceCollection.AddTransient<IStateRepository, StateRepository>();
            serviceCollection.AddTransient<IProfileRepository, ProfileRepository>();
        }

        private static void AddContextAdministrators(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<NotificationContext>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
