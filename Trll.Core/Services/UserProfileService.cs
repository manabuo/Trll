using System.Threading.Tasks;
using Trll.Core.Entities;

namespace Trll.Core.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ITrelloStore _trelloStore;

        public UserProfileService(ITrelloStore trelloStore)
        {
            _trelloStore = trelloStore;
        }

        public async Task<UserProfile> GetCurrentUserAsync() =>
            await _trelloStore.GetCurrentUserAsync();
    }
}