using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira;
using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Exceptions;
using MeControla.AgileManager.Integrations.Jira.Tests.Data.Entities;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Entities;
using MeControla.AgileManager.TestingTools.Helpers;
using MeControla.Core.Extensions;
using Microsoft.Extensions.Options;
using NSubstitute;
using System.IO;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira
{
    public class CacheTests
    {
        private const string FOLDER_CACHE = "caches";

        private IOptionsMonitor<CacheConfiguration> GetConfiguration()
        {
            var optionsMonitor = Substitute.For<IOptionsMonitor<CacheConfiguration>>();
            optionsMonitor.CurrentValue.Returns(configuration);

            return optionsMonitor;
        }

        private readonly Cache cache;
        private readonly CacheConfiguration configuration;

        public CacheTests()
        {
            configuration = new CacheConfiguration
            {
                Cache = 20
            };

            cache = new Cache(GetConfiguration());
            cache.Clear();
        }

        [Fact(DisplayName = "[Cache.Write|Read] Deve salvar o arquivo de cache e carregar em seguida.")]
        public void DeveEscreveLerCache()
        {
            var key = TestHelper.GetCurrentMethodName();

            cache.Write(key, DataMock.JSON_CLASS_TEST);

            cache.Read(key).Should().Be(DataMock.JSON_CLASS_TEST);
        }

        [Fact(DisplayName = "[Cache.Write|Read] Deve salvar um objeto em um arquivo de cache e carregar em seguida.")]
        public void DeveEscreveLerObjetoCache()
        {
            var key = TestHelper.GetCurrentMethodName();
            var expected = ClassTestMock.Create();

            cache.Write(key, expected);

            var actual = cache.Read<ClassTest>(key);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[Cache.IsExpired] Deve retornar true quando o cache estiver desligado.")]
        public void DeveRetornarTrueQuandoCacheInativo()
        {
            var key = TestHelper.GetCurrentMethodName();
            configuration.Cache = 0;

            cache.IsExpired(key).Should().BeTrue();

            cache.Write(key, DataMock.JSON_CLASS_TEST);

            cache.IsExpired(key).Should().BeTrue();
        }

        [Fact(DisplayName = "[Cache.IsExpired] Deve retornar true quando escrever um objeto e o cache estiver desligado.")]
        public void DeveRetornarTrueQuandoEscreveObjetoCacheInativo()
        {
            var key = TestHelper.GetCurrentMethodName();
            configuration.Cache = 0;

            cache.IsExpired(key).Should().BeTrue();

            cache.Write(key, ClassTestMock.Create());

            cache.IsExpired(key).Should().BeTrue();
        }

        [Fact(DisplayName = "[Cache.IsExpired] Deve retornar false quando o cache estiver dentro do tempo de validade.")]
        public void DeveRetornarFalseQuandoCacheValido()
        {
            var key = TestHelper.GetCurrentMethodName();

            cache.IsExpired(key).Should().BeTrue();

            cache.Write(key, DataMock.JSON_CLASS_TEST);

            cache.IsExpired(key).Should().BeFalse();
        }

        [Fact(DisplayName = "[Cache.IsExpired] Deve retornar true quando o cache estiver fora do tempo de validade.")]
        public void DeveRetornarTrueQuandoTempoMaiorQueConfigurado()
        {
            var key = TestHelper.GetCurrentMethodName();

            cache.IsExpired(key).Should().BeTrue();

            cache.Write(key, DataMock.JSON_CLASS_TEST);

            ChangeLastAccessTimeTo1HourAgo(key);

            cache.IsExpired(key).Should().BeTrue();
        }

        [Fact(DisplayName = "[Cache.ContainsKey] Deve retornar false quando a chave não existir.")]
        public void DeveRetornarFalseQuandoCacheNaoExistir()
        {
            var key = TestHelper.GetCurrentMethodName();

            cache.ContainsKey(key).Should().BeFalse();
        }

        [Fact(DisplayName = "[Cache.ContainsKey] Deve retornar true quando a chave existir.")]
        public void DeveRetornarTrueQuandoCacheExistir()
        {
            var key = TestHelper.GetCurrentMethodName();

            cache.Write(key, DataMock.JSON_CLASS_TEST);

            cache.ContainsKey(key).Should().BeTrue();
        }

        [Fact(DisplayName = "[Cache.Write] Deve retornar true quando cache estiver desativado e houver tentativa de escrita.")]
        public void DeveRetornarTrueQuandoCacheInativoComTentativaEscrita()
        {
            var key = TestHelper.GetCurrentMethodName();
            configuration.Cache = 0;

            cache.Write(key, DataMock.JSON_CLASS_TEST);

            cache.IsExpired(key).Should().BeTrue();
        }

        [Fact(DisplayName = "[Cache.Read] Deve gerar a exceção CacheNotFoundException quando a chave não existir.")]
        public void DeveGerarCacheNotFoundExceptionQuandoChaveInexistente()
        {
            var action = () => cache.Read(DataMock.VALUE_USERNAME);
            action.Should().Throw<CacheNotFoundException>();
        }

        ~CacheTests()
        {
            cache.Clear();
        }

        private static void ChangeLastAccessTimeTo1HourAgo(string key)
        {
            var filename = Path.Combine(PathBase(), $"{key.ToMD5()}.cache");
            var lastAccessTime = File.GetLastAccessTime(filename);

            File.SetLastAccessTime(filename, lastAccessTime.AddHours(-1));
        }

        private static string PathBase()
            => Path.Combine(Directory.GetCurrentDirectory(), FOLDER_CACHE);
    }
}