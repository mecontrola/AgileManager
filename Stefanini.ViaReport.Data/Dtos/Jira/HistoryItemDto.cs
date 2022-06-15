namespace Stefanini.ViaReport.Data.Dtos.Jira
{
    public class HistoryItemDto
    {
        public string Field { get; set; }
        public string Fieldtype { get; set; }
        public string From { get; set; }
        public string FromString { get; set; }
        public string To { get; set; }
        public new string ToString { get; set; }
    }
}