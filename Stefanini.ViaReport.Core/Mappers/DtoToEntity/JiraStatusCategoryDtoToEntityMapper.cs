using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Mappers.DtoToEntity
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