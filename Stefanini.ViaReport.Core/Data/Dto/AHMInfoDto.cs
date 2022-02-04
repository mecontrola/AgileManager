namespace Stefanini.ViaReport.Core.Data.Dto
{
    public class AHMInfoDto
    {
        public string Date { get; set; }
        public decimal? GrowthToDo { get; set; }
        public decimal? GrowthInProgress { get; set; }
        public decimal? UpstreamDownstreamRate { get; set; }
        public bool IsChecked { get; set; }
    }
}