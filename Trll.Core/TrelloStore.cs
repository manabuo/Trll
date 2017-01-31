using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trll.Core.Entities;
using Trll.Core.Services;

namespace Trll.Core
{
    public class TrelloStore : ITrelloStore
    {
        private readonly TrelloClient _trelloClient;
        private UserProfile _currentUser;
        private readonly IDictionary<string, MemberInfo> _membersCache;

        public TrelloStore(TrelloClient trelloClient)
        {
            _trelloClient = trelloClient;
            _membersCache = new Dictionary<string, MemberInfo>();
        }

        public async Task<UserProfile> GetCurrentUserAsync()
        {
            //TODO: Add caching invalidation logic

            return _currentUser ?? (_currentUser = await _trelloClient.CurrentUserProfileAsync());
        }

        public async Task<IEnumerable<Organization>> GetOrganizationsForCurrentUser()
        {
            //TODO: Add caching logic
            var organizations = await _trelloClient.Organizations();

            var userProfile = await GetCurrentUserAsync();

            var res = new[] {new Organization {DisplayName = "Personal Boards"}}
                .Concat(organizations).ToArray();

            foreach (var organization in res)
                organization.Boards = userProfile.Boards.Where(board => board.OrganizationId == organization.Id).ToArray();
            
            return res;
        }

        public async Task<IEnumerable<List>> ListsByBoardIdAsync(string id)
        {
            var lists = (await _trelloClient.ListsByBoardId(id)).ToArray();

            var selectMany = lists.SelectMany(list => list.Cards);

            foreach (var card in selectMany)
            {
                var members = new List<MemberInfo>();
                foreach (var memberId in card.MemberIds)
                    members.Add(await GetMemberInfoAsync(memberId));
                card.Members = members;
            }

            return lists;
        }

        private async Task<MemberInfo> GetMemberInfoAsync(string memberId)
        {
            if (_membersCache.ContainsKey(memberId))
                return _membersCache[memberId];

            var memberInfo = await _trelloClient.GetMemberInfoAsync(memberId);

            _membersCache[memberId] = memberInfo;

            return memberInfo;
        }
    }
}