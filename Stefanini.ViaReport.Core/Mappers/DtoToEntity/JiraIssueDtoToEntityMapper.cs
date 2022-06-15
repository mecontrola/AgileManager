using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Mappers.DtoToEntity
{
    public class JiraIssueDtoToEntityMapper : BaseMapper<IssueDto, Issue>, IJiraIssueDtoToEntityMapper
    {
        private static readonly string[] LABELS_INCIDENTS = new string[] { "incidente", "Incidente", "incidentes", "Incidentes" };

        protected override IMappingExpression<IssueDto, Issue> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<IssueDto, Issue>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Key))
                  .ForMember(dest => dest.Summary, opt => opt.MapFrom(source => source.Fields.Summary))
                  .ForMember(dest => dest.Incident, opt => opt.MapFrom(source => HasLabelIndicent(source.Fields.Labels)))
                  .ForMember(dest => dest.Updated, opt => opt.Ignore())
                  .ForMember(dest => dest.Resolved, opt => opt.MapFrom(source => source.Fields.Resolutiondate))
                  .ForMember(dest => dest.ProjectId, opt => opt.Ignore())
                  .ForMember(dest => dest.Project, opt => opt.Ignore())
                  .ForMember(dest => dest.StatusId, opt => opt.Ignore())
                  .ForMember(dest => dest.Status, opt => opt.Ignore())
                  .ForMember(dest => dest.Statuses, opt => opt.Ignore());

        private static bool HasLabelIndicent(IList<string> labels)
            => labels.Any(label => LABELS_INCIDENTS.Any(itm => itm.Equals(label)));
    }
}