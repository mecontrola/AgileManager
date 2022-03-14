using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class DeliveryLastCycleDtoMock
    {
        public static DeliveryLastCycleDto Create()
            => new()
            {
                StartDate =  DataMock.DATETIME_START_CYCLE,
                EndDate = DataMock.DATETIME_END_CYCLE,
                Throughtput = 20,
                LeadTimeAverage = 6,
                Issues = CreateLeadTimeList()
            };

        private static IList<DeliveryLastCycleIssueDto> CreateLeadTimeList()
            => new List<DeliveryLastCycleIssueDto>()
            {
                new DeliveryLastCycleIssueDto { Key = "SEA-219", Description = "IOS - implementar excluir histórico total e registro unitário", LeadTime = 23 },
                new DeliveryLastCycleIssueDto { Key = "SEA-230", Description = "IOS- Implementar tela de histórico de busca", LeadTime = 12 },
                new DeliveryLastCycleIssueDto { Key = "SEA-232", Description = "BFF - Mapear a nova opção de ordenação - Novidade ", LeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-233", Description = "Android - Listar nova opção de ordenação - novidades", LeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-234", Description = "BFF - Correção de frete grátis após modificação da linx", LeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-235", Description = "Android - Ajuste no comportamento do frete grátis", LeadTime = 4 },
                new DeliveryLastCycleIssueDto { Key = "SEA-236", Description = "nova label de CEP Implementar Android", LeadTime = 10 },
                new DeliveryLastCycleIssueDto { Key = "SEA-237", Description = "Nova label de CEP Implementar IOS", LeadTime = 10 },
                new DeliveryLastCycleIssueDto { Key = "SEA-245", Description = "Implementar Android solução para envio de Single ID SF", LeadTime = 7 },
                new DeliveryLastCycleIssueDto { Key = "SEA-246", Description = "Implementar IOS solução para envio de Single ID SF", LeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-248", Description = "iOS - Histórico de busca: Implementar animação", LeadTime = 3 },
                new DeliveryLastCycleIssueDto { Key = "SEA-254", Description = "O app não está apresentando os filtros laterais ao acessar categoria \"Fogão a lenha\"", LeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-255", Description = "IOS- Listar nova opção de ordenação - novidades", LeadTime = 9 },
                new DeliveryLastCycleIssueDto { Key = "SEA-257", Description = " Alterar composições de frete grátis no Firebase ", LeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-259", Description = "Bug da esposa do Edinho", LeadTime = 6 },
                new DeliveryLastCycleIssueDto { Key = "SEA-262", Description = "Android - Não salvando o CEP na primeira utilização", LeadTime = 1 },
                new DeliveryLastCycleIssueDto { Key = "SEA-264", Description = "BFF- Correção emergencial departamentos na home", LeadTime = 5 },
                new DeliveryLastCycleIssueDto { Key = "SEA-266", Description = "Android - solução definitiva correção dos atalhos de departamentos na home - 04 de mar", LeadTime = 4 },
                new DeliveryLastCycleIssueDto { Key = "SEA-267", Description = "BFF - Colocar PRODUTOS INDISPONÍVEIS no final da lista sempre", LeadTime = 3 },
                new DeliveryLastCycleIssueDto { Key = "SEA-273", Description = "BFF- ajuste de moveis atalhos da HOME", LeadTime = 0 },
            };
    }
}