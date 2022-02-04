using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.Core.Mappers;
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
        }
    }
}