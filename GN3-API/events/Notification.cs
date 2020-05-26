using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GN3_API.events
{
    [JsonConverter(typeof(EventConverter))]
    public class Notification
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        public IEvent Event { get; set; }

        public string EventJson { get; set; }
    }
}
