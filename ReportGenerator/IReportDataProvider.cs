namespace ReportGenerator
{
    public interface IReportDataProvider<T>
    {
        IEnumerable<T> GetReportData();
    }
}