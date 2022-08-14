using AutoMapper;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public class JiraFieldDtoToEntityMapper : BaseMapper<FieldDto, Customfield>, IJiraFieldDtoToEntityMapper
    {
        protected override IMappingExpression<FieldDto, Customfield> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<FieldDto, Customfield>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Key))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                  .ForMember(dest => dest.Type, opt => opt.MapFrom(source => source.Schema.Type))
                  .ForMember(dest => dest.Custom, opt => opt.MapFrom(source => source.Schema.Custom));
    }
}