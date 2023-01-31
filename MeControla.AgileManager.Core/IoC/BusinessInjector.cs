using MeControla.AgileManager.Core.Business;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace MeControla.AgileManager.Core.IoC
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
            services.TryAddScoped<IDeployBusiness, DeployBusiness>();

            services.TryAddScoped<IProjectBusiness, ProjectBusiness>();
            services.TryAddScoped<IQuarterBusiness, QuarterBusiness>();
            services.TryAddScoped<ISettingsBusiness, SettingsBusiness>();
            services.TryAddScoped<ISynchronizerBusiness, SynchronizerBusiness>();
        }
    }
}