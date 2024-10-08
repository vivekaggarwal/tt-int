namespace ReportGenerator
{
    public class ReportLine
    {
        public string Isin { get; set; }
        public string Sedol { get; set; }
        public string InstrumentName { get; set; }
        public string InstrumentType { get; set; }
        public string BaseCurrency { get; set; }
        public string MoodysRating { get; set; }
        public string AnalstRating { get; set; }
    }
}
