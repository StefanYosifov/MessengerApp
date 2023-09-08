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
        }

        public string? ImageUrl { get; set; }

        [InverseProperty("Sender")]
        public ICollection<FriendShip> SentFriendRequests { get; set; }

        [InverseProperty("Receiver")]
        public ICollection<FriendShip> ReceivedFriendRequests { get; set; }

    }
}
