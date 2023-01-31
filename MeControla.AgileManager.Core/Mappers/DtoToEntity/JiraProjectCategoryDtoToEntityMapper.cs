using AutoMapper;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public class JiraProjectCategoryDtoToEntityMapper : BaseMapper<ProjectCategoryDto, ProjectCategory>, IJiraProjectCategoryDtoToEntityMapper
    {
        protected override IMappingExpression<ProjectCategoryDto, ProjectCategory> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<ProjectCategoryDto, ProjectCategory>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => long.Parse(source.Id)))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name));
    }
}