using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Mappers.EntityToDto
{
    public class DeliveryLastCycleEpicEntityToDtoMapper : BaseMapper<IssueEpic, DeliveryLastCycleEpicDto>, IDeliveryLastCycleEpicEntityToDtoMapper
    {
        protected override IMappingExpression<IssueEpic, DeliveryLastCycleEpicDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<IssueEpic, DeliveryLastCycleEpicDto>()
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Issue.Key))
                  .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Issue.Summary))
                  .ForMember(dest => dest.Progress, opt => opt.MapFrom(source => source.Progress))
                  .ForMember(dest => dest.Link, opt => opt.MapFrom(source => source.Issue.Link));
    }
}