using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using API.Domain.CoreLogic.Entities.Base;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace API.Presentation.API.AutoMapper.CustomResolver
{
    public class RandomPhotoUrlResolver<TEntity> : IMemberValueResolver<TEntity, Object, string, string> where TEntity : Entity
    {
        private readonly string DownloadUrl;
        private readonly string[] Extensions = {".png", ".jpeg"};

        public RandomPhotoUrlResolver(IConfiguration config)
        {
            this.DownloadUrl = config.GetValue<string>($"{typeof(TEntity).Name}ImageUrl");
        }

        public string Resolve(TEntity source, Object destination, string sourceMember, string destMember, ResolutionContext context)
        {
            return GetPhotoUrl(source.Id, sourceMember);
        }

        private string GetPhotoUrl(int id, string path)
        {
            if(path == null)
                return null;

            string[] files = Directory.GetFiles(path);

            string fileName = Path.GetFileNameWithoutExtension(files.FirstOrDefault());
            return (string.Format(DownloadUrl, id, fileName));
        }
    }
}