using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Data.Dtos.Jira
{
    public class DocumentFormat
    {
        public string Type { get; set; }
        public int Version { get; set; }
        public IList<DocumentFormatContent> Content { get; set; } = new List<DocumentFormatContent>();
    }
}