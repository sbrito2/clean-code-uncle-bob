using AutoMapper;

namespace API.Presentation.API.AutoMapper
{
    public class GlobalMapProfile : Profile
    {
        public GlobalMapProfile()
        {
            CreateMap<string, string>()
                .ConvertUsing(str => (str != null) ? str.Trim() : str);  
        }
    }
}