using System;
using System.Collections.Generic;

namespace Stefanini.GitHub.Core.Data.Dto.GitHub
{
    public class SearchIssueItemDto
    {
        public string Url { get; set; }
        public string RepositoryUrl { get; set; }
        public string LabelsUrl { get; set; }
        public string CommentsUrl { get; set; }
        public string EventsUrl { get; set; }
        public string HtmlUrl { get; set; }
        public long Id { get; set; }
        public string NodeId { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public UserDto User { get; set; }
        public IList<LabelDto> Labels { get; set; }
        public string State { get; set; }
        public bool Locked { get; set; }
        public UserDto Assignee { get; set; }
        public IList<UserDto> Assignees { get; set; }
        ////"milestone": null,
        public int Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string AuthorAssociation { get; set; }
        ////"active_lock_reason": null,
        public bool Draft { get; set; }
        public PullRequestDto PullRequest { get; set; }
        public string Body { get; set; }
        public ReactionsDto Reactions { get; set; }
        public string TimelineUrl { get; set; }
        ////"performed_via_github_app": null,
        public decimal Score { get; set; }
    }
}