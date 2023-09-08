namespace MessengerApp.Data.DbContext
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public virtual DbSet<ApplicationUser> Users { get; set; } = null!;

        public virtual DbSet<FriendShip> FriendShips { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}