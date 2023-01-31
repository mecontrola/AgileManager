using MeControla.Core.Data.Dtos;
using System;

namespace MeControla.AgileManager.Data.Dtos
{
    public class IssueDeployDto : IDto
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Summary { get; set; }
        public string Environment { get; set; }
        public string Services { get; set; }
        public DateTime FinishedIn { get; set; }
        public DateTime? DeployedIn { get; set; }
        public Guid IssueId { get; set; }
    }
}