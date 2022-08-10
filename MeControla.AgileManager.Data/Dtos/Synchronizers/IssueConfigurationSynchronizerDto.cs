namespace MeControla.AgileManager.Data.Dtos.Synchronizers
{
    public class IssueConfigurationSynchronizerDto : ConfigurationSynchronizerDto
    {
        public long[] Projects { get; set; }
        public bool SyncAllData { get; set; }
    }
}