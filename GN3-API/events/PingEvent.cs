using Newtonsoft.Json;

namespace GN3_API.events
{
    public class PingEvent : IEvent
    {
        [JsonProperty("cpu_usage_percent")]
        public float CPULoad { get; set; }

        [JsonProperty("memory_usage_percent")]
        public float RAMLoad { get; set; }
    }
}
