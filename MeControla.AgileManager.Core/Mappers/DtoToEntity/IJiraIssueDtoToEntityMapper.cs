using MeControla.Core.Mappers;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public interface IJiraIssueDtoToEntityMapper : IMapper<IssueDto, Issue>
    { }
}