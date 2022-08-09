using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos
{
    internal class ProjectCategoryDtoMock
    {
        public static ProjectCategoryDto CreateAplicativos()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Name = DataMock.TEXT_APLICATIVOS_PROJECT_CATEGORY
            };

        public static ProjectCategoryDto CreateDecisao()
            => new()
            {
                Id = DataMock.INT_ID_2,
                Name = DataMock.TEXT_DECISAO_PROJECT_CATEGORY
            };

        public static ProjectCategoryDto CreateDescoberta()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Name = DataMock.TEXT_DESCOBERTA_PROJECT_CATEGORY
            };

        public static ProjectCategoryDto CreateFidelizacao()
            => new()
            {
                Id = DataMock.INT_ID_4,
                Name = DataMock.TEXT_FIDELIZACAO_PROJECT_CATEGORY
            };

        public static IList<ProjectCategoryDto> CreateList()
            => new List<ProjectCategoryDto>
            {
                CreateAplicativos(),
                CreateDecisao(),
                CreateDescoberta(),
                CreateFidelizacao(),
            };
    }
}