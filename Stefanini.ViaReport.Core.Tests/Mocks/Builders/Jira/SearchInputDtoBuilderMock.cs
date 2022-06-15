using Stefanini.ViaReport.Core.Builders.Jira;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Builders.Jira
{
    public class SearchInputDtoBuilderMock
    {
        public static SearchInputDtoBuilder CreateJqlCriteriaProjectOrderByKey()
            => SearchInputDtoBuilder.GetInstance()
                                    .AddJql(JqlBuilderMock.CreateCriteriaProjectOrderByKey());

        public static SearchInputDtoBuilder CreateJqlCriteriaProjectOrderByKeyWithStartAt256()
            => SearchInputDtoBuilder.GetInstance()
                                    .AddJql(JqlBuilderMock.CreateCriteriaProjectOrderByKey())
                                    .AddStartAt(DataMock.JIRA_SEARCH_START_AT_256);

        public static SearchInputDtoBuilder CreateJqlCriteriaProjectOrderByKeyWithMaxResults512()
            => SearchInputDtoBuilder.GetInstance()
                                    .AddJql(JqlBuilderMock.CreateCriteriaProjectOrderByKey())
                                    .AddMaxResults(DataMock.JIRA_SEARCH_MAX_RESULTS_512);

        public static SearchInputDtoBuilder CreateJqlCriteriaProjectOrderByKeyWithFieldsStatusAndSummary()
            => SearchInputDtoBuilder.GetInstance()
                                    .AddJql(JqlBuilderMock.CreateCriteriaProjectOrderByKey())
                                    .AddFields(DataMock.JIRA_SEARCH_FIELDS_STATUS_AND_SUMMARY);
    }
}