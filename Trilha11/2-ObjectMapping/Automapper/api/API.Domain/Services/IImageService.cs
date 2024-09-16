using Microsoft.AspNetCore.Http;

namespace API.Domain.Services
{
    public interface IImageService
    {
        string UploadPhoto(IFormFile file, string NameAndExtension, string directory, string folder);
        byte[] DonwloadFile(string path, int id, string fileName, string extension = null);
    }
}