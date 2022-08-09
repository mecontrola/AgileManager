using MeControla.Core.Mappers;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;

namespace MeControla.AgileManager.Core.Mappers.EntityToDto
{
    public interface IProjectEntityToDtoMapper : IMapper<Project, ProjectDto>
    { }
}