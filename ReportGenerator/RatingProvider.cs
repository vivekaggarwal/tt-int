using ReportGenerator.Entities;

namespace ReportGenerator
{
    public class RatingProvider : IRatingProvider
    {
        IDictionary<string, string> _ratings;

        public RatingProvider(IEnumerable<IRating> ratings)
        {
            _ratings = ratings.ToDictionary(x => x.Isin, x => x.Rating);
        }

        public string GetRatingForIsin(string isin)
        {
            var result = "Not available";

            if (!string.IsNullOrEmpty(isin) && _ratings.ContainsKey(isin))
            {
                result = _ratings[isin];
            }

            return result;
        }
    }
}
