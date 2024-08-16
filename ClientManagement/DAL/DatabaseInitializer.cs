using System;
using System.Collections.Generic;
using ClientManagement.Enums;
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
                MembershipTypeName = MembershipTypeEnum.MonthlyLoyal
            };

            var payPerSessionMembership = new MembershipType
            {
                MembershipTypeName = MembershipTypeEnum.PayPerSession
            };

            // Add Membership Types to Database
            context.MembershipTypes.AddRange(monthlyLoyalMembership, payPerSessionMembership);

            // Seed Clients
            var clients = new[]
            {
                new Client
                {
                    Name = "John Monthly",
                    Email = "johnmonthly@example.com",
                    PhoneNumber = "123-456-7890",
                    MembershipTypeId = 1 // Cliente com contrato mensal
                },
                new Client
                {
                    Name = "Jane Session",
                    Email = "janesession@example.com",
                    PhoneNumber = "098-765-4321",
                    MembershipTypeId = 2 // Cliente com pagamento por sessão
                }
            };

            context.Clients.AddRange(clients);

            // Seed Services
            var services = new[]
            {
                new Service { Name = "Personal Training", Price = 50m },
                new Service { Name = "Yoga", Price = 30m }
                // Adicione mais serviços conforme necessário
            };

            context.Services.AddRange(services);

            // Salva as mudanças no banco de dados
            context.SaveChanges();
        }

        #endregion
    }
}
