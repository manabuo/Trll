using System.Collections.Generic;
using System.Threading.Tasks;
using Trll.Core.Entities;

namespace Trll.Core.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetOrganizationsForCurrentUser();
    }
}