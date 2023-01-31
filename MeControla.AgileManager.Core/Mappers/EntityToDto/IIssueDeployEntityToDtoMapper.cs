using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.EntityToDto
{
    public interface IIssueDeployEntityToDtoMapper : IMapper<Issue, IssueDeployDto>
    { }
}