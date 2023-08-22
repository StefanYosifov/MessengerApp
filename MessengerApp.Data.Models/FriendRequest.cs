namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using DbContext.Enumeration;

    public class FriendRequest
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Sender")] public string SenderId { get; set; } = null!;
        public ApplicationUser Sender { get; set; }

        [Required]
        [ForeignKey("Receiver")] public string ReceiverUserId { get; set; } = null!;

        public ApplicationUser Receiver { get; set; }

        public FriendRequestStatus Status { get; set; }  
    }
}
