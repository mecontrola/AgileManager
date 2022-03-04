using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class JiraProjectDtoMock
    {
        public static IList<JiraProjectDto> Create()
            => GetData().Select(x => CreateJiraProjectList(x.Key, x.Value))
                        .SelectMany(x => x)
                        .ToList();

        private static IList<JiraProjectDto> CreateJiraProjectList(string category, string[] projects)
            => projects.Select(project => CreateJiraProject(category, project))
                       .ToList();

        private static JiraProjectDto CreateJiraProject(string category, string project)
            => new()
            {
                Category = category,
                Name = project
            };

        private static IDictionary<string, string[]> GetData()
            => new Dictionary<string, string[]>
            {
                { DataMock.LIST_PROJECT_CATEGORIES[0], DataMock.LIST_PROJECT_CATEGORIES_APLICATIVOS },
                { DataMock.LIST_PROJECT_CATEGORIES[1], DataMock.LIST_PROJECT_CATEGORIES_DECISAO },
                { DataMock.LIST_PROJECT_CATEGORIES[2], DataMock.LIST_PROJECT_CATEGORIES_DESCOBERTA_USUARIO },
                { DataMock.LIST_PROJECT_CATEGORIES[3], DataMock.LIST_PROJECT_CATEGORIES_FIDELIZACAO },
            };
    }
}