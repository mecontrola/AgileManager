using System;

namespace Stefanini.ViaReport.Core.Tests.Mocks
{
    public class DataMock
    {
        public static bool BOOL_TRUE { get; } = true;
        public static bool BOOL_FALSE { get; } = true;

        public static string TEXT_COREAPPS_PROJECT_KEY { get; } = "Core Apps";
        public static string TEXT_CHOOSE_PROJECT_KEY { get; } = "Choose";
        public static string TEXT_LOYALTY_PROJECT { get; } = "Loyalty";
        public static string TEXT_SEARCH_PROJECT { get; } = "Search";
        public static string TEXT_APLICATIVOS_PROJECT_CATEGORY { get; } = "Aplicativos";
        public static string TEXT_DECISAO_PROJECT_CATEGORY { get; } = "Decisão";
        public static string TEXT_DESCOBERTA_PROJECT_CATEGORY { get; } = "Descoberta";
        public static string TEXT_FIDELIZACAO_PROJECT_CATEGORY { get; } = "Fidelização";
        public static string TEXT_KEY_ISSUE_SEA242 { get; } = "SEA-242";
        public static string VALUE_USERNAME { get; } = "username";
        public static string VALUE_PASSWORD { get; } = "password";
        public static string VALUE_DEFAULT_TEXT { get; } = "Simply String Test";
        public static string VALUE_DEFAULT_TEXT2 { get; } = "Simply String Test Anything";
        public static string JSON_CLASS_TEST { get; } = @"{""field_in_class1"":5,""field_in_class2"":9}";
        public static string JSON_CLASS_TEST_DATE { get; } = @"{""FieldInClass1"":5,""FieldInClass2"":9,""FieldDateTime"":""05/05/2000 00:00:00""}";
        public static string TEXT_DATETIME_WITH_WEEK { get; } = "W18, May 05 2000";
        public static string TEXT_QUARTER_1_2000 { get; } = "Q12000";
        public static string TEXT_QUARTER_2_2000 { get; } = "Q22000";
        public static string TEXT_QUARTER_3_2000 { get; } = "Q32000";
        public static string TEXT_QUARTER_4_2000 { get; } = "Q42000";
        public static string TEXT_STATUS_CATEGORY_TO_DO { get; } = "To Do";
        public static string TEXT_STATUS_CATEGORY_IN_PROGRESS { get; } = "In Progress";
        public static string TEXT_STATUS_CATEGORY_DONE { get; } = "Done";
        public static string TEXT_STATUS_CATEGORY_NO_CATEGORY { get; } = "No Category";
        public static string TEXT_STATUS_REFINAMENTO_FUNCIONAL { get; } = "Refinamento Funcional";
        public static string TEXT_STATUS_REFINAMENTO_TECNICO { get; } = "Refinamento Técnico";
        public static string TEXT_STATUS_CANCELLED { get; } = "Cancelled";
        public static string TEXT_STATUS_REMOVED { get; } = "Removed";
        public static string TEXT_STATUS_PARA_DESENVOLVIMENTO { get; } = "Para Desenvolvimento";
        public static string TEXT_STATUS_EM_DESENVOLVIMENTO { get; } = "Em Desenvolvimento";
        public static string TEXT_STATUS_PARA_REVISAO { get; } = "Para Revisão";
        public static string TEXT_STATUS_EM_REVISAO { get; } = "Em Revisão";
        public static string TEXT_STATUS_PARA_TESTE { get; } = "Para Teste";
        public static string TEXT_STATUS_TO_TEST { get; } = "To Test";
        public static string TEXT_STATUS_EM_TESTE { get; } = "Em Teste";
        public static string TEXT_STATUS_IN_TEST { get; } = "In Test";
        public static string TEXT_STATUS_PARA_HOMOLOGACAO { get; } = "Para Homologação";
        public static string TEXT_STATUS_EM_HOMOLOGACAO { get; } = "Em Homologação";
        public static string TEXT_EASYBI_ACCOUNT { get; } = "51";

        public static int INT_ID_1 { get; } = 1;
        public static int INT_ID_2 { get; } = 2;
        public static int INT_ID_3 { get; } = 3;
        public static int INT_ID_4 { get; } = 4;
        public static int INT_ID_5 { get; } = 5;
        public static int INT_ID_6 { get; } = 6;
        public static int INT_ID_7 { get; } = 7;
        public static int INT_COREAPPS_PROJECT_KEY { get; } = 16313;
        public static int INT_CHOOSE_PROJECT_KEY { get; } = 20209;
        public static int INT_LOYALTY_PROJECT_KEY { get; } = 21021;
        public static int INT_SEARCH_PROJECT_KEY { get; } = 21018;
        public static int INT_APLICATIVOS_PROJECT_CATEGORY_KEY { get; } = 12904;
        public static int INT_DECISAO_PROJECT_CATEGORY_KEY { get; } = 11404;
        public static int INT_DESCOBERTA_PROJECT_CATEGORY_KEY { get; } = 11104;
        public static int INT_FIDELIZACAO_PROJECT_CATEGORY_KEY { get; } = 12905;
        public static int VALUE_DEFAULT_5 { get; } = 5;
        public static int VALUE_DEFAULT_9 { get; } = 9;
        public static int VALUE_DEFAULT_50 { get; } = 50;
        public static int INT_STATUS_REFINAMENTO_FUNCIONAL { get; } = 16110;
        public static int INT_STATUS_REFINAMENTO_TECNICO { get; } = 13421;
        public static int INT_STATUS_DONE { get; } = 10214;
        public static int INT_STATUS_CANCELLED { get; } = 10717;
        public static int INT_STATUS_REMOVED { get; } = 11709;
        public static int INT_STATUS_PARA_DESENVOLVIMENTO { get; } = 16112;
        public static int INT_STATUS_EM_DESENVOLVIMENTO { get; } = 11601;
        public static int INT_STATUS_PARA_REVISAO { get; } = 16113;
        public static int INT_STATUS_EM_REVISAO { get; } = 12527;
        public static int INT_STATUS_PARA_TESTE { get; } = 16114;
        public static int INT_STATUS_TO_TEST { get; } = 14603;
        public static int INT_STATUS_EM_TESTE { get; } = 12908;
        public static int INT_STATUS_IN_TEST { get; } = 11801;
        public static int INT_STATUS_PARA_HOMOLOGACAO { get; } = 16115;
        public static int INT_STATUS_EM_HOMOLOGACAO { get; } = 12100;
        public static int INT_STATUS_BACKLOG { get; } = 10514;
        public static int INT_STATUS_REPLENISHMENT { get; } = 13213;
        public static int INT_CACHE_MINUTES { get; } = 10;

        public static DateTime DATETIME_QUARTER_1_2000 { get; } = new(2000, 2, 2);
        public static DateTime DATETIME_QUARTER_2_2000 { get; } = new(2000, 5, 5);
        public static DateTime DATETIME_QUARTER_3_2000 { get; } = new(2000, 8, 8);
        public static DateTime DATETIME_QUARTER_4_2000 { get; } = new(2000, 11, 11);
        public static DateTime DATETIME_CHANGELOG_STATUS { get; } = new(2022, 1, 17);
        public static DateTime DATETIME_START_CYCLE { get; } = new(2022, 2, 21);
        public static DateTime DATETIME_END_CYCLE { get; } = new(2022, 3, 6);
        public static DateTime DATETIME_FIRST_DAY_YEAR { get; } = new(2000, 1, 1);
        public static DateTime DATETIME_LAST_DAY_YEAR { get; } = new(2000, 12, 31);
        public static DateTime DATETIME_FIRST_HISTORY_FINDED { get; } = DateTime.Parse("2021-08-25 11:18:57.876");
        public static DateTime DATETIME_LAST_CYCLE_INIT { get; } = new(2021, 1, 1);
        public static DateTime DATETIME_LAST_CYCLE_END { get; } = new(2021, 12, 31);

        public static string JIRA_HOST { get; } = "https://jira.hostname.com";
        public static string ISSUE_KEY_1 { get; } = "TST-1";
        public static string ISSUE_KEY_2 { get; } = "TST-2";
        public static string ISSUE_KEY_3 { get; } = "TST-3";
        public static string ISSUE_SUMMARY_1 { get; } = "TST-1 issue description";
        public static string ISSUE_SUMMARY_2 { get; } = "TST-2 issue description";
        public static string ISSUE_SUMMARY_3 { get; } = "TST-3 issue description";
        public static string ISSUE_LINK_1 { get; } = JIRA_HOST + "/browse/TST-1";
        public static string ISSUE_LINK_2 { get; } = JIRA_HOST + "/browse/TST-2";
        public static string ISSUE_LINK_3 { get; } = JIRA_HOST + "/browse/TST-3";
        public static string ISSUE_SELF_1 { get; } = JIRA_HOST + "/rest/api/2/issue/1";
        public static string ISSUE_SELF_2 { get; } = JIRA_HOST + "/rest/api/2/issue/2";
        public static string ISSUE_STATUS_1 { get; } = "Backlog";
        public static string ISSUE_STATUS_2 { get; } = "Replenishment";
        public static string[] ISSUE_LABEL_2_INCIDENT { get; } = new string[] { "Incidente" };

        public static string[] LIST_PROJECT_CATEGORIES_APLICATIVOS { get; } = new[] { "Acquisition", "App Checkout", "App Experience", "Cart", "Choose", "Core Apps", "Search" };

        public static string FILENAMA_CFD_CSV_IMPORT { get; } = @"Mocks\Imports\cfd_-_colunas_por_semana.csv";

        public static long JIRA_SEARCH_START_AT_DEFAULT { get; } = 0;
        public static long JIRA_SEARCH_START_AT_256 { get; } = 256;
        public static long JIRA_SEARCH_MAX_RESULTS_DEFAULT { get; } = 256;
        public static long JIRA_SEARCH_MAX_RESULTS_512 { get; } = 512;
        public static string[] JIRA_SEARCH_FIELDS_DEFAULT { get; } = Array.Empty<string>();
        public static string[] JIRA_SEARCH_FIELDS_STATUS_AND_SUMMARY { get; } = new string[] { "Status", "Summary" };

        public static long[] PROJECTS_EMPTY { get; } = Array.Empty<long>();
        public static long[] PROJECTS { get; } = new long[] { INT_SEARCH_PROJECT_KEY, INT_LOYALTY_PROJECT_KEY };

        public static long ID_NOT_FOUND { get; } = 0;
        public static long ID_PROJECT { get; } = 1;
        public static long ID_ISSUE { get; } = 7623;
        public static long KEY_NOT_FOUND { get; } = 0;
        public static long KEY_ISSUE_TYPE { get; } = 1;
        public static long KEY_PROJECT_CATEGORY { get; } = 12904;
        public static long KEY_PROJECT { get; } = 21021;
        public static long KEY_STATUS_CATEGORY { get; } = 1;
        public static long KEY_STATUS { get; } = 1;
        public static string NAME_ISSUE_TYPE { get; } = "Bug";
        public static string NAME_PROJECT_CATEGORY { get; } = "Aplicativos";
        public static string NAME_STATUS_CATEGORY { get; } = "No Category";
        public static DateTime UPDATED_ISSUE { get; } = DateTime.Parse("2021-08-26 16:28:28.367");

        public static string USER_SELF { get; } = "https://jira.viavarejo.com.br/rest/api/2/user?username=1234567890";
        public static string USER_EMAILADDRESS { get; } = "desconhecido@email.com";
        public static string USER_DISPLAYNAME { get; } = "DESCONHECIDO";
        public static string USER_TIMEZONE { get; } = "America/Bahia";
        public static string HISTORYITEM_ID { get; } = "6486311";
        public static string HISTORYITEM_FIELD_ASSIGNEE { get; } = "assignee";
        public static string HISTORYITEM_FIELD_FLAGGED { get; } = "Flagged";
        public static string HISTORYITEM_FIELD_STATUS { get; } = "status";
        public static string HISTORYITEM_FIELDTYPE_CUSTOM { get; } = "custom";
        public static string HISTORYITEM_FIELDTYPE_JIRA { get; } = "jira";

        public static string ISSUETYPE_NAME_TASK { get; } = "Task";
        public static string ISSUETYPE_NAME_SUBTASk { get; } = "Sub-task";
        public static string ISSUETYPE_NAME_STORY { get; } = "Story";
        public static string ISSUETYPE_NAME_BUG { get; } = "Bug";
        public static string ISSUETYPE_NAME_EPIC { get; } = "Epic";
        public static string ISSUETYPE_NAME_TECHNICALDEBT { get; } = "Technical debt";
        public static string ISSUETYPE_NAME_TECHNICALIMPROVEMENT { get; } = "Technical Improvement";
    }
}