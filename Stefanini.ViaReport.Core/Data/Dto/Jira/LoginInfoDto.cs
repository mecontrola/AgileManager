using System;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class LoginInfoDto
    {
        public int FailedLoginCount { get; set; }
        public int LoginCount { get; set; }
        public DateTime LastFailedLoginTime { get; set; }
        public DateTime PreviousLoginTime { get; set; }
    }
}