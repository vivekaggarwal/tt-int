namespace ReportGenerator.Entities
{
    public class AnalystRating : IRating
    {
        public string Isin { get; set; }
        public string Rating { get; set; }
    }
}
