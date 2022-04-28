using System;

namespace Stefanini.ViaReport.Core.Tests.Mocks
{
    public class DataMock
    {
        public static string TEXT_SEARCH_PROJECT { get; } = "Search";
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
        public static string TEXT_STATUS_REFINAMENTO_FUNCIONAL { get; } = "Refinamento Funcional";
        public static string TEXT_STATUS_REFINAMENTO_TECNICO { get; } = "Refinamento Técnico";
        public static string TEXT_STATUS_CANCELLED { get; } = "Cancelled";
        public static string TEXT_STATUS_REMOVED { get; } = "Removed";
        public static string TEXT_STATUS_PARA_DESENVOLVIMENTO { get; } = "Para Desenvolvimento";
        public static string TEXT_STATUS_EM_DESENVOLVIMENTO { get; } = "Em Desenvolvimento";
        public static string TEXT_STATUS_PARA_REVISAO { get; } = "Para Revisão";
        public static string TEXT_STATUS_EM_REVISAO { get; } = "Em Revisão";
        public static string TEXT_STATUS_PARA_TESTE { get; } = "Para Teste";
        public static string TEXT_STATUS_EM_TESTE { get; } = "Em Teste";
        public static string TEXT_STATUS_PARA_HOMOLOGACAO { get; } = "Para Homologação";
        public static string TEXT_STATUS_EM_HOMOLOGACAO { get; } = "Em Homologação";
        public static string TEXT_EASYBI_ACCOUNT { get; } = "51";

        public static int VALUE_DEFAULT_5 { get; } = 5;
        public static int VALUE_DEFAULT_9 { get; } = 9;
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
        public static int INT_STATUS_EM_TESTE { get; } = 12908;
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

        public static string JIRA_HOST { get; } = "https://jira.hostname.com";
        public static string ISSUE_KEY_1 { get; } = "TST-1";
        public static string ISSUE_KEY_2 { get; } = "TST-2";
        public static string ISSUE_DESCRIPTION_1 { get; } = "TST-1 issue description";
        public static string ISSUE_DESCRIPTION_2 { get; } = "TST-2 issue description";
        public static string ISSUE_LINK_1 { get; } = JIRA_HOST + "/browse/TST-1";
        public static string ISSUE_LINK_2 { get; } = JIRA_HOST + "/browse/TST-2";
        public static string ISSUE_SELF_1 { get; } = JIRA_HOST + "/rest/api/2/issue/1";
        public static string ISSUE_SELF_2 { get; } = JIRA_HOST + "/rest/api/2/issue/2";
        public static string ISSUE_STATUS_1 { get; } = "Backlog";
        public static string ISSUE_STATUS_2 { get; } = "Replenishment";

        public static string[] LIST_PROJECT_CATEGORIES { get; } = new[] { "Aplicativos", "Decisão", "Descoberta do Usuário", "Fidelização" };
        public static string[] LIST_PROJECT_CATEGORIES_APLICATIVOS { get; } = new[] { "Acquisition", "App Checkout", "App Experience", "Cart", "Choose", "Core Apps", "Search" };
        public static string[] LIST_PROJECT_CATEGORIES_DECISAO { get; } = new[] { "Add to Cart", "Clube de Prêmios", "Payment to Checkout", "Plataforma Decisão", "Shipping Information", "Televendas" };
        public static string[] LIST_PROJECT_CATEGORIES_DESCOBERTA_USUARIO { get; } = new[] { "Acessibilidade e SEO", "Busca", "CMS", "DPTO", "Home e Personalização", "Plataforma Descoberta", "Product Detail Page", "Via ADS" };
        public static string[] LIST_PROJECT_CATEGORIES_FIDELIZACAO { get; } = new[] { "Listas", "Loyalty", "Tagueamento", "VIP", "Web Experience" };

        public static string FILENAMA_CFD_CSV_IMPORT { get; } = @"Mocks\Imports\cfd_-_colunas_por_semana.csv";
    }
}