using System.Text.RegularExpressions;

namespace System.Text.Json
{
    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        private const string REGEX_SNAKE_CASE = @"([a-z0-9])([A-Z])";

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public override string ConvertName(string name)
            => Regex.Replace(name, REGEX_SNAKE_CASE, "$1_$2", RegexOptions.Compiled, TimeSpan.FromSeconds(0.2))
                    .ToLower();
    }
}