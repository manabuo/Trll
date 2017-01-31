using System.Threading.Tasks;
using Trll.Core.Entities;

namespace Trll.Core.Services
{
    public interface IUserProfileService
    {
        Task<UserProfile> GetCurrentUserAsync();
    }
}