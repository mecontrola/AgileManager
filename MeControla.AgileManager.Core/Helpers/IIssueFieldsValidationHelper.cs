﻿using MeControla.AgileManager.Data.Dtos.Jira;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
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