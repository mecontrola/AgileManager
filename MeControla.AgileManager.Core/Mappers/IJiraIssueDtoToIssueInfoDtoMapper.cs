using MeControla.Core.Mappers;
using MeControla.AgileManager.Data.Dtos;
using DtoJira = MeControla.AgileManager.Data.Dtos.Jira;

namespace MeControla.AgileManager.Core.Mappers
{
    public interface IJiraIssueDtoToIssueInfoDtoMapper : IMapper<DtoJira.IssueDto, IssueDto>
    { }
}