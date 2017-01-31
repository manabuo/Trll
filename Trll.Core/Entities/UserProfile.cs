using System.Collections.Generic;

namespace Trll.Core.Entities
{
    public class UserProfile
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Initials { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public IEnumerable<Board> Boards { get; set; }

        public IEnumerable<Organization> Organizations { get; set; }
    }
}