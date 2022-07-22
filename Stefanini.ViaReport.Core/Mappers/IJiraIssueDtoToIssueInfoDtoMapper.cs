using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos;
using DtoJira = Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Mappers
{
    public interface IJiraIssueDtoToIssueInfoDtoMapper : IMapper<DtoJira.IssueDto, IssueDto>
    { }
}