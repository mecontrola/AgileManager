using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Mappers.DtoToEntity
{
    public interface IJiraProjectCategoryDtoToEntityMapper : IMapper<ProjectCategoryDto, ProjectCategory>
    { }
}