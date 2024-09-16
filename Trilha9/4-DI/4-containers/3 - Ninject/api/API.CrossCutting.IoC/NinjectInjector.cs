
using API.Domain.Repositories;
using API.Domain.Services;
using API.Infraestructure.Data;
using API.Application.Services;
using API.Domain.UnitOfWork;
using API.Infraestructure.Data.Context;
using API.Domain.Notification;
using Ninject.Modules;  
using Ninject;

namespace API.CrossCutting.IoC
{
    public class NinjectBindings : NinjectModule
    {

        public override void Load()
        {
            Bind<JwtTokenGeneratorService>();
            Bind<IUserService>().To<UserService>();
            Bind<IPropertyService>().To<PropertyService>();
            Bind<IPropertyTypeService>().To<PropertyTypeService>();
            Bind<ICustomerService>().To<CustomerService>();
            Bind<IImageService>().To<ImageService>();
            Bind<IResourceService>().To<ResourceService>();
            Bind<IResourceTypeService>().To<ResourceTypeService>();
            Bind<IActionTypeService>().To<ActionTypeService>();
            Bind<IProfileService>().To<ProfileService>();
            Bind<IEmailService>().To<EmailService>();
            Bind<ICityService>().To<CityService>();
            Bind<IStateService>().To<StateService>();

            Bind<IUserRepository>().To<UserRepository>();
            Bind<IPropertyRepository>().To<PropertyRepository>();
            Bind<IPropertyTypeRepository>().To<PropertyTypeRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<IResourceRepository>().To<ResourceRepository>();
            Bind<IResourceTypeRepository>().To<ResourceTypeRepository>();
            Bind<IActionTypeRepository>().To<ActionTypeRepository>();
            Bind<ICityRepository>().To<CityRepository>();
            Bind<IStateService>().To<StateService>();
            Bind<IProfileRepository>().To<ProfileRepository>();

            Bind<NotificationContext>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
