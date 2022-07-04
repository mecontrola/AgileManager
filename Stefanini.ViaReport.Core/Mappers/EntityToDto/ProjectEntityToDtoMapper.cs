using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Mappers.EntityToDto
{
    public class ProjectEntityToDtoMapper : BaseMapper<Project, ProjectDto>, IProjectEntityToDtoMapper
    {
        private readonly IProjectCategoryEntityToDtoMapper projectCategoryEntityToDtoMapper;

        public ProjectEntityToDtoMapper(IProjectCategoryEntityToDtoMapper projectCategoryEntityToDtoMapper)
        {
            this.projectCategoryEntityToDtoMapper = projectCategoryEntityToDtoMapper;
        }

        protected override IMappingExpression<Project, ProjectDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<Project, ProjectDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                  .ForMember(dest => dest.Selected, opt => opt.MapFrom(source => source.Selected))
                  .ForMember(dest => dest.Category, opt => opt.MapFrom(source => MappingCategory(source.ProjectCategory)));

        private ProjectCategoryDto MappingCategory(ProjectCategory source)
            => projectCategoryEntityToDtoMapper.ToMap(source);
    }
}