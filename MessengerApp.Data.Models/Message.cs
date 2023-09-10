namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Infrastucture.Constants.Constants;

    public class Message
    {

        public Message()
        {
            this.Replies = new HashSet<Reply>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(MessageConstants.MessageContentMaxLength)]
        public string MessageContent { get; set;} = null!;

        [ForeignKey(nameof(Conversation))]
        public Guid ConversationId { get; set; }

        public Conversation Conversation { get; set; } = null!;

        public IEnumerable<Reply> Replies { get; set; }

    }
}
