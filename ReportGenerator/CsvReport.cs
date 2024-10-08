using System.Text;

namespace ReportGenerator
{
    public class CsvReport
    {
        static readonly string HEADER = "ISIN,SEDOL,Instrument Name,Type,Currency,Moody's Rating,Analyst Rating\n";
        static readonly string SEPERATOR = ",";

        private readonly IEnumerable<ReportLine> reportLines;

        public CsvReport(IEnumerable<ReportLine> reportLines)
        {
            this.reportLines = reportLines;
        }

        public override string ToString()
        {
            StringBuilder output = new();

            output.AppendLine(HEADER);

            foreach (var line in reportLines)
            {
                output.Append(line.Isin + SEPERATOR);
                output.Append(line.Sedol + SEPERATOR);
                output.Append(line.InstrumentName + SEPERATOR);
                output.Append(line.InstrumentType + SEPERATOR);
                output.Append(line.BaseCurrency + SEPERATOR);
                output.Append(line.MoodysRating + SEPERATOR);
                output.Append(line.AnalstRating);
                output.AppendLine();
            }
            
            return output.ToString();
        }
    }
}
