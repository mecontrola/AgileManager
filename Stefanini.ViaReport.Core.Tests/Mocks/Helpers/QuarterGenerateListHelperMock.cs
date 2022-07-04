using NSubstitute;
using Stefanini.ViaReport.Core.Helpers;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Helpers
{
    public class QuarterGenerateListHelperMock
    {
        public static IQuarterGenerateListHelper Create()
        {
            var helper = Substitute.For<IQuarterGenerateListHelper>();
            helper.Create(Arg.Any<DateTime>())
                  .Returns(CreateListQuarter());

            return helper;
        }

        private static IList<string> CreateListQuarter()
            => new List<string>
            {
                DataMock.TEXT_QUARTER_1_2000,
                DataMock.TEXT_QUARTER_2_2000,
                DataMock.TEXT_QUARTER_3_2000,
                DataMock.TEXT_QUARTER_4_2000,
            };
    }
}