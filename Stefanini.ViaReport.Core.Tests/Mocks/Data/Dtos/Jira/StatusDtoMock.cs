using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class StatusDtoMock
    {
        private const string SEARCH_RESULT_FILE_NAME = "status.get.all.json";

        public static StatusDto CreateBacklog()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_BACKLOG}",
                Name = DataMock.ISSUE_STATUS_1,
                StatusCategory = StatusCategoryDtoMock.CreateToDo(),
            };

        public static StatusDto CreateRefinamentoFuncional()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_REFINAMENTO_FUNCIONAL}",
                Name = DataMock.TEXT_STATUS_REFINAMENTO_FUNCIONAL,
                StatusCategory = StatusCategoryDtoMock.CreateToDo(),
            };

        public static StatusDto CreateRefinamentoTecnico()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_REFINAMENTO_TECNICO}",
                Name = DataMock.TEXT_STATUS_REFINAMENTO_TECNICO,
                StatusCategory = StatusCategoryDtoMock.CreateToDo(),
            };

        public static StatusDto CreateReplanishment()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_REPLENISHMENT}",
                Name = DataMock.ISSUE_STATUS_2,
                StatusCategory = StatusCategoryDtoMock.CreateToDo(),
            };

        public static StatusDto CreateParaDesenvolvimento()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_PARA_DESENVOLVIMENTO}",
                Name = DataMock.TEXT_STATUS_PARA_DESENVOLVIMENTO,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateEmDesenvolvimento()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_EM_DESENVOLVIMENTO}",
                Name = DataMock.TEXT_STATUS_EM_DESENVOLVIMENTO,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateParaRevisao()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_PARA_REVISAO}",
                Name = DataMock.TEXT_STATUS_PARA_REVISAO,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateEmRevisao()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_EM_REVISAO}",
                Name = DataMock.TEXT_STATUS_EM_REVISAO,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateParaTeste()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_PARA_TESTE}",
                Name = DataMock.TEXT_STATUS_PARA_TESTE,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateEmTeste()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_EM_TESTE}",
                Name = DataMock.TEXT_STATUS_EM_TESTE,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateParaHomologacao()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_PARA_HOMOLOGACAO}",
                Name = DataMock.TEXT_STATUS_PARA_HOMOLOGACAO,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateEmHomologacao()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_EM_HOMOLOGACAO}",
                Name = DataMock.TEXT_STATUS_EM_HOMOLOGACAO,
                StatusCategory = StatusCategoryDtoMock.CreateInProgress(),
            };

        public static StatusDto CreateDone()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_DONE}",
                Name = DataMock.ISSUE_STATUS_2,
                StatusCategory = StatusCategoryDtoMock.CreateDone(),
            };

        public static StatusDto CreateRemoved()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_REMOVED}",
                Name = DataMock.TEXT_STATUS_REMOVED,
                StatusCategory = StatusCategoryDtoMock.CreateDone(),
            };

        public static StatusDto CreateCancelled()
            => new()
            {
                Id = $"{DataMock.INT_STATUS_CANCELLED}",
                Name = DataMock.TEXT_STATUS_CANCELLED,
                StatusCategory = StatusCategoryDtoMock.CreateDone(),
            };

        public static StatusDto[] CreateListToDo()
            => new[]
            {
                CreateBacklog(),
                CreateRefinamentoFuncional(),
                CreateRefinamentoTecnico(),
                CreateReplanishment()
            };

        public static StatusDto[] CreateListInProgress()
            => new[]
            {
                CreateParaDesenvolvimento(),
                CreateEmDesenvolvimento(),
                CreateParaRevisao(),
                CreateEmRevisao(),
                CreateParaTeste(),
                CreateEmTeste(),
                CreateParaHomologacao(),
                CreateEmHomologacao(),
            };

        public static StatusDto[] CreateListDone()
            => new[]
            {
                CreateDone(),
                CreateRemoved(),
                CreateCancelled()
            };

        public static StatusDto[] CreateListAll()
            => CreateListToDo().Concat(CreateListInProgress())
                               .Concat(CreateListDone())
                               .ToArray();

        public static IDictionary<string, string> CreateDictionaryInProgress()
            => CreateListInProgress().ToDictionary(x => x.Id,
                                                   x => x.Name);

        public static IDictionary<string, string> CreateDictionaryDone()
            => CreateListDone().ToDictionary(x => x.Id,
                                             x => x.Name);

        public static StatusDto[] CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<StatusDto[]>(SEARCH_RESULT_FILE_NAME);
    }
}