using FluentAssertions;
using Newtonsoft.Json;
using ReportGenerator.Entities;

namespace ReportGenerator.Tests
{
    public class CsvReportTests
    {
        [Fact]
        public void CsvReport_GeneratesReport_Correctly()
        {
            var expectedResult = "ISIN,SEDOL,Instrument Name,Instrument Type,Base Currency,Moody's Rating,Analyst Rating\r\nBMG9456A1009 UW,2367963 UW,GOLAR LNG LTD (UW),Equity,USD,Not available,Buy\r\n";

            string instrumentsJsonPath = "./data/instruments.json";
            string moodysJsonPath = "./data/moodys.json";
            string analystJsonPath = "./data/analystratings.json";

            var instruments = JsonConvert.DeserializeObject<ApiResponse<Instrument>>(File.ReadAllText(instrumentsJsonPath)).Values.Take(1);
            var moodysRatings = JsonConvert.DeserializeObject<ApiResponse<MoodysRating>>(File.ReadAllText(moodysJsonPath)).Values;
            var analystRatings = JsonConvert.DeserializeObject<ApiResponse<AnalystRating>>(File.ReadAllText(analystJsonPath)).Values;

            IReportDataProvider<ReportLine> dataProvider = new ReportDataProvider(instruments, moodysRatings, analystRatings);

            var result = dataProvider.GetReportData();

            IReport csvReport = new CsvReport();

            var reportString = csvReport.GenerateReport(result);

            reportString.Should().NotBeNullOrEmpty();
            reportString.Should().Be(expectedResult);
        }
    }
}
