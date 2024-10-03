using Newtonsoft.Json;

namespace mySampleBackend.Domain
{
    public class FloopRequest
    {
        [JsonProperty("floopValue")]
        public double FloopValue { get; set; }
        [JsonProperty("testFlag")]
        public bool TestFlag { get; set; }

    }
}
