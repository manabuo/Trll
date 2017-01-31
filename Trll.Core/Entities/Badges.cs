using System;

namespace Trll.Core.Entities
{
    public class Badges
    {
        public int CheckItems { get; set; }

        public int CheckItemsChecked { get; set; }

        public int Comments { get; set; }

        public int Attachments { get; set; }

        public bool Description { get; set; }

        public DateTime? Due { get; set; }

        public bool DueComplete { get; set; }
    }
}