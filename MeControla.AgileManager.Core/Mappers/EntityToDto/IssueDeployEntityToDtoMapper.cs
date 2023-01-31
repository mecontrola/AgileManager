using AutoMapper;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Core.Mappers.EntityToDto
{
    public class IssueDeployEntityToDtoMapper : BaseMapper<Issue, IssueDeployDto>, IIssueDeployEntityToDtoMapper
    {
        protected override IMappingExpression<Issue, IssueDeployDto> CreateMap(IMapperConfigurationExpression cfg)
            => cfg.CreateMap<Issue, IssueDeployDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Deploy.Uuid))
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(source => source.Key))
                  .ForMember(dest => dest.Summary, opt => opt.MapFrom(source => source.Summary))
                  .ForMember(dest => dest.Environment, opt => opt.MapFrom(source => source.Labels))
                  .ForMember(dest => dest.Services, opt => opt.MapFrom(source => source.Deploy.Services))
                  .ForMember(dest => dest.FinishedIn, opt => opt.MapFrom(source => GetFinishedIn(source.Statuses)))
                  .ForMember(dest => dest.DeployedIn, opt => opt.MapFrom(source => source.Deploy.DeployedIn))
                  .ForMember(dest => dest.IssueId, opt => opt.MapFrom(source => source.Uuid));

        private static DateTime GetFinishedIn(IList<IssueStatusHistory> statuses)
            => statuses.Where(x => x.FromStatusId == 71
                                && (x.ToStatusId == 52 || x.ToStatusId == 72))
                       .Select(x => x.DateTime)
                       .OrderBy(x => x)
                       .First();
    }
}