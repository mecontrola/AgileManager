using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class DeliveryLastCycleDtoMock
    {
        public static DeliveryLastCycleDto Create()
            => new()
            {
                StartDate = DataMock.DATETIME_START_CYCLE,
                EndDate = DataMock.DATETIME_END_CYCLE,
                Throughtput = 20,
                Debits = 20,
                DebitsPercent = 1,
                Feature = 0,
                FeaturePercent = 0,
                SystemLeadTimeAverage = 6.5M,
                Issues = CreateLeadTimeIssueList(),
                Impediments = CreateLeadTimeImpedimentList(),
                Epics = CreateLeadTimeEpicList(),
            };

        private static IList<DeliveryLastCycleIssueDto> CreateLeadTimeIssueList()
            => new List<DeliveryLastCycleIssueDto>()
            {
                new DeliveryLastCycleIssueDto { Key = "SEA-219", Description = "IOS - implementar excluir histórico total e registro unitário", SystemLeadTime = 23 },
                new DeliveryLastCycleIssueDto { Key = "SEA-230", Description = "IOS- Implementar tela de histórico de busca", SystemLeadTime = 12 },
                new DeliveryLastCycleIssueDto { Key = "SEA-232", Description = "BFF - Mapear a nova opção de ordenação - Novidade ", SystemLeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-233", Description = "Android - Listar nova opção de ordenação - novidades", SystemLeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-234", Description = "BFF - Correção de frete grátis após modificação da linx", SystemLeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-235", Description = "Android - Ajuste no comportamento do frete grátis", SystemLeadTime = 4 },
                new DeliveryLastCycleIssueDto { Key = "SEA-236", Description = "nova label de CEP Implementar Android", SystemLeadTime = 10 },
                new DeliveryLastCycleIssueDto { Key = "SEA-237", Description = "Nova label de CEP Implementar IOS", SystemLeadTime = 10 },
                new DeliveryLastCycleIssueDto { Key = "SEA-245", Description = "Implementar Android solução para envio de Single ID SF", SystemLeadTime = 7 },
                new DeliveryLastCycleIssueDto { Key = "SEA-246", Description = "Implementar IOS solução para envio de Single ID SF", SystemLeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-248", Description = "iOS - Histórico de busca: Implementar animação", SystemLeadTime = 3 },
                new DeliveryLastCycleIssueDto { Key = "SEA-254", Description = "O app não está apresentando os filtros laterais ao acessar categoria \"Fogão a lenha\"", SystemLeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-255", Description = "IOS- Listar nova opção de ordenação - novidades", SystemLeadTime = 9 },
                new DeliveryLastCycleIssueDto { Key = "SEA-257", Description = " Alterar composições de frete grátis no Firebase ", SystemLeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-259", Description = "Bug da esposa do Edinho", SystemLeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-262", Description = "Android - Não salvando o CEP na primeira utilização", SystemLeadTime = 1 },
                new DeliveryLastCycleIssueDto { Key = "SEA-264", Description = "BFF- Correção emergencial departamentos na home", SystemLeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-266", Description = "Android - solução definitiva correção dos atalhos de departamentos na home - 04 de mar", SystemLeadTime = 4 },
                new DeliveryLastCycleIssueDto { Key = "SEA-267", Description = "BFF - Colocar PRODUTOS INDISPONÍVEIS no final da lista sempre", SystemLeadTime = 3 },
                new DeliveryLastCycleIssueDto { Key = "SEA-273", Description = "BFF- ajuste de moveis atalhos da HOME", SystemLeadTime = 0 },
            };

        private static IList<DeliveryLastCycleImpedimentDto> CreateLeadTimeImpedimentList()
            => new List<DeliveryLastCycleImpedimentDto>();

        private static IList<DeliveryLastCycleEpicDto> CreateLeadTimeEpicList()
            => new List<DeliveryLastCycleEpicDto>();
    }
}