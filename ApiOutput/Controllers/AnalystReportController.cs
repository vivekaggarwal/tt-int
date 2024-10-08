using Microsoft.AspNetCore.Mvc;
using ReportGenerator;
using ReportGenerator.Entities;

namespace ApiOutput.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalystReportController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static readonly string instrumentsUrl = "https://mocki.io/v1/5c913cd3-77b2-43b7-9c74-0982e6174298";
        private static readonly string moodysRatingsUrl = "https://mocki.io/v1/11ab88f0-0a9a-44ad-ac40-334005fc5117";
        private static readonly string analystRatingsUrl = "https://mocki.io/v1/1cf057a5-e4c7-4cd3-9701-fbf29d379a39";


        public AnalystReportController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAnalystReport")]
        public async Task<string> Get()
        {
            // Dependency injection: Fetchers and Report generator
            IDataFetcher<Instrument> instrumentFetcher = new ApiDataFetcher<Instrument>();
            IDataFetcher<MoodysRating> moodysRatingFetcher = new ApiDataFetcher<MoodysRating>();
            IDataFetcher<AnalystRating> analystRatingFetcher = new ApiDataFetcher<AnalystRating>();

            // Fetch the data from the 'values' node of each API response
            var instruments = await instrumentFetcher.FetchDataAsync(instrumentsUrl);
            var moodysRatings = await moodysRatingFetcher.FetchDataAsync(moodysRatingsUrl);
            var analystRatings = await analystRatingFetcher.FetchDataAsync(analystRatingsUrl);

            // Ensure data is not null before generating the report
            if (instruments != null && moodysRatings != null && analystRatings != null)
            {
                var reportBuilder = new ReportDataProvider(instruments, moodysRatings, analystRatings);
                var reportData = reportBuilder.GetReportData();

                var csvReport = new CsvReport();
                var report = csvReport.GenerateReport(reportData);


                return report;
            }

            return "Input data is not valid.";
        }
    }
}
