using Newtonsoft.Json;

namespace Trll.Core.Entities
{
    public class Board
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("idOrganization")]
        public string OrganizationId { get; set; }

        //TODO: I don't think this is needed
        public LabelNames LabelNames { get; set; }

        public Preferences Prefs { get; set; }

        public string BackgroundColor => Prefs?.BackgroundColor;

        public class Preferences
        {
            public string BackgroundColor { get; set; }
        }
    }
}