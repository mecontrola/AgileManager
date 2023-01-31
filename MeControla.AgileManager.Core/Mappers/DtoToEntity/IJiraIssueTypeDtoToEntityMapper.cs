using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public interface IJiraIssueTypeDtoToEntityMapper : IMapper<IssueTypeDto, IssueType>
    { }
}