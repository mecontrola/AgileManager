using FluentAssertions;
using MeControla.AgileManager.Core.Converters;
using MeControla.AgileManager.Core.Tests.Data.Entities;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Entities;
using System.Text.Json;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Converters
{
    public class DateTimeJiraConverterTests
    {
        private readonly JsonSerializerOptions options;

        public DateTimeJiraConverterTests()
        {
            options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeJiraConverter());
        }

        [Fact(DisplayName = "[DateTimeJiraConverter.Write] Deve converter campo do tipo DateTime para string json no formato de data brasileiro.")]
        public void DeveConverterValorDateTimeParaJson()
        {
            var actual = JsonSerializer.Serialize(ClassTestMock.Create(), options);
            var expected = DataMock.JSON_CLASS_TEST_DATE;

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[DateTimeJiraConverter.Read] Deve converter string json que contem o campo de data para o tipo DateTime.")]
        public void DeveConverterValorJsonParaDateTime()
        {
            var actual = JsonSerializer.Deserialize<ClassTest>(DataMock.JSON_CLASS_TEST_DATE, options);
            var expected = ClassTestMock.Create();

            actual.Should().NotBeNull();
            actual.Should().BeOfType<ClassTest>();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}