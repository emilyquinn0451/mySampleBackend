using Newtonsoft.Json;

namespace mySampleBackend.Domain
{
    public class FloopRequest
    {
        [JsonProperty("testFlag")]
        public bool TestFlag { get; set; }

    }
}
