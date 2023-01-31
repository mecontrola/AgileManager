using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class DocumentFormat
    {
        public string Type { get; set; }
        public int Version { get; set; }
        public IList<DocumentFormatContent> Content { get; set; } = new List<DocumentFormatContent>();
    }
}