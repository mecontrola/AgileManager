using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto
{
    public class IssueInfoListDto
    {
        public long Total { get; set; }
        public IList<IssueInfoDto> Data { get; set; }
    }
}