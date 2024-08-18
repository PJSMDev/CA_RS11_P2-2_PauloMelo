using System;
using System.Collections.Generic;
using ClientManagement.Enums;
using ClientManagement.Models;
using System.Linq;

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
        /// <seealso href="https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding"/>
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
                Price = 100m,
                IsRecurring = true,
                LoyaltyMonths = 12
            };

            var payPerSessionMembership = new MembershipType
            {
                MembershipTypeName = MembershipTypeEnum.PayPerSession,
                Price = 20m,
                IsRecurring = false,
                LoyaltyMonths = null
            };

            // Add Membership Types to Database
            context.MembershipTypes.AddRange(monthlyLoyalMembership, payPerSessionMembership);

            // Seed Clients
            var clients = new[]
            {
                new Client
                {
                    Name = "Paulo Silva Melo",
                    Email = "pjsm.lesi@gmail.com",
                    PhoneNumber = "925109653",
                    DateOfBirth = new DateTime(1986, 1, 27),
                    MembershipTypeId = monthlyLoyalMembership.MembershipTypeId,
                    IsLoyal = true
                },
                new Client
                {
                    Name = "Milena Reis e Sousa",
                    Email = "milena.reis.sousa@hotmail.com",
                    PhoneNumber = "964576123",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    MembershipTypeId = payPerSessionMembership.MembershipTypeId,
                    IsLoyal = false
                }
            };

            context.Clients.AddRange(clients);

            // Seed Services
            var services = new[]
            {
                new Service { Name = "Personal Training", Price = 50m },
                new Service { Name = "Yoga", Price = 30m },
                new Service { Name = "Pilates", Price = 40m },
                new Service { Name = "Swimming", Price = 35m },
                new Service { Name = "Zumba", Price = 25m },
                new Service { Name = "Boxing", Price = 45m },
                new Service { Name = "Martial Arts", Price = 55m },
                new Service { Name = "CrossFit", Price = 60m },
                new Service { Name = "Aerobics", Price = 30m },
                new Service { Name = "Spin Class", Price = 40m },
                new Service { Name = "Dance", Price = 30m },
                new Service { Name = "Strength Training", Price = 50m },
                new Service { Name = "Stretching", Price = 20m },
                new Service { Name = "Nutrition Coaching", Price = 70m },
                new Service { Name = "Massage Therapy", Price = 80m },
                new Service { Name = "Sauna", Price = 15m },
                new Service { Name = "Steam Room", Price = 20m },
                new Service { Name = "Personalized Workout Plan", Price = 100m },
                new Service { Name = "Group Fitness Class", Price = 25m },
                new Service { Name = "Wellness Consultation", Price = 60m },
                new Service { Name = "Body Analysis", Price = 40m }
            };

            context.Services.AddRange(services);

            // Save changes to the database
            context.SaveChanges();
        }

        #endregion
    }
}
