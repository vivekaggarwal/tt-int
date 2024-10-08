namespace ReportGenerator
{
    public interface IRatingProvider
    {
        string GetRatingForIsin(string isin);
    }
}