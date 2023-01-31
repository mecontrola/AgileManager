using AutoMapper;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public class JiraProjectDtoToEntityMapper : BaseMapper<ProjectDto, Project>, IJiraProjectDtoToEntityMapper
    {
        protected override IMappingExpression<ProjectDto, Project> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<ProjectDto, Project>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => long.Parse(source.Id)))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                  .ForMember(dest => dest.ProjectCategoryId, opt => opt.Ignore())
                  .ForMember(dest => dest.ProjectCategory, opt => opt.Ignore());
    }
}