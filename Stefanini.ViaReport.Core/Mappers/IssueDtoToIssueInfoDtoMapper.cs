using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System;

namespace Stefanini.ViaReport.Core.Mappers
{
    public class IssueDtoToIssueInfoDtoMapper : BaseMapper<IssueDto, IssueInfoDto>, IIssueDtoToIssueInfoDtoMapper
    {
        public override IssueInfoDto ToMap(IssueDto obj)
            => obj == null
             ? null
             : new()
             {
                 Key = obj.Key,
                 Description = obj.Fields.Summary,
                 Status = obj.Fields.Status.Name,
                 Created = obj.Fields.Created,
                 Resolved = obj.Fields.Resolutiondate,
                 Link = MountUrlIssueJira(obj.Self, obj.Key)
             };

        private static string MountUrlIssueJira(string urlBase, string issueKey)
        {
            var uri = new Uri(urlBase);
            return $"{uri.Scheme}://{uri.Host}/browse/{issueKey}";
        }
    }
}