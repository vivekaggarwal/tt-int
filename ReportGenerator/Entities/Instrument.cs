using Newtonsoft.Json;

namespace ReportGenerator.Entities
{
    public class Instrument
    {
        [JsonProperty("identifiers")]
        public Identifiers? Identifiers { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("instrumentDefinition")]
        public InstrumentDefinition? InstrumentDefinition { get; set; }

        [JsonProperty("domCcy")]
        public string? BaseCurrency { get; set; }

        [JsonIgnore]
        public string? Type => InstrumentDefinition?.InstrumentType;

        [JsonIgnore]
        public string? Isin => Identifiers?.Isin;

        [JsonIgnore]
        public string? Sedol => Identifiers?.Sedol;
    }

    public class Identifiers
    {
        public string? Isin { get; set; }
        public string? ClientInternal { get; set; }
        public string? LusidInstrumentId { get; set; }
        public string? Sedol { get; set; }
    }

    public class InstrumentDefinition
    {
        [JsonProperty("instrumentType")]
        public string? InstrumentType { get; set; }
    }
}
