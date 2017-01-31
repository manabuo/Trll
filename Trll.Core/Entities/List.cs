using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trll.Core.Entities
{
    public class List
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("idBoard")]
        public string BoardId { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}