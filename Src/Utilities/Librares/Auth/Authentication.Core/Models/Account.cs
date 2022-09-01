using Authentication.Helpers;

namespace Authentication.Core.Models
{
    public class Account
    {
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        public PermissionGroups PermissionGroup { get; set; }
        public SessionStatus Session { get; set; }
    }
}
