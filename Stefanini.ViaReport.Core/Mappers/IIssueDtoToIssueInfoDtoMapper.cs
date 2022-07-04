using MeControla.Core.Mappers;
using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Mappers
{
    public interface IIssueDtoToIssueInfoDtoMapper : IMapper<IssueDto, IssueInfoDto>
    { }
}