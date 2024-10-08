namespace ReportGenerator.Entities
{
    public interface IRating
    {
        string Isin { get; set; }
        string Rating { get; set; }
    }
}
