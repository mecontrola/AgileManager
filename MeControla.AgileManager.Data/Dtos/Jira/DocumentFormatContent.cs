using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Data.Dtos.Jira
{
    public class DocumentFormatContent
    {
        public string Type { get; set; }
        public IList<DocumentFormatContentValue> Content { get; set; } = new List<DocumentFormatContentValue>();
    }
}