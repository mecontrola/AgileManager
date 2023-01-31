using MeControla.AgileManager.Core.Mappers;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace MeControla.AgileManager.Core.IoC
{
    public static class MappersInjector
    {
        public static void AddMappers(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddSingleton<IJiraIssueDtoToIssueInfoDtoMapper, JiraIssueDtoToIssueDtoMapper>();

            AddDtoToEntityMapperServices(services);

            AddEntityToDtoMapperServices(services);
        }

        private static void AddDtoToEntityMapperServices(IServiceCollection services)
        {
            services.TryAddSingleton<IJiraClasseOfServiceDtoToEntityMapper, JiraClasseOfServiceDtoToEntityMapper>();
            services.TryAddSingleton<IJiraFieldDtoToEntityMapper, JiraFieldDtoToEntityMapper>();
            services.TryAddSingleton<IJiraIssueDtoToEntityMapper, JiraIssueDtoToEntityMapper>();
            services.TryAddSingleton<IJiraIssueTypeDtoToEntityMapper, JiraIssueTypeDtoToEntityMapper>();
            services.TryAddSingleton<IJiraProjectDtoToEntityMapper, JiraProjectDtoToEntityMapper>();
            services.TryAddSingleton<IJiraProjectCategoryDtoToEntityMapper, JiraProjectCategoryDtoToEntityMapper>();
            services.TryAddSingleton<IJiraStatusDtoToEntityMapper, JiraStatusDtoToEntityMapper>();
            services.TryAddSingleton<IJiraStatusCategoryDtoToEntityMapper, JiraStatusCategoryDtoToEntityMapper>();
        }

        private static void AddEntityToDtoMapperServices(IServiceCollection services)
        {
            services.TryAddSingleton<IDeliveryLastCycleEpicEntityToDtoMapper, DeliveryLastCycleEpicEntityToDtoMapper>();
            services.TryAddSingleton<IIssueDeployEntityToDtoMapper, IssueDeployEntityToDtoMapper>();
            services.TryAddSingleton<IIssueEntityToDtoMapper, IssueEntityToDtoMapper>();
            services.TryAddSingleton<IProjectEntityToDtoMapper, ProjectEntityToDtoMapper>();
            services.TryAddSingleton<IProjectCategoryEntityToDtoMapper, ProjectCategoryEntityToDtoMapper>();
            services.TryAddSingleton<IQuarterEntityToDtoMapper, QuarterEntityToDtoMapper>();
        }
    }
}