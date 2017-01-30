using System.Collections.Generic;

namespace Trll.Core.Entities
{
    public class CardList
    {
        public int Id { get; set; }
        public IEnumerable<Card> Cards { get; set; }
    }
}