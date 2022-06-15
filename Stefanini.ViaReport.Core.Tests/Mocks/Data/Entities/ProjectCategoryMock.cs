using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class ProjectCategoryMock
    {
        public static ProjectCategory CreateAplicativos()
        {
            var entity = CreateAplicativosFromJira();
            entity.Id = DataMock.INT_ID_1;
            return entity;
        }

        public static ProjectCategory CreateAplicativosFromJira()
            => new()
            {
                Key = DataMock.INT_APLICATIVOS_PROJECT_CATEGORY_KEY,
                Name = DataMock.TEXT_APLICATIVOS_PROJECT_CATEGORY
            };

        public static ProjectCategory CreateDecisao()
        {
            var entity = CreateDecisaoFromJira();
            entity.Id = DataMock.INT_ID_2;
            return entity;
        }

        public static ProjectCategory CreateDecisaoFromJira()
            => new()
            {
                Key = DataMock.INT_DECISAO_PROJECT_CATEGORY_KEY,
                Name = DataMock.TEXT_DECISAO_PROJECT_CATEGORY
            };

        public static ProjectCategory CreateDescoberta()
        {
            var entity = CreateDescobertaFromJira();
            entity.Id = DataMock.INT_ID_3;
            return entity;
        }

        public static ProjectCategory CreateDescobertaFromJira()
            => new()
            {
                Key = DataMock.INT_DESCOBERTA_PROJECT_CATEGORY_KEY,
                Name = DataMock.TEXT_DESCOBERTA_PROJECT_CATEGORY
            };

        public static ProjectCategory CreateFidelizacao()
        {
            var entity = CreateFidelizacaoFromJira();
            entity.Id = DataMock.INT_ID_4;
            return entity;
        }

        public static ProjectCategory CreateFidelizacaoFromJira()
            => new()
            {
                Key = DataMock.INT_FIDELIZACAO_PROJECT_CATEGORY_KEY,
                Name = DataMock.TEXT_FIDELIZACAO_PROJECT_CATEGORY
            };

        public static IList<ProjectCategory> CreateList()
            => new List<ProjectCategory>
            {
                CreateAplicativos(),
                CreateDecisao(),
                CreateDescoberta(),
                CreateFidelizacao(),
            };

        public static IList<ProjectCategory> CreateListFromJira()
            => new List<ProjectCategory>
            {
                CreateAplicativosFromJira(),
                CreateDecisaoFromJira(),
                CreateDescobertaFromJira(),
                CreateFidelizacaoFromJira(),
            };
    }
}