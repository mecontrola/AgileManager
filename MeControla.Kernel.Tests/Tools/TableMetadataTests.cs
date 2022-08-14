using FluentAssertions;
using MeControla.Kernel.Tests.Data.Entities;
using MeControla.Kernel.Tools;
using Xunit;

namespace MeControla.Kernel.Tests.Tools
{
    public class TableMetadataTests
    {
        private readonly TableMetadata<ClassTest> tool;

        public TableMetadataTests()
            => tool = new TableMetadata<ClassTest>("tst", "cst");

        [Fact(DisplayName = "[TableMetadata.GetTableName] Deve gerar o nome da tabela a partir do tipo da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeTabelaDaTipoClasseInformadoComPrefixo()
            => tool.GetTableName()
                   .Should()
                   .BeEquivalentTo("tst_class_test");

        [Fact(DisplayName = "[TableMetadata.GetColumnName] Deve gerar o nome da columna a partir da propriedade  da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeColunaDaPropriedadeClasseInformadaComPrefixo()
            => tool.GetColumnName(x => x.FieldInClass1)
                   .Should()
                   .BeEquivalentTo("cst_field_in_class1");
    }
}