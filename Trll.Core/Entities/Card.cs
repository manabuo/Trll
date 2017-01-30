using System;
using System.Collections.Generic;

namespace Trll.Core.Entities
{
    public class Card
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public IEnumerable<CheckListItem> Checklist { get; set; }
        public IEnumerable<User> Members { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
    }

    public class CheckListItem
    {
        public bool Checked { get; set; }
    }
}