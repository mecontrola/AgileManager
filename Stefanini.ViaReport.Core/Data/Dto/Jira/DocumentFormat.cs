using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class DocumentFormat
    {
        public string Type { get; set; }
        public int Version { get; set; }
        public IList<DocumentFormatContent> Content { get; set; } = new List<DocumentFormatContent>();
    }
}