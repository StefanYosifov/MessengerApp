namespace MessengerApp.Data.DbContext
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    using Models;

    public class MessengerDbContext : IdentityDbContext
    {
        private readonly IConfiguration configuration;

        public MessengerDbContext(
            DbContextOptions<MessengerDbContext> options,
            IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<ApplicationUser> Users { get; set; } = null!;

        public virtual DbSet<FriendShip> FriendShips { get; set; } = null!;

        public virtual DbSet<Message> Messages { get; set; } = null!;

        public virtual DbSet<Reply> Replies { get; set; } = null!;

        public virtual DbSet<Conversation> Conversations { get; set; } = null!;

        public virtual DbSet<UserConversation> UserConversations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserConversation>()
                .HasKey(k => new
                {
                    k.ConversationId, k.UserId
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}