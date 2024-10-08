namespace ReportGenerator
{
    public interface IReport
    {
        string GenerateReport(IEnumerable<ReportLine> reportLines);
    }
}