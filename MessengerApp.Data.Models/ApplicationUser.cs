namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            this.Friends = new HashSet<Friend>();
            this.SentFriendRequests = new HashSet<FriendRequest>();
            this.ReceivedFriendRequests = new HashSet<FriendRequest>(); 
        }

        public string? ImageUrl { get; set; }

        [InverseProperty("Friends")]
        public ICollection<Friend> Friends { get; set; }

        [InverseProperty("Sender")]
        public ICollection<FriendRequest> SentFriendRequests { get; set; }

        [InverseProperty("Receiver")]
        public ICollection<FriendRequest> ReceivedFriendRequests { get; set; }

    }
}
