using System;

namespace Stefanini.ViaReport.Core.Tests.Mocks
{
    public class DataMock
    {
        public const string VALUE_DEFAULT_TEXT = "Simply String Test";
        public const string VALUE_DEFAULT_TEXT2 = "Simply String Test Anything";
        public const string JSON_CLASS_TEST = @"{""field_in_class1"":5,""field_in_class2"":9}";
        public const string JSON_CLASS_TEST_DATE = @"{""FieldInClass1"":5,""FieldInClass2"":9,""FieldDateTime"":""05/05/2000 00:00:00""}";

        public const int VALUE_DEFAULT_5 = 5;
        public const int VALUE_DEFAULT_9 = 9;
        public const int WEEK_YEAR = 18;

        public static readonly DateTime DATETIME_DEFAULT = new(2000, 5, 5);

        public const string ISSUE_KEY_1 = "TST-1";
        public const string ISSUE_KEY_2 = "TST-2";
        public const string ISSUE_DESCRIPTION_1 = "TST-1 issue description";
        public const string ISSUE_DESCRIPTION_2 = "TST-2 issue description";
        public const string ISSUE_LINK_1 = "https://jira.hostname.com/browse/TST-1";
        public const string ISSUE_LINK_2 = "https://jira.hostname.com/browse/TST-2";
        public const string ISSUE_SELF_1 = "https://jira.hostname.com/rest/api/2/issue/1";
        public const string ISSUE_SELF_2 = "https://jira.hostname.com/rest/api/2/issue/2";
        public const string ISSUE_STATUS_1 = "Backlog";
        public const string ISSUE_STATUS_2 = "Replanishment";
    }
}