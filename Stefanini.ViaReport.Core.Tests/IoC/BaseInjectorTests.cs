using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public abstract class BaseInjectorTests
    {
        protected readonly IServiceCollection serviceCollection;

        public BaseInjectorTests()
        {
            serviceCollection = new ServiceCollection();
        }

        protected static void RunServiceCollectionNull(Action<IServiceCollection> action)
        {
            var act = () => action(null);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}