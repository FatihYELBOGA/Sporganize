namespace Sporganize.Models
{
    public class UserFriends
    {
        public int Id { get; set; }
        public int? FollowingUserId { get; set; }
        public User? FollowingUser { get; set; }
        public int? FollowerUserId { get; set; }
        public User? FollowerUser { get; set; }

    }
}
