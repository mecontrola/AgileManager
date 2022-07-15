using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class IssueFieldsValidationHelper : IIssueFieldsValidationHelper
    {
        private const string REGEX_LABEL_QUARTER_SEPARATOR = "separator";
        private const string REGEX_LABEL_QUARTER = @"^[Qq][0-9](?<separator>\s|-)?[0-9]{4}$";

        private static readonly string[] LABELS_INCIDENTS = new string[] { "incidente", "Incidente", "incidentes", "Incidentes" };

        public bool HasLabelIndicent(IList<string> labels)
            => labels.Any(label => LABELS_INCIDENTS.Any(itm => itm.Equals(label)));

        public bool IsEpicIssueType(IssueDto issueDto)
            => long.Parse(issueDto.Fields.Issuetype.Id) == (long)IssueTypes.Epic;

        public bool HasLabelQuarter(IList<string> labels)
            => labels.Any(label => IsLabelQuarter(label));

        public bool IsLabelQuarter(string label)
            => Regex.IsMatch(label, REGEX_LABEL_QUARTER, RegexOptions.IgnoreCase);

        public string SatinizeLabelQuarter(string label)
        {
            var match = Regex.Match(label, REGEX_LABEL_QUARTER);

            if (!match.Success)
                return string.Empty;

            var separator = match.Groups[REGEX_LABEL_QUARTER_SEPARATOR].Value;
            if (!string.IsNullOrEmpty(separator))
                label = label.Replace(separator, string.Empty);

            return label.ToUpper();
        }
    }
}