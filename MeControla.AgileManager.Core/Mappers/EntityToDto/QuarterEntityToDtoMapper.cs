using AutoMapper;
using MeControla.Core.Mappers;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;

namespace MeControla.AgileManager.Core.Mappers.EntityToDto
{
    public class QuarterEntityToDtoMapper : BaseMapper<Quarter, QuarterDto>, IQuarterEntityToDtoMapper
    {
        protected override IMappingExpression<Quarter, QuarterDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<Quarter, QuarterDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name));
    }
}