using System.Collections.Generic;

namespace Trll.Core.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CardList> Lists { get; set; }
    }
}