namespace MessengerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Conversation
    {
        public Conversation()
        {
            this.UserConversations=new HashSet<UserConversation>();
            this.Messages = new HashSet<Message>();
        }

        [Key]
        public Guid Id { get; set; }

        public IEnumerable<UserConversation> UserConversations { get; set; }

        public IEnumerable<Message> Messages { get; set; }

    }
}
