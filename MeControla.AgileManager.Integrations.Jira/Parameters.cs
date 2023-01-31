using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira
{
    internal sealed class Parameters
    {
        private readonly Dictionary<string, string> parameters = new();

        public Parameters Add(string key, int value)
            => Add(key, value.ToString());

        public Parameters Add(string key, long value)
            => Add(key, value.ToString());

        public Parameters Add(string key, string value)
        {
            parameters[key] = value;
            return this;
        }

        public Parameters Remove(string key)
        {
            parameters.Remove(key);
            return this;
        }

        public bool ContainsKey(string key)
            => parameters.ContainsKey(key);

        public void Clear()
            => parameters.Clear();

        public Dictionary<string, string>.Enumerator GetEnumerator()
            => parameters.GetEnumerator();

        public string this[string key]
        {
            get
            {
                if (!parameters.ContainsKey(key))
                    throw new KeyNotFoundException();

                return parameters[key];
            }
            set
            {
                Add(key, value);
            }
        }
    }
}