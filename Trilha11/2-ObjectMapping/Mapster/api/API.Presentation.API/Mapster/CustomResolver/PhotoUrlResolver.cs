// using System;
// using System.Collections.Generic;
// using System.IO;
// using API.Domain.Entities.Base;
// using Microsoft.Extensions.Configuration;

// namespace API.Presentation.API.AutoMapper.CustomResolver
// {
//     public class PhotoUrlResolver<TEntity> : IMemberValueResolver<TEntity, Object, string, List<string>> where TEntity : Entity
//     {
//         private readonly string DownloadUrl;
//         private readonly string[] Extensions = {".png", ".jpeg"};

//         public PhotoUrlResolver(IConfiguration config)
//         {
//             this.DownloadUrl = config.GetValue<string>($"{typeof(TEntity).Name}ImageUrl");
//         }

//         public List<string> Resolve(TEntity source, Object destination, string sourceMember, List<string> destMember, ResolutionContext context)
//         {
//             return GetPhotoUrls(source.Id, sourceMember);
//         }

//         private List<string> GetPhotoUrls(int id, string path)
//         {
//             if(path == null)
//                 return null;

//             string[] files = Directory.GetFiles(path);
//             List<string> paths = new List<string>();

//             foreach(var file in files)
//             {
//                 string fileName = Path.GetFileNameWithoutExtension(file);
//                 paths.Add(string.Format(DownloadUrl, id, fileName));
//             }

//             return paths;
//         }
//     }
// }