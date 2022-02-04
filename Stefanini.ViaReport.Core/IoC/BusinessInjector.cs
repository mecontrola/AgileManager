using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.Core.Business;
using System;

namespace Stefanini.ViaReport.Core.IoC
{
    public static class BusinessInjector
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddScoped<IDashboardBusiness, DashboardBusiness>();
            services.TryAddScoped<IDownstreamJiraIndicatorsBusiness, DownstreamJiraIndicatorsBusiness>();
            services.TryAddScoped<IFixVersionBusiness, FixVersionBusiness>();
            services.TryAddScoped<IUpstreamDownstreamRateBusiness, UpstreamDownstreamRateBusiness>();
        }
    }
}