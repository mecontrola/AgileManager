namespace MeControla.AgileManager.Integrations.Jira.Abstrations
{
    internal interface ICache
    {
        bool ContainsKey(string key);
        bool IsExpired(string key);
        T Read<T>(string key);
        string Read(string key);
        void Write<T>(string key, T value);
        void Write(string key, string value);
        void Clear();
    }
}