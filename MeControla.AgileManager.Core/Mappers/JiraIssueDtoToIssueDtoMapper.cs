using AutoMapper;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Data.Dtos;
using MeControla.Core.Mappers;
using DtoJira = MeControla.AgileManager.Integrations.Jira.Data.Dtos;

namespace MeControla.AgileManager.Core.Mappers
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