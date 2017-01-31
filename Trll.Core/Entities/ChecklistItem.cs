using Newtonsoft.Json;

namespace Trll.Core.Entities
{
    public class CheckListItem
    {
        public string Id { get; set; }

        public State State { get; set; }


        [JsonProperty("idChecklist")]
        public string ChecklistId { get; set; }

        public string Name { get; set; }

        public bool Checked => State == State.Complete;
    }
}