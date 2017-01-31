using System.Collections.Generic;
using System.Threading.Tasks;
using Trll.Core.Entities;

namespace Trll.Core.Services
{
    public interface IBoardService
    {
        Task<IEnumerable<List>> ListsByBoardIdAsync(string id);
    }
}