using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trll.Core.Entities
{
    public class Checklist
    {
        public string Id { get; set; }

        [JsonProperty("idBoard")]
        public string BoardId { get; set; }
        [JsonProperty("idCard")]
        public string CardId { get; set; }

        public string Name { get; set; }

        public IEnumerable<CheckListItem> CheckItems { get; set; }
    }
}