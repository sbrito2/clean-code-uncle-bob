
using System.Linq;
using System.Collections.Generic;
using API.Domain.Entities;
using API.Domain.Repositories;
using API.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using API.Domain.Queries;
using API.Domain.Queries.Property;
using API.Domain.UnitOfWork;
using System.IO;
using API.Domain.Notification;
namespace API.Application.Services
{
    public class PropertyService : Service<Property>, IPropertyService
    {
        private readonly IPropertyRepository propertyRepository;
        private readonly IPropertyTypeService propertyTypeService;
        private readonly IActionTypeService actionTypeService;
        private readonly IImageService imageService;
        private readonly ICityService cityService;
        private readonly string imagePath;
        private readonly int itensPerPageDefault;
        private readonly int randomPropertyTotal;

        public PropertyService(IPropertyRepository propertyRepository, IImageService imageService, IConfiguration config, IPropertyTypeService propertyTypeService, IActionTypeService actionTypeService, IUnitOfWork unitOfWork, ICityService cityService, NotificationContext notificationContext)
        : base(propertyRepository, unitOfWork, notificationContext)
        {
            this.propertyRepository = propertyRepository;
            this.imageService = imageService;
            this.propertyTypeService = propertyTypeService;
            this.actionTypeService = actionTypeService;
            this.cityService = cityService;
            this.imagePath = config.GetValue<string>("PropertyImages");
            this.itensPerPageDefault = config.GetValue<int>("ItensPerPageDefault");
            this.randomPropertyTotal = config.GetValue<int>("RandomPropertyTotal");
        }

        public void Add(Property property, List<IFormFile> photos)
        {
            if(!propertyTypeService.Any(property.PropertyTypeId))
            {
                this.notificationContext.AddNotFoundNotification("Tipo de imóvel não encontrado.");
                return;
            }

            if(!actionTypeService.Any(property.ActionTypeId ?? 0))
            {
                this.notificationContext.AddNotFoundNotification("Tipo de leilão não encontrado.");
                return;
            }

            if(!cityService.Any(property.CityId))
            {
                this.notificationContext.AddNotFoundNotification("Cidade não encontrada.");
                return;
            }

            unitOfWork.Add(property);

            unitOfWork.SaveChanges();

            if(photos != null && photos.Count() > 0)
            {
                UploadPhotos(photos, property.Id);
                property.PhotosPath =  $"{imagePath}{Path.DirectorySeparatorChar}{property.Id.ToString()}";
            }

            unitOfWork.SaveChanges();

            return;
        }

        public List<Property> GetAll()
        {
            return propertyRepository.GetAllAsNoTracking().ToList();
        }

        public void Update(Property property, List<IFormFile> photos)
        {
            if(!propertyTypeService.Any(property.PropertyTypeId))
            {
                this.notificationContext.AddNotFoundNotification("Tipo de imóvel não encontrado.");
                return;
            }

            if(!actionTypeService.Any(property.ActionTypeId ?? 0))
            {
                this.notificationContext.AddNotFoundNotification("Tipo de leilão não encontrado.");
                return;
            }

            if(photos != null && photos.Count() > 0)
            {
                UploadPhotos(photos, property.Id);
                property.PhotosPath =  $"{imagePath}{Path.DirectorySeparatorChar}{property.Id.ToString()}";
            }
            
            unitOfWork.Update(property);

            unitOfWork.SaveChanges();

            return;
        }

        public byte[] GetImage(int id, string fileName)
        {
            var property = propertyRepository.Find(id);
            if (property == null)
            {
                this.notificationContext.AddNotFoundNotification("Imóvel não encontrado");
                return null;
            }

            var bytes = imageService.DonwloadFile(imagePath, id, fileName);

            return bytes;
        }

        public bool UploadPhotos(List<IFormFile> photos, int id)
        {
            if(photos == null)
                return false;

            var folderId = id.ToString();

            foreach ((IFormFile image, int index) in photos.Select((image, index) => ( image, index )))
            {
                int fileName = index + 1;
                imageService.UploadPhoto(image, $"{fileName}.png", imagePath, folderId);
            }

            return true;
        }

        public PaginatedQueryResult<Property> Index(int page, PropertyQuery filter)
        {
            var query = new GenericPaginatedQuery<PropertyQuery>(page, itensPerPageDefault, filter);
            PaginatedQueryResult<Property> properties = propertyRepository.GetAll(query);

            return properties;
        }

        public List<Property> GetRandomProperties()
        {
           return propertyRepository.GetRamdomProperties(randomPropertyTotal);
        }
    }
}
