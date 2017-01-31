using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trll.Core.Entities
{
    public class Card
    {
        public string Id { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("idBoard")]
        public string BoardId { get; set; }

        [JsonProperty("idList")]
        public string ListId { get; set; }
        
        public string Name { get; set; }

        public Badges Badges { get; set; }

        public bool DueComplete { get; set; }

        public DateTime? Due { get; set; }

        public IEnumerable<Label> Labels { get; set; }

        [JsonProperty("idMembers")]
        public IEnumerable<string> MemberIds { get; set; }

        public IEnumerable<MemberInfo> Members { get; set; }
    }
}