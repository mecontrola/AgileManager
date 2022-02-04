using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var act = () => action((IServiceCollection)null);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}