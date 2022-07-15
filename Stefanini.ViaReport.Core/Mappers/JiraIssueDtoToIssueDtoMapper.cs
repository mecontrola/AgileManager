using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Data.Dtos;
using DtoJira = Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Mappers
{
    public class JiraIssueDtoToIssueDtoMapper : BaseMapper<DtoJira.IssueDto, IssueDto>, IJiraIssueDtoToIssueInfoDtoMapper
    {
        private readonly IMountJiraUrlHelper mountJiraUrlHelper;

        public JiraIssueDtoToIssueDtoMapper(IMountJiraUrlHelper mountJiraUrlHelper)
        {
            this.mountJiraUrlHelper = mountJiraUrlHelper;
        }

        protected override IMappingExpression<DtoJira.IssueDto, IssueDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<DtoJira.IssueDto, IssueDto>()
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Key))
                  .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Fields.Summary))
                  .ForMember(dest => dest.Status, opt => opt.MapFrom(source => source.Fields.Status.Name))
                  .ForMember(dest => dest.Created, opt => opt.MapFrom(source => source.Fields.Created))
                  .ForMember(dest => dest.Resolved, opt => opt.MapFrom(source => source.Fields.Resolutiondate))
                  .ForMember(dest => dest.Link, opt => opt.MapFrom(source => mountJiraUrlHelper.GetIssueUrl(source.Self, source.Key)));
    }
}