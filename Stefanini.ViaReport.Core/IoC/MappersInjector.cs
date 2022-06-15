using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Core.Mappers.EntityToDto;
using System;

namespace Stefanini.ViaReport.Core.IoC
{
    public static class MappersInjector
    {
        public static void AddMappers(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddSingleton<IIssueDtoToIssueInfoDtoMapper, IssueDtoToIssueInfoDtoMapper>();

            AddDtoToEntityMapperServices(services);

            AddEntityToDtoMapperServices(services);
        }

        private static void AddDtoToEntityMapperServices(IServiceCollection services)
        {
            services.TryAddSingleton<IJiraIssueDtoToEntityMapper, JiraIssueDtoToEntityMapper>();
            services.TryAddSingleton<IJiraIssueTypeDtoToEntityMapper, JiraIssueTypeDtoToEntityMapper>();
            services.TryAddSingleton<IJiraProjectDtoToEntityMapper, JiraProjectDtoToEntityMapper>();
            services.TryAddSingleton<IJiraProjectCategoryDtoToEntityMapper, JiraProjectCategoryDtoToEntityMapper>();
            services.TryAddSingleton<IJiraStatusDtoToEntityMapper, JiraStatusDtoToEntityMapper>();
            services.TryAddSingleton<IJiraStatusCategoryDtoToEntityMapper, JiraStatusCategoryDtoToEntityMapper>();
        }

        private static void AddEntityToDtoMapperServices(IServiceCollection services)
        {
            services.TryAddSingleton<IProjectEntityToDtoMapper, ProjectEntityToDtoMapper>();
            services.TryAddSingleton<IProjectCategoryEntityToDtoMapper, ProjectCategoryEntityToDtoMapper>();
        }
    }
}