using MeControla.AgileManager.Integrations.Jira.Data.Dtos.Inputs;
using System;

namespace MeControla.AgileManager.Integrations.Jira.Builders
{
    public sealed class SearchInputDtoBuilder
    {
        private const long DEFAULT_START_AT = 0;
        private const long DEFAULT_MAX_RESULTS = 256;

        private static readonly string[] DEFAULT_FIELDS = Array.Empty<string>();

        private readonly SearchInputDto obj;

        private SearchInputDtoBuilder()
            => obj = new()
            {
                StartAt = DEFAULT_START_AT,
                MaxResults = DEFAULT_MAX_RESULTS,
                Fields = DEFAULT_FIELDS
            };

        public SearchInputDtoBuilder AddJql(JqlBuilder jql)
            => Set(x => x.Jql = jql.ToBuild());

        public SearchInputDtoBuilder AddStartAt(long startAt)
            => Set(x => x.StartAt = startAt);

        public SearchInputDtoBuilder AddMaxResults(long maxResults)
            => Set(x => x.MaxResults = maxResults);

        public SearchInputDtoBuilder AddFields(params string[] fields)
            => Set(x => x.Fields = fields);

        private SearchInputDtoBuilder Set(Action<SearchInputDto> action)
        {
            action?.Invoke(obj);
            return this;
        }

        public SearchInputDto ToBuild()
            => obj;

        public static SearchInputDtoBuilder GetInstance()
            => new();
    }
}