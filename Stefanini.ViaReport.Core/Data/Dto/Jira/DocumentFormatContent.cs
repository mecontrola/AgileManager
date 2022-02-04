using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class DocumentFormatContent
    {
        public string Type { get; set; }
        public IList<DocumentFormatContentValue> Content { get; set; } = new List<DocumentFormatContentValue>();
    }
}