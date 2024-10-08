using ReportGenerator;
using ReportGenerator.Entities;

class Program
{
    private static readonly string instrumentsUrl = "https://mocki.io/v1/5c913cd3-77b2-43b7-9c74-0982e6174298";
    private static readonly string moodysRatingsUrl = "https://mocki.io/v1/11ab88f0-0a9a-44ad-ac40-334005fc5117";
    private static readonly string analystRatingsUrl = "https://mocki.io/v1/1cf057a5-e4c7-4cd3-9701-fbf29d379a39";

    static async Task Main(string[] args)
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
            var reportBuilder = new CsvReportBuilder(instruments, moodysRatings, analystRatings);
            var csvReport = reportBuilder.GetCsvReport();
            Console.WriteLine(csvReport.ToString());
        }
        else
        {
            Console.WriteLine("Failed to generate the report due to missing data.");
        }
    }
}
