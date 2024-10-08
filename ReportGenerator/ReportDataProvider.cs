using ReportGenerator.Entities;

namespace ReportGenerator
{
    public class ReportDataProvider : IReportDataProvider<ReportLine>
    {
        private readonly IEnumerable<Instrument> _instruments;
        private readonly RatingProvider _moodysRatings;
        private readonly RatingProvider _analystRatings;

        public ReportDataProvider(IEnumerable<Instrument> instruments, IEnumerable<MoodysRating> moodysRatings, IEnumerable<AnalystRating> analystRatings)
        {
            _instruments = instruments;
            _moodysRatings = new RatingProvider(moodysRatings);
            _analystRatings = new RatingProvider(analystRatings);
        }
        
        public IEnumerable<ReportLine> GetReportData()
        {
            IList<ReportLine> lines = new List<ReportLine>();

            foreach (var instrument in _instruments) {
                lines.Add(new ReportLine {
                    Isin = instrument.Isin,
                    InstrumentName = instrument.Name,
                    InstrumentType = instrument.Type,
                    Sedol = instrument.Sedol,
                    BaseCurrency = instrument.BaseCurrency,
                    MoodysRating = _moodysRatings.GetRatingForIsin(instrument.Isin),
                    AnalstRating = _analystRatings.GetRatingForIsin(instrument.Isin)
                });
            }

            return lines;
        }
    }
}
