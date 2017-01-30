using System.Linq;
using Trll.Core.Entities;
using Trll.Core.Storage;

namespace Trll.Mobile.DummyStorage
{
    public class BoardRepository : IRepository<Board>
    {
        public Board ById(int id)
        {
            var i = 0;
            return new Board
            {
                Id = id,
                Name = $"Board {id}",
                Lists = Enumerable.Range(0, 3).Select(j =>
                    new CardList
                    {
                        Id = i++,
                        Name = $"CardList #{i}",
                        Cards = Enumerable.Range(0, 3).Select(k => new Card
                        {
                            Id = i++,
                            Name = $"Card {i}"
                        }).ToList()
                    }).ToList()
            };
        }
    }
}