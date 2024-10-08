using FluentAssertions;
using Newtonsoft.Json;
using ReportGenerator.Entities;

namespace ReportGenerator.Tests
{
    public class JsonTests
    {
        [Fact]
        public void DeserialiseInstrumentJson_ShouldReturnInstrumentObjects_WhenValidJsonProvided()
        {
            string filePath = "./data/instruments.json";

            var result = JsonConvert.DeserializeObject<ApiResponse<Instrument>>(File.ReadAllText(filePath));

            result.Should().NotBeNull();
            result.Values.Count.Should().Be(61);
        }

        [Fact]
        public void DeserialiseAnalystRatingsJson_ShouldReturnAnalystRatingObjects_WhenValidJsonProvided()
        {
            string filePath = "./data/analystratings.json";

            var result = JsonConvert.DeserializeObject<ApiResponse<AnalystRating>>(File.ReadAllText(filePath));

            result.Should().NotBeNull();
            result.Values.Count.Should().Be(13);
        }

        [Fact]
        public void DeserialiseMoodysRatingsJson_ShouldReturnMoodysRatingObjects_WhenValidJsonProvided()
        {
            string filePath = "./data/moodys.json";

            var result = JsonConvert.DeserializeObject<ApiResponse<MoodysRating>>(File.ReadAllText(filePath));

            result.Should().NotBeNull();
            result.Values.Count.Should().Be(17);
        }
    }
}