using System;

namespace Stefanini.Core.Tests.Mocks
{
    public class DataMock
    {
        public static string VALUE_DEFAULT_TEXT { get; } = "Simply String Test";
        public static string VALUE_DEFAULT_TEXT2 { get; } = "Simply String Test Anything";
        public static string JSON_CLASS_TEST { get; } = @"{""field_in_class1"":5,""field_in_class2"":9}";
        public static string TEXT_DATETIME { get; } = "2000-05-05";
        public static string TEXT_DECIMAL { get; set; } = "100.0";

        public static int VALUE_DEFAULT_5 { get; } = 5;
        public static int VALUE_DEFAULT_9 { get; } = 9;
        public static int WEEK_YEAR { get; } = 18;

        public static DateTime DATETIME_QUARTER_2_2000 { get; } = new(2000, 5, 5);

        public static decimal DECIMAL_DEFAULT { get; } = 100;
    }
}