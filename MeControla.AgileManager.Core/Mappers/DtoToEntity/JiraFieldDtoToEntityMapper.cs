using AutoMapper;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public class JiraFieldDtoToEntityMapper : BaseMapper<FieldDto, CustomField>, IJiraFieldDtoToEntityMapper
    {
        protected override IMappingExpression<FieldDto, CustomField> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<FieldDto, CustomField>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Key))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                  .ForMember(dest => dest.Type, opt => opt.MapFrom(source => source.Schema.Type))
                  .ForMember(dest => dest.Custom, opt => opt.MapFrom(source => source.Schema.Custom));
    }
}