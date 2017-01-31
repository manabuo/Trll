using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trll.Core.Entities
{
    [JsonObject]
    public class Organization : IEnumerable<Board>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonIgnore]
        public IEnumerable<Board> Boards { get; set; }

        public IEnumerator<Board> GetEnumerator() =>
            Boards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}

