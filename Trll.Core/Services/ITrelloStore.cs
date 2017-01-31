using System.Collections.Generic;
using System.Threading.Tasks;
using Trll.Core.Entities;

namespace Trll.Core.Services
{
    public interface ITrelloStore
    {
        Task<UserProfile> GetCurrentUserAsync();
        Task<IEnumerable<Organization>> GetOrganizationsForCurrentUser();
        Task<IEnumerable<List>> ListsByBoardIdAsync(string id);
    }
}