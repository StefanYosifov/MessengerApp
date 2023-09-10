namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            this.SentFriendRequests = new HashSet<FriendShip>();
            this.ReceivedFriendRequests = new HashSet<FriendShip>();
            this.UserConversations = new HashSet<UserConversation>();
        }

        public string? ImageUrl { get; set; }

        [InverseProperty("Sender")]
        public IEnumerable<FriendShip> SentFriendRequests { get; set; }

        [InverseProperty("Receiver")]
        public IEnumerable<FriendShip> ReceivedFriendRequests { get; set; }

        public IEnumerable<UserConversation> UserConversations { get; set; }

    }
}
