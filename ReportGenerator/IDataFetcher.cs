namespace ReportGenerator
{
    public interface IDataFetcher<T>
    {
        Task<List<T>?> FetchDataAsync(string url);
    }
}
