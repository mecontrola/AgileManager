using AutoMapper;
using MeControla.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Mappers.DtoToEntity
{
    public class JiraStatusDtoToEntityMapper : BaseMapper<StatusDto, Status>, IJiraStatusDtoToEntityMapper
    {
        protected override IMappingExpression<StatusDto, Status> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<StatusDto, Status>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => long.Parse(source.Id)))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                  .ForMember(dest => dest.StatusCategoryId, opt => opt.Ignore())
                  .ForMember(dest => dest.StatusCategory, opt => opt.Ignore());
    }
}