using Trll.Core.Entities;
using Trll.Core.Storage;

namespace Trll.Mobile.DummyStorage
{
    public class BoardRepository : IRepository<Board>
    {
        public Board ById(int id)
        {
            return new Board
            {
                Id = id,
                Name = $"Board {id}"
            };
        }
    }
}