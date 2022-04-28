using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Stefanini.Core.TestingTools.Helpers
{
    public abstract class BaseConfigurationMockHelper
    {
        public static IConfiguration CreateEmptyConfigurationInstance()
            => CreateConfigurationInstance(new Dictionary<string, string>());

        protected static IConfiguration CreateConfigurationInstance(IDictionary<string, string> dataSettings)
            => new ConfigurationBuilder().AddInMemoryCollection(dataSettings)
                                         .Build();
    }
}