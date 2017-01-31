using System.Collections.Generic;
using System.Threading.Tasks;
using Trll.Core.Entities;

namespace Trll.Core.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ITrelloStore _trelloStore;

        public OrganizationService(ITrelloStore trelloStore)
        {
            _trelloStore = trelloStore;
        }

        public async Task<IEnumerable<Organization>> GetOrganizationsForCurrentUser() =>
            await _trelloStore.GetOrganizationsForCurrentUser();
    }
}