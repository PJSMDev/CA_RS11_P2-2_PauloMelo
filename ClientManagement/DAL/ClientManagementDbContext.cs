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
        /// <seealso href="https://learn.microsoft.com/en-us/ef/core/modeling/"/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration for the Payment entity
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)")
                .HasComment("The amount of money paid.");

            // Configuration for the Service entity
            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)")
                .HasComment("The price of the service.");

            // Configuration for the MembershipType entity
            modelBuilder.Entity<MembershipType>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)")
                .HasComment("The price associated with the membership type.");

            // Configure one-to-many relationship between Client and MembershipType
            modelBuilder.Entity<Client>()
                .HasOne(c => c.MembershipType)
                .WithMany()
                .HasForeignKey(c => c.MembershipTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationship between Client and Service via ClientService
            modelBuilder.Entity<ClientService>()
                .HasOne(cs => cs.Client)
                .WithMany(c => c.ClientServices)
                .HasForeignKey(cs => cs.ClientId);

            modelBuilder.Entity<ClientService>()
                .HasOne(cs => cs.Service)
                .WithMany(s => s.ClientServices)
                .HasForeignKey(cs => cs.ServiceId);

            // Configure one-to-many relationship between Payment and Client
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
