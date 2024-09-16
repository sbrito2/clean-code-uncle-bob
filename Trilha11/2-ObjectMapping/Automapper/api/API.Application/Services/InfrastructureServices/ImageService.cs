using System.IO;
using System.Threading.Tasks;
using API.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
using System;
using API.CrossCutting.Utils.Security.Exceptions;

namespace API.Application.Services.InfrastructureServices
{
    public class ImageService : IImageService
    {
        public ImageService()
        {
            
        }

        public async Task<byte[]> ConvertFileToBytes(IFormFile formFile)
        {
            if (formFile.Length <= 0)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                await formFile.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

        public string UploadPhoto(IFormFile file, string NameAndExtension, string directory, string folder)
        {
            var path = directory + Path.DirectorySeparatorChar;
            path += folder;
            string finalPath = path + Path.DirectorySeparatorChar + NameAndExtension;

            try
            {
                Directory.CreateDirectory(path);
            
                Image image = Image.FromStream(file.OpenReadStream(), true, true);
                bool needsResize = image.Width > 800 || image.Height > 600;

                using (FileStream stream = new FileStream(finalPath, FileMode.Create))
                {
                    if (needsResize)
                    {
                        Image resized = ScaleImage(image, 800, 600);
                        resized.Save(stream, ImageFormat.Png);
                    }
                    else
                    {
                        image.Save(stream, ImageFormat.Png);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ConflictException(ex.Message);
            }

            return finalPath;
        }

        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public byte[] DonwloadFile(string path, int id, string fileName, string extension = null)
        {
            if(extension == null) extension = "png";

            if (!VerifyImageExist(path, id, fileName, extension))
            {
                throw new NotFoundException("Arquivo não encontrado");
            }

            using (FileStream stream = new FileStream($"{path}/{id}/{fileName}.{extension}", FileMode.Open, FileAccess.Read))
            {
                // Read the source file into a byte array.
                byte[] bytes = new byte[stream.Length];
                int numBytesToRead = (int)stream.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = stream.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                         break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = bytes.Length;
                return  bytes; 
            }
        }

        private static bool VerifyImageExist(string path, int id, string fileName, string extension )
        {
            return File.Exists($"{path}/{id}/{fileName}.{extension}");
        }
    }
}