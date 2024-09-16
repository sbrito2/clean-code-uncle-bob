using Microsoft.Extensions.DependencyInjection;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Infraestructure.Data;
using API.Application.Services;
using API.Domain.UnitOfWork;
using API.Infraestructure.Data.Context;
using API.Domain.Notification;
using SimpleInjector;

namespace PDG.CrossCutting
{
    public static class SimpleInjectorConfiguration
    {
        public static void RegisterServices(Container container)
        {
            AddRepositories(container);
            AddServices(container);
            AddContextAdministrators(container);
        }

        private static void AddServices(Container container)
        {
            container.Register<JwtTokenGeneratorService>(Lifestyle.Transient);
            container.Register<IUserService, UserService>(Lifestyle.Transient);
            container.Register<IPropertyService, PropertyService>(Lifestyle.Transient);
            container.Register<IPropertyTypeService, PropertyTypeService>(Lifestyle.Transient);
            container.Register<ICustomerService, CustomerService>(Lifestyle.Transient);
            container.Register<IImageService, ImageService>(Lifestyle.Transient);
            container.Register<IResourceService, ResourceService>(Lifestyle.Transient);
            container.Register<IResourceTypeService, ResourceTypeService>(Lifestyle.Transient);
            container.Register<IActionTypeService, ActionTypeService>(Lifestyle.Transient);
            container.Register<IProfileService, ProfileService>(Lifestyle.Transient);
            container.Register<IEmailService, EmailService>(Lifestyle.Transient);
            container.Register<ICityService, CityService>(Lifestyle.Transient);
            container.Register<IStateService, StateService>(Lifestyle.Transient);
        }

        private static void AddRepositories(Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);
            container.Register<IPropertyRepository, PropertyRepository>(Lifestyle.Transient);
            container.Register<IPropertyTypeRepository, PropertyTypeRepository>(Lifestyle.Transient);
            container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Transient);
            container.Register<IResourceRepository, ResourceRepository>(Lifestyle.Transient);
            container.Register<IResourceTypeRepository, ResourceTypeRepository>(Lifestyle.Transient);
            container.Register<IActionTypeRepository, ActionTypeRepository>(Lifestyle.Transient);
            container.Register<ICityRepository, CityRepository>(Lifestyle.Transient);
            container.Register<IStateRepository, StateRepository>(Lifestyle.Transient);
            container.Register<IProfileRepository, ProfileRepository>(Lifestyle.Transient);
        }

        private static void AddContextAdministrators(Container container)
        {
            container.Register<NotificationContext>(Lifestyle.Transient);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Transient);
        }
    }
}
