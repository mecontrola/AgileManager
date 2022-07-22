using Stefanini.ViaReport.Core.Builders.Jira;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Builders.Jira
{
    public class JqlBuilderMock
    {
        public static JqlBuilder CreateCriteriaProject()
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(DataMock.TEXT_SEARCH_PROJECT);
        public static JqlBuilder CreateCriteriaProjectOrderByKey()
            => CreateCriteriaProject().AddKeyOrderBy();
    }
}