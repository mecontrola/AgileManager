namespace Stefanini.GitHub.Core.Data.Dto.GitHub
{
    public class ReactionsDto
    {
        public string Url { get; set; }
        public int TotalCount { get; set; }
        //"+1": 0,
        //"-1": 0,
        public int Laugh { get; set; }
        public int Hooray { get; set; }
        public int Confused { get; set; }
        public int Heart { get; set; }
        public int Rocket { get; set; }
        public int Eyes { get; set; }
    }
}