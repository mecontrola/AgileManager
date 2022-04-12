using System;

namespace Stefanini.Core.Tests.Mocks
{
    public class DataMock
    {
        public const string VALUE_USERNAME = "username";
        public const string VALUE_PASSWORD = "password";
        public const string VALUE_DEFAULT_TEXT = "Simply String Test";
        public const string VALUE_DEFAULT_TEXT2 = "Simply String Test Anything";
        public const string JSON_CLASS_TEST = @"{""field_in_class1"":5,""field_in_class2"":9}";
        public const string TEXT_DATETIME = "2000-05-05";

        public const int VALUE_DEFAULT_5 = 5;
        public const int VALUE_DEFAULT_9 = 9;
        public const int WEEK_YEAR = 18;

        public static readonly DateTime DATETIME_QUARTER_2_2000 = new(2000, 5, 5);
    }
}