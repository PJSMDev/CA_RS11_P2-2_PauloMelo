using System;
using System.Collections.Generic;
using System.Linq;
using ClientManagement.Enums;
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

            // Check if any clients already exist
            if (context.Clients.Any())
            {
                return; // DB has been seeded
            }

            // Seed the database with initial data
            SeedDatabase(context);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Seeds the database with predefined clients, services, and membership types.
        /// </summary>
        /// <param name="context">The database context to seed.</param>
        private static void SeedDatabase(ClientManagementDbContext context)
        {
            // Define Membership Types
            var monthlyLoyalMembership = new MembershipType
            {
                MembershipTypeName = MembershipTypeEnum.MonthlyLoyal,
                Price = 29.99m, // Defina o preço apropriado
                IsRecurring = true,
                LoyaltyMonths = 6 // Defina o número de meses de lealdade
            };

            var payPerSessionMembership = new MembershipType
            {
                MembershipTypeName = MembershipTypeEnum.PayPerSession,
                Price = 10.00m, // Defina o preço apropriado
                IsRecurring = false
            };

            // Add Membership Types to Database
            context.MembershipTypes.AddRange(monthlyLoyalMembership, payPerSessionMembership);

            // Seed Services
            var services = new[]
            {
                new Service { Name = "Personal Training", Price = 50m },
                new Service { Name = "Yoga", Price = 30m },
                new Service { Name = "Zumba", Price = 25m },
                new Service { Name = "Pilates", Price = 35m },
                new Service { Name = "Boxing", Price = 40m },
                new Service { Name = "Spin Class", Price = 20m },
                new Service { Name = "Swimming", Price = 45m },
                new Service { Name = "Meditation", Price = 15m },
                new Service { Name = "Massage", Price = 60m },
                new Service { Name = "Nutrition Counseling", Price = 55m },
                new Service { Name = "Cardio Kickboxing", Price = 50m },
                new Service { Name = "Strength Training", Price = 40m },
                new Service { Name = "Group Fitness", Price = 30m },
                new Service { Name = "Flexibility Training", Price = 20m },
                new Service { Name = "Running Club", Price = 25m },
                new Service { Name = "Functional Training", Price = 35m },
                new Service { Name = "Senior Fitness", Price = 30m },
                new Service { Name = "Kids Fitness", Price = 25m },
                new Service { Name = "Aquatic Fitness", Price = 40m },
                new Service { Name = "Corporate Wellness", Price = 60m },
                new Service { Name = "Private Lessons", Price = 70m }
            };

            // Add Services to Database
            context.Services.AddRange(services);

            // Seed Clients
            var clients = new[]
            {
                new Client
                {
                    Name = "Paulo Silva Melo",
                    Email = "pjsm.lesi@gmail.com",
                    PhoneNumber = "925109653",
                    DateOfBirth = new DateTime(1986, 1, 27),
                    MembershipTypeId = 1, // ID do MembershipType 'MonthlyLoyal'
                    IsLoyal = true
                },
                new Client
                {
                    Name = "Milena Reis e Sousa",
                    Email = "milena.reis.sousa@hotmail.com",
                    PhoneNumber = "964576123",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    MembershipTypeId = 2, // ID do MembershipType 'PayPerSession'
                    IsLoyal = false
                }
            };

            // Add Clients to Database
            context.Clients.AddRange(clients);

            // Add Client Services
            var clientServices = new[]
            {
                new ClientService
                {
                    ClientId = 1, // ID de 'Paulo Silva Melo'
                    ServiceId = services.First(s => s.Name == "Personal Training").ServiceId,
                    ServiceDate = DateTime.Now
                },
                new ClientService
                {
                    ClientId = 2, // ID de 'Milena Reis e Sousa'
                    ServiceId = services.First(s => s.Name == "Yoga").ServiceId,
                    ServiceDate = DateTime.Now
                }
            };

            context.ClientServices.AddRange(clientServices);

            // Save changes to database
            context.SaveChanges();
        }

        #endregion
    }
}
