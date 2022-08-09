using AutoMapper;
using MeControla.Core.Mappers;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public class JiraIssueTypeDtoToEntityMapper : BaseMapper<IssueTypeDto, IssueType>, IJiraIssueTypeDtoToEntityMapper
    {
        protected override IMappingExpression<IssueTypeDto, IssueType> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<IssueTypeDto, IssueType>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name));
    }
}