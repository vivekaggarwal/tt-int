using FluentAssertions;
using Newtonsoft.Json;
using ReportGenerator.Entities;

namespace ReportGenerator.Tests
{
    public class RatingProviderTests
    {
        [Theory]
        [InlineData("QS000212QM71", "Sell")]
        [InlineData(null, "Not available")]
        [InlineData("MadeUpIsin", "Not available")]
        public void GetRatingForIsin_ReturnsExpectedValues(string isin, string expectedRating)
        {
            string filePath = "./data/analystratings.json";

            var ratings = JsonConvert.DeserializeObject<ApiResponse<AnalystRating>>(File.ReadAllText(filePath)).Values;

            var ratingProvider = new RatingProvider(ratings);

            var result = ratingProvider.GetRatingForIsin(isin);

            result.Should().NotBeNull();
            result.Should().Be(expectedRating);
        }
    }
}
