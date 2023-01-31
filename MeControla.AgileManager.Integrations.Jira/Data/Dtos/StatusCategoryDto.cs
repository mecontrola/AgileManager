namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class StatusCategoryDto : BaseDto
    {
        public new int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string ColorName { get; set; }
    }
}