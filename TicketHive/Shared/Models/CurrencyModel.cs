using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Shared.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Rates
    {
        [JsonProperty("EUR")]
        public double? Euro { get; set; }
        [JsonProperty("GBP")]
        public double? Pounds { get; set; }
    }

    public class Root
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("timestamp")]
        public int? Timestamp { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("rates")]
        public Rates Rates { get; set; }
    }



}
