using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System;

namespace Stefanini.ViaReport.Core.Mappers
{
    public class IssueDtoToIssueInfoDtoMapper : BaseMapper<IssueDto, IssueInfoDto>, IIssueDtoToIssueInfoDtoMapper
    {
        protected override IMappingExpression<IssueDto, IssueInfoDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<IssueDto, IssueInfoDto>()
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Key))
                  .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Fields.Summary))
                  .ForMember(dest => dest.Status, opt => opt.MapFrom(source => source.Fields.Status.Name))
                  .ForMember(dest => dest.Created, opt => opt.MapFrom(source => source.Fields.Created))
                  .ForMember(dest => dest.Resolved, opt => opt.MapFrom(source => source.Fields.Resolutiondate))
                  .ForMember(dest => dest.Link, opt => opt.MapFrom(source => MountUrlIssueJira(source.Self, source.Key)));

        private static string MountUrlIssueJira(string urlBase, string issueKey)
        {
            var uri = new Uri(urlBase);
            return $"{uri.Scheme}://{uri.Host}/browse/{issueKey}";
        }
    }
}