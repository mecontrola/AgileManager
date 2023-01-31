using AutoMapper;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.EntityToDto
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
                  .ForMember(dest => dest.Incident, opt => opt.MapFrom(source => source.Incident))
                  .ForMember(dest => dest.Labels, opt => opt.MapFrom(source => source.Labels))
                  .ForMember(dest => dest.Link, opt => opt.MapFrom(source => source.Link));
    }
}