namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Infrastucture.Constants.Constants;

    public class Reply
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ReplyConstants.ReplyContentMaxLength)]
        public string ReplyContent { get; set; } = null!;

        [ForeignKey(nameof(Message))]
        public Guid MessageId { get; set; }

        public Message Message { get; set; } = null!;
    }
}
