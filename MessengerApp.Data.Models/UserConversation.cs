namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserConversation
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Conversation))]
        public Guid ConversationId { get; set; }

        public Conversation Conversation { get; set; }

    }
}
