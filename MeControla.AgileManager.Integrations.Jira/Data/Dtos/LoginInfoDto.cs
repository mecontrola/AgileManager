using System;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class LoginInfoDto
    {
        public int FailedLoginCount { get; set; }
        public int LoginCount { get; set; }
        public DateTime LastFailedLoginTime { get; set; }
        public DateTime PreviousLoginTime { get; set; }
    }
}