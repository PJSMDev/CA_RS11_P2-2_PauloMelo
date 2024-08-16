using Microsoft.EntityFrameworkCore;
using ClientManagement.Models;

namespace ClientManagement.DAL
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class ClientManagementDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientManagementDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the <see cref="DbContext"/>.</param>
        public ClientManagementDbContext(DbContextOptions<ClientManagementDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity in the model
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<MembershipType> MembershipTypes { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<ClientService> ClientServices { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        /// <summary>
        /// Configures the model creating process.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration for the Payment entity
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)") // Precision and scale for Amount
                .HasComment("The amount of money paid."); // Optional comment

            // Configuration for the Service entity
            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)") // Precision and scale for Price
                .HasComment("The price of the service."); // Optional comment

            // Configuration for the MembershipType entity
            modelBuilder.Entity<MembershipType>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)") // Precision and scale for Price
                .HasComment("The price associated with the membership type."); // Optional comment
        }
    }
}
