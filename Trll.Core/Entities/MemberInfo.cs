namespace Trll.Core.Entities
{
    public class MemberInfo
    {
        public string Initials { get; set; }
        public string AvatarHash { get; set; }
        public string FullName { get; set; }
        public byte[] AvatarBytes { get; set; }
    }
}