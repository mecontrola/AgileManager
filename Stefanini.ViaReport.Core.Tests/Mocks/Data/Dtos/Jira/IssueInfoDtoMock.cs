using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class IssueInfoDtoMock
    {
        public static IssueInfoDto CreateIssue1()
            => new()
            {
                Key = DataMock.ISSUE_KEY_1,
                Description = DataMock.ISSUE_DESCRIPTION_1,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Link = DataMock.ISSUE_LINK_1,
                Status = DataMock.ISSUE_STATUS_1,
            };

        public static IssueInfoDto CreateIssue2()
            => new()
            {
                Key = DataMock.ISSUE_KEY_2,
                Description = DataMock.ISSUE_DESCRIPTION_2,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Link = DataMock.ISSUE_LINK_2,
                Status = DataMock.ISSUE_STATUS_2,
            };

        public static IList<IssueInfoDto> CreateList()
            => new List<IssueInfoDto>
            {
                CreateIssue1(),
                CreateIssue2()
            };

        public static IList<IssueInfoDto> CreateDoneList()
            => new List<IssueInfoDto>
            {
                 CreateDoneIssueSea219(),
                 CreateDoneIssueSea230(),
                 CreateDoneIssueSea232(),
                 CreateDoneIssueSea233(),
                 CreateDoneIssueSea234(),
                 CreateDoneIssueSea235(),
                 CreateDoneIssueSea236(),
                 CreateDoneIssueSea237(),
                 CreateDoneIssueSea245(),
                 CreateDoneIssueSea246(),
                 CreateDoneIssueSea248(),
                 CreateDoneIssueSea254(),
                 CreateDoneIssueSea255(),
                 CreateDoneIssueSea257(),
                 CreateDoneIssueSea259(),
                 CreateDoneIssueSea262(),
                 CreateDoneIssueSea264(),
                 CreateDoneIssueSea266(),
                 CreateDoneIssueSea267(),
                 CreateDoneIssueSea273(),
            };

        private static IssueInfoDto CreateDoneIssueSea219()
            => new()
            {
                Created = new(2022, 1, 20, 9, 33, 58, 590),
                Description = "IOS - implementar excluir histórico total e registro unitário",
                Key = "SEA-219",
                Link = "https://jira.viavarejo.com.br/browse/SEA-219",
                Resolved = new(2022, 2, 22, 16, 34, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea230()
            => new()
            {
                Created = new(2022, 2, 2, 9, 47, 0, 173),
                Description = "IOS- Implementar tela de histórico de busca",
                Key = "SEA-230",
                Link = "https://jira.viavarejo.com.br/browse/SEA-230",
                Resolved = new(2022, 2, 22, 16, 34, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea232()
            => new()
            {
                Created = new(2022, 2, 2, 10, 22, 16, 390),
                Description = "BFF - Mapear a nova opção de ordenação - Novidade ",
                Key = "SEA-232",
                Link = "https://jira.viavarejo.com.br/browse/SEA-232",
                Resolved = new(2022, 2, 21, 8, 47, 30, 757),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea233()
            => new()
            {
                Created = new(2022, 2, 2, 10, 22, 52, 397),
                Description = "Android - Listar nova opção de ordenação - novidades",
                Key = "SEA-233",
                Link = "https://jira.viavarejo.com.br/browse/SEA-233",
                Resolved = new(2022, 2, 22, 16, 35, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea234()
            => new()
            {
                Created = new(2022, 2, 4, 10, 52, 48, 547),
                Description = "BFF - Correção de frete grátis após modificação da linx",
                Key = "SEA-234",
                Link = "https://jira.viavarejo.com.br/browse/SEA-234",
                Resolved = new(2022, 2, 22, 16, 35, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea235()
            => new()
            {
                Created = new(2022, 2, 4, 11, 15, 37, 633),
                Description = "Android - Ajuste no comportamento do frete grátis",
                Key = "SEA-235",
                Link = "https://jira.viavarejo.com.br/browse/SEA-235",
                Resolved = new(2022, 2, 22, 16, 35, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea236()
            => new()
            {
                Created = new(2022, 2, 4, 12, 18, 32, 127),
                Description = "nova label de CEP Implementar Android",
                Key = "SEA-236",
                Link = "https://jira.viavarejo.com.br/browse/SEA-236",
                Resolved = new(2022, 3, 4, 8, 57, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea237()
            => new()
            {
                Created = new(2022, 2, 4, 12, 18, 56, 507),
                Description = "Nova label de CEP Implementar IOS",
                Key = "SEA-237",
                Link = "https://jira.viavarejo.com.br/browse/SEA-237",
                Resolved = new(2022, 3, 4, 8, 57, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea245()
            => new()
            {
                Created = new(2022, 2, 10, 11, 32, 45, 783),
                Description = "Implementar Android solução para envio de Single ID SF",
                Key = "SEA-245",
                Link = "https://jira.viavarejo.com.br/browse/SEA-245",
                Resolved = new(2022, 2, 21, 8, 47, 56, 997),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea246()
            => new()
            {
                Created = new(2022, 2, 11, 9, 3, 19, 843),
                Description = "Implementar IOS solução para envio de Single ID SF",
                Key = "SEA-246",
                Link = "https://jira.viavarejo.com.br/browse/SEA-246",
                Resolved = new(2022, 2, 21, 8, 47, 32, 503),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea248()
            => new()
            {
                Created = new(2022, 2, 11, 12, 13, 10, 417),
                Description = "iOS - Histórico de busca: Implementar animação",
                Key = "SEA-248",
                Link = "https://jira.viavarejo.com.br/browse/SEA-248",
                Resolved = new(2022, 2, 22, 16, 34, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea254()
            => new()
            {
                Created = new(2022, 2, 14, 9, 48, 44, 487),
                Description = "O app não está apresentando os filtros laterais ao acessar categoria \"Fogão a lenha\"",
                Key = "SEA-254",
                Link = "https://jira.viavarejo.com.br/browse/SEA-254",
                Resolved = new(2022, 2, 21, 8, 46, 33, 027),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea255()
            => new()
            {
                Created = new(2022, 2, 14, 10, 54, 7, 283),
                Description = "IOS- Listar nova opção de ordenação - novidades",
                Key = "SEA-255",
                Link = "https://jira.viavarejo.com.br/browse/SEA-255",
                Resolved = new(2022, 2, 25, 8, 51, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea257()
            => new()
            {
                Created = new(2022, 2, 14, 15, 21, 43, 240),
                Description = " Alterar composições de frete grátis no Firebase ",
                Key = "SEA-257",
                Link = "https://jira.viavarejo.com.br/browse/SEA-257",
                Resolved = new(2022, 2, 21, 8, 47, 34, 170),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea259()
            => new()
            {
                Created = new(2022, 2, 18, 9, 39, 18, 210),
                Description = "Bug da esposa do Edinho",
                Key = "SEA-259",
                Link = "https://jira.viavarejo.com.br/browse/SEA-259",
                Resolved = new(2022, 3, 2, 9, 27, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea262()
            => new()
            {
                Created = new(2022, 2, 23, 10, 34, 29, 27),
                Description = "Android - Não salvando o CEP na primeira utilização",
                Key = "SEA-262",
                Link = "https://jira.viavarejo.com.br/browse/SEA-262",
                Resolved = new(2022, 3, 3, 10, 57, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea264()
            => new()
            {
                Created = new(2022, 2, 24, 9, 16, 10, 917),
                Description = "BFF- Correção emergencial departamentos na home",
                Key = "SEA-264",
                Link = "https://jira.viavarejo.com.br/browse/SEA-264",
                Resolved = new(2022, 3, 3, 10, 57, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea266()
            => new()
            {
                Created = new(2022, 2, 25, 9, 4, 25, 593),
                Description = "Android - solução definitiva correção dos atalhos de departamentos na home - 04 de mar",
                Key = "SEA-266",
                Link = "https://jira.viavarejo.com.br/browse/SEA-266",
                Resolved = new(2022, 3, 3, 10, 57, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea267()
            => new()
            {
                Created = new(2022, 2, 25, 9, 6, 15, 383),
                Description = "BFF - Colocar PRODUTOS INDISPONÍVEIS no final da lista sempre",
                Key = "SEA-267",
                Link = "https://jira.viavarejo.com.br/browse/SEA-267",
                Resolved = new(2022, 3, 2, 9, 3, 0),
                Status = "Done"
            };

        private static IssueInfoDto CreateDoneIssueSea273()
            => new()
            {
                Created = new(2022, 3, 4, 9, 39, 44, 827),
                Description = "BFF- ajuste de moveis atalhos da HOME",
                Key = "SEA-273",
                Link = "https://jira.viavarejo.com.br/browse/SEA-273",
                Resolved = new(2022, 3, 4, 4, 13, 0),
                Status = "Done"
            };
    }
}
