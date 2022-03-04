using System;

namespace Stefanini.ViaReport.Core.Tests.Mocks
{
    public class DataMock
    {
        public const string TEXT_SEARCH_PROJECT = "Search";
        public const string TEXT_KEY_ISSUE_SEA242 = "SEA-242";
        public const string TEXT_STATUS_EM_DESENVOLVIMENTO = "Em Desenvolvimento";
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

        public const int VALUE_DEFAULT_5 = 5;
        public const int VALUE_DEFAULT_9 = 9;
        public const int WEEK_YEAR = 18;

        public static readonly DateTime DATETIME_QUARTER_1_2000 = new(2000, 2, 2);
        public static readonly DateTime DATETIME_QUARTER_2_2000 = new(2000, 5, 5);
        public static readonly DateTime DATETIME_QUARTER_3_2000 = new(2000, 8, 8);
        public static readonly DateTime DATETIME_QUARTER_4_2000 = new(2000, 11, 11);

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

        public static readonly string[] LIST_PROJECT_CATEGORIES = new[] { "Aplicativos", "Decisão", "Descoberta do Usuário", "Fidelização" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_APLICATIVOS = new[] { "Acquisition", "App Checkout", "App Experience", "Cart", "Choose", "Core Apps", "Search" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_DECISAO = new[] { "Add to Cart", "Clube de Prêmios", "Payment to Checkout", "Plataforma Decisão", "Shipping Information", "Televendas" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_DESCOBERTA_USUARIO = new[] { "Acessibilidade e SEO", "Busca", "CMS", "DPTO", "Home e Personalização", "Plataforma Descoberta", "Product Detail Page", "Via ADS" };
        public static readonly string[] LIST_PROJECT_CATEGORIES_FIDELIZACAO = new[] { "Listas", "Loyalty", "Tagueamento", "VIP", "Web Experience" };
    }
}