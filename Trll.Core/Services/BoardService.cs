using System.Collections.Generic;
using System.Threading.Tasks;
using Trll.Core.Entities;

namespace Trll.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly ITrelloStore _trelloStore;

        public BoardService(ITrelloStore trelloStore)
        {
            _trelloStore = trelloStore;
        }

        public async Task<IEnumerable<List>> ListsByBoardIdAsync(string id) => 
            await _trelloStore.ListsByBoardIdAsync(id);
    }
}