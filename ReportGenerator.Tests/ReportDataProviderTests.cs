using FluentAssertions;
using Newtonsoft.Json;
using ReportGenerator.Entities;


namespace ReportGenerator.Tests
{
    public class ReportDataProviderTests
    {
        [Fact]
        public void ReportDataProvider_GeneratesReport_Correctly()
        {
            string instrumentsJsonPath = "./data/instruments.json";
            string moodysJsonPath = "./data/moodys.json";
            string analystJsonPath = "./data/analystratings.json";

            var instruments = JsonConvert.DeserializeObject<ApiResponse<Instrument>>(File.ReadAllText(instrumentsJsonPath)).Values.Take(1);
            var moodysRatings = JsonConvert.DeserializeObject<ApiResponse<MoodysRating>>(File.ReadAllText(moodysJsonPath)).Values;
            var analystRatings = JsonConvert.DeserializeObject<ApiResponse<AnalystRating>>(File.ReadAllText(analystJsonPath)).Values;

            IReportDataProvider<ReportLine> dataProvider = new ReportDataProvider(instruments, moodysRatings, analystRatings);

            var result = dataProvider.GetReportData();

            result.Should().NotBeNull();
            result.First().AnalstRating.Should().Be("Buy");
        }
    }
}
