using mySampleBackend.Infrastructure;
using Newtonsoft.Json;

namespace mySampleBackend.Domain
{
    public class FloopResponse
    {
        [JsonProperty("errorReason")]
        public string? ErrorReason { get; set; }
        public Floop? Floop {  get; set; }
    }
    public class Floop
    {
        [JsonProperty("floopName")]
        public string FloopName { get; set; }
        [JsonProperty("floopType")]
        public string FloopType { get; set; }
        [JsonProperty("floopSafetyCode")]
        public string FloopSafetyCode { get; set; }
        [JsonProperty("floopValue")]
        public double FloopValue { get; set; }
    }

}
