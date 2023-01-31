using MeControla.AgileManager.Data.Dtos;
using MeControla.Core.Mappers;
using DtoJira = MeControla.AgileManager.Integrations.Jira.Data.Dtos;

namespace MeControla.AgileManager.Core.Mappers
{
    public interface IJiraIssueDtoToIssueInfoDtoMapper : IMapper<DtoJira.IssueDto, IssueDto>
    { }
}