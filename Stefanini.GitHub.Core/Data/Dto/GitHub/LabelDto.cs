namespace Stefanini.GitHub.Core.Data.Dto.GitHub
{
    public class LabelDto
    {
        public long Id { get; set; }
        public string NodeId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool Default { get; set; }
        public string Description { get; set; }
    }
}