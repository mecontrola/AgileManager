using System;

namespace Stefanini.GitHub.Core.Data.Dto
{
    public class IssueDto
    {
        public string Stack { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public DateTime CreateAt { get; set; }
        public string Url { get; set; }
    }
}