﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
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

        [JsonExtensionData]
        public IDictionary<string, dynamic> CustomFields { get; set; }

        public string Customfield_14503 { get; set; }
        public string Customfield_15703 { get; set; }
    }
}