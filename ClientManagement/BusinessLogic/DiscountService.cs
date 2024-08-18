using ClientManagement.Models;

namespace ClientManagement.BusinessLogic
{
    /// <summary>
    /// Provides discount calculation services for clients.
    /// </summary>
    public class DiscountService
    {
        // Constant discount percentage for loyal clients
        private const decimal LoyaltyDiscountPercentage = 10m;

        /// <summary>
        /// Calculates the discount for a client based on their loyalty status and membership type.
        /// </summary>
        /// <param name="client">The client for whom the discount is being calculated.</param>
        /// <param name="basePrice">The base price of the service or membership.</param>
        /// <returns>The final price after applying the discount.</returns>
        public decimal CalculateDiscount(Client client, decimal basePrice)
        {
            // Check if the client is loyal and has a recurring membership with a defined loyalty period.
            if (client.IsLoyal && client.MembershipType.IsRecurring && client.MembershipType.LoyaltyMonths.HasValue)
            {
                // Apply the fixed discount rate.
                decimal discountRate = LoyaltyDiscountPercentage / 100m;
                return basePrice * (1 - discountRate);
            }

            // Return the base price if no discount is applicable.
            return basePrice;
        }
    }
}
