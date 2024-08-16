using System.Linq;
using ClientManagement.Models;

namespace ClientManagement.DAL
{
    /// <summary>
    /// Class for initializing the database with default data.
    /// </summary>
    public static class DatabaseInitializer
    {
        #region Public Methods

        /// <summary>
        /// Initializes the database with default data if it is not already seeded.
        /// </summary>
        /// <param name="context">The database context to initialize.</param>
        public static void Initialize(ClientManagementDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if any services already exist
            if (context.Services.Any())
            {
                return; // DB has been seeded
            }

            // Seed the database with initial data
            SeedDatabase(context);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Seeds the database with a predefined list of services.
        /// </summary>
        /// <param name="context">The database context to seed.</param>
        private static void SeedDatabase(ClientManagementDbContext context)
        {
            var services = new[]
            {
                new Service { Name = "Personal Training", Price = 50m },
                new Service { Name = "Yoga", Price = 30m },
                new Service { Name = "Pilates", Price = 40m },
                new Service { Name = "Zumba", Price = 35m },
                new Service { Name = "Spinning", Price = 45m },
                new Service { Name = "HIIT", Price = 50m },
                new Service { Name = "Kickboxing", Price = 55m },
                new Service { Name = "CrossFit", Price = 60m },
                new Service { Name = "Body Pump", Price = 50m },
                new Service { Name = "Cardio Kick", Price = 40m },
                new Service { Name = "Strength Training", Price = 55m },
                new Service { Name = "Aqua Aerobics", Price = 30m },
                new Service { Name = "Dance Fitness", Price = 35m },
                new Service { Name = "Stretch & Relax", Price = 25m },
                new Service { Name = "Functional Training", Price = 50m },
                new Service { Name = "Group Cycling", Price = 45m },
                new Service { Name = "Boxing", Price = 50m },
                new Service { Name = "Meditation", Price = 20m },
                new Service { Name = "Nutrition Counseling", Price = 70m }
            };

            // Add the services to the database
            context.Services.AddRange(services);
            context.SaveChanges();
        }

        #endregion
    }
}
