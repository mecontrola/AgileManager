using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Mappers.EntityToDto
{
    public class IssueEntityToDtoMapper : BaseMapper<Issue, IssueDto>, IIssueEntityToDtoMapper
    {
        protected override IMappingExpression<Issue, IssueDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<Issue, IssueDto>()
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Key))
                  .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Summary))
                  .ForMember(dest => dest.Status, opt => opt.MapFrom(source => source.Status.Name))
                  .ForMember(dest => dest.Created, opt => opt.MapFrom(source => source.Created))
                  .ForMember(dest => dest.Resolved, opt => opt.MapFrom(source => source.Resolved))
                  .ForMember(dest => dest.Link, opt => opt.MapFrom(source => source.Link));
    }
}