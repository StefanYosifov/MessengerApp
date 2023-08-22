namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friend
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = null!;

        public ApplicationUser User  { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string FriendId { get; set; } = null!;

        [InverseProperty("Friends")]
        public ApplicationUser Friends { get; set; } = null!;

    }
}
