using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IIssueFieldsValidationHelper
    {
        bool HasLabelIndicent(IList<string> labels);
        bool HasLabelQuarter(IList<string> labels);
        bool IsEpicIssueType(IssueDto issueDto);
        bool IsLabelQuarter(string label);
        string SatinizeLabelQuarter(string label);
    }
}