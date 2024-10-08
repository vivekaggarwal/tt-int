namespace ReportGenerator.Entities
{
    public class MoodysRating : IRating
    {
        public string? Isin { get; set; }
        public string? Rating { get; set; }
    }
}
