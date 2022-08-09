using AutoMapper;
using MeControla.Core.Mappers;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public class JiraStatusCategoryDtoToEntityMapper : BaseMapper<StatusCategoryDto, StatusCategory>, IJiraStatusCategoryDtoToEntityMapper
    {
        protected override IMappingExpression<StatusCategoryDto, StatusCategory> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<StatusCategoryDto, StatusCategory>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name));
    }
}