using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Dtos.Jira
{
    public class IssueFieldsDto
    {
        public string Summary { get; set; }
        public UserDto Creator { get; set; }
        public UserDto Reporter { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Resolutiondate { get; set; }
        public StatusDto Status { get; set; }
        public IssueTypeDto Issuetype { get; set; }
        public IList<string> Labels { get; set; }
        public IList<IssuelinkDto> Issuelinks { get; set; }

        public object Customfield_10028 { get; set; }
        public object Customfield_10029 { get; set; }
        public object Customfield_10030 { get; set; }
        public object Customfield_10031 { get; set; }
        public object Customfield_10032 { get; set; }
        public object Customfield_10033 { get; set; }
        public object Customfield_10034 { get; set; }
        public object Customfield_10035 { get; set; }
        public string Customfield_10036 { get; set; }
        public string Customfield_14503 { get; set; }
        public string Customfield_15703 { get; set; }
    }
}