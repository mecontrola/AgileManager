using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Mappers.EntityToDto
{
    public class ProjectCategoryEntityToDtoMapper : BaseMapper<ProjectCategory, ProjectCategoryDto>, IProjectCategoryEntityToDtoMapper
    {
        protected override IMappingExpression<ProjectCategory, ProjectCategoryDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<ProjectCategory, ProjectCategoryDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name));
    }
}