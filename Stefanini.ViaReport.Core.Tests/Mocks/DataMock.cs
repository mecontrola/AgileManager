using System;

namespace Stefanini.ViaReport.Core.Tests.Mocks
{
    public class DataMock
    {
        public const string TEXT_SEARCH_PROJECT = "Search";
        public const string TEXT_KEY_ISSUE_SEA242 = "SEA-242";
        public const string VALUE_USERNAME = "username";
        public const string VALUE_PASSWORD = "password";
        public const string VALUE_DEFAULT_TEXT = "Simply String Test";
        public const string VALUE_DEFAULT_TEXT2 = "Simply String Test Anything";
        public const string JSON_CLASS_TEST = @"{""field_in_class1"":5,""field_in_class2"":9}";
        public const string JSON_CLASS_TEST_DATE = @"{""FieldInClass1"":5,""FieldInClass2"":9,""FieldDateTime"":""05/05/2000 00:00:00""}";
        public const string TEXT_DATETIME_WITH_WEEK = "W18, May 05 2000";
        public const string TEXT_QUARTER_1_2000 = "Q12000";
        public const string TEXT_QUARTER_2_2000 = "Q22000";
        public const string TEXT_QUARTER_3_2000 = "Q32000";
        public const string TEXT_QUARTER_4_2000 = "Q42000";
        public const string TEXT_STATUS_CATEGORY_TO_DO = "To Do";
        public const string TEXT_STATUS_CATEGORY_IN_PROGRESS = "In Progress";
        public const string TEXT_STATUS_CATEGORY_DONE = "Done";
        public const string TEXT_STATUS_REFINAMENTO_FUNCIONAL = "Refinamento Funcional";
        public const string TEXT_STATUS_REFINAMENTO_TECNICO = "Refinamento Técnico";
        public const string TEXT_STATUS_DONE = "Done";
        public const string TEXT_STATUS_CANCELLED = "Cancelled";
        public const string TEXT_STATUS_REMOVED = "Removed";
        public const string TEXT_STATUS_PARA_DESENVOLVIMENTO = "Para Desenvolvimento";
        public const string TEXT_STATUS_EM_DESENVOLVIMENTO = "Em Desenvolvimento";
        public const string TEXT_STATUS_PARA_REVISAO = "Para Revisão";
        public const string TEXT_STATUS_EM_REVISAO = "Em Revisão";
        public const string TEXT_STATUS_PARA_TESTE = "Para Teste";
        public const string TEXT_STATUS_EM_TESTE = "Em Teste";
        public const string TEXT_STATUS_PARA_HOMOLOGACAO = "Para Homologação";
        public const string TEXT_STATUS_EM_HOMOLOGACAO = "Em Homologação";

        public const int VALUE_DEFAULT_5 = 5;
        public const int VALUE_DEFAULT_9 = 9;
        public const int WEEK_YEAR = 18;
        public const int INT_STATUS_REFINAMENTO_FUNCIONAL = 16110;
        public const int INT_STATUS_REFINAMENTO_TECNICO = 13421;
        public const int INT_STATUS_DONE = 10214;
        public const int INT_STATUS_CANCELLED = 10717;
        public const int INT_STATUS_REMOVED = 11709;
        public const int INT_STATUS_PARA_DESENVOLVIMENTO = 16112;
        public const int INT_STATUS_EM_DESENVOLVIMENTO = 11601;
        public const int INT_STATUS_PARA_REVISAO = 16113;
        public const int INT_STATUS_EM_REVISAO = 12527;
        public const int INT_STATUS_PARA_TESTE = 16114;
        public const int INT_STATUS_EM_TESTE = 12908;
        public const int INT_STATUS_PARA_HOMOLOGACAO = 16115;
        public const int INT_STATUS_EM_HOMOLOGACAO = 12100;
        public const int INT_STATUS_BACKLOG = 10514;
        public const int INT_STATUS_REPLENISHMENT = 13213;

        public static readonly DateTime DATETIME_QUARTER_1_2000 = new(2000, 2, 2);
        public static readonly DateTime DATETIME_QUARTER_2_2000 = new(2000, 5, 5);
        public static readonly DateTime DATETIME_QUARTER_3_2000 = new(2000, 8, 8);
        public static readonly DateTime DATETIME_QUARTER_4_2000 = new(2000, 11, 11);
        public static readonly DateTime DATETIME_CHANGELOG_STATUS = new(2022, 1, 17);
        public static readonly DateTime DATETIME_START_CYCLE = new(2022, 2, 21);
        public static readonly DateTime DATETIME_END_CYCLE = new(2022, 3, 6);

        public const string ISSUE_KEY_1 = "TST-1";
        public const string ISSUE_KEY_2 = "TST-2";
        public const string ISSUE_DESCRIPTION_1 = "TST-1 issue description";
        public const string ISSUE_DESCRIPTION_2 = "TST-2 issue description";
        public const string ISSUE_LINK_1 = "https://jira.hostname.com/browse/TST-1";
        public const string ISSUE_LINK_2 = "https://jira.hostname.com/browse/TST-2";
        public const string ISSUE_SELF_1 = "https://jira.hostname.com/rest/api/2/issue/1";
        public const string ISSUE_SELF_2 = "https://jira.hostname.com/rest/api/2/issue/2";
        public const string ISSUE_STATUS_1 = "Backlog";
        public const string ISSUE_STATUS_2 = "Replenishment";

        public static readonly string[] LIST_PROJECT_CATEGORIES = new[] { "Aplicativos", "Decisão", "Descoberta do Usuário", "Fidelização" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_APLICATIVOS = new[] { "Acquisition", "App Checkout", "App Experience", "Cart", "Choose", "Core Apps", "Search" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_DECISAO = new[] { "Add to Cart", "Clube de Prêmios", "Payment to Checkout", "Plataforma Decisão", "Shipping Information", "Televendas" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_DESCOBERTA_USUARIO = new[] { "Acessibilidade e SEO", "Busca", "CMS", "DPTO", "Home e Personalização", "Plataforma Descoberta", "Product Detail Page", "Via ADS" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_FIDELIZACAO = new[] { "Listas", "Loyalty", "Tagueamento", "VIP", "Web Experience" };
    }
}