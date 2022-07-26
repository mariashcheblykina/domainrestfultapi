using AutoMapper;
using DomainTestWebApi.Models;
using DomainTestWebApi.Resources;

namespace DomainTestWebApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<MainEntity, MainEntityResource>();
            CreateMap<CreateUpdateMainEntityResource, MainEntity>();
        }
        
    }
}