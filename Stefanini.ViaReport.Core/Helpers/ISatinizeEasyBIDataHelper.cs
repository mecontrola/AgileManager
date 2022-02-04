using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.EasyBI;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface ISatinizeEasyBIDataHelper
    {
        IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> Execute(ReportResultDto values);
        IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> Execute(SearchDto result, IDictionary<StatusCategories, List<string>> statuses);
    }
}