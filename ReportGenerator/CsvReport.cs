using System.Text;

namespace ReportGenerator
{
    public class CsvReport : IReport
    {
        static readonly string HEADER = "ISIN,SEDOL,Instrument Name,Type,Currency,Moody's Rating,Analyst Rating";
        static readonly string SEPERATOR = ",";

        public string GenerateReport(IEnumerable<ReportLine> reportLines)
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
