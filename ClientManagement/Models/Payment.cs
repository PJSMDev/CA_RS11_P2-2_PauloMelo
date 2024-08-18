using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagement.Models
{
    /// <summary>
    /// Represents a payment made by a client.
    /// </summary>
    public class Payment
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the payment.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the client who made the payment.
        /// </summary>
        [Required(ErrorMessage = "The client ID is required.")]
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the amount of money paid.
        /// </summary>
        [Required(ErrorMessage = "The amount is required.")]
        public decimal Amount { get; set; }

        #endregion

        #region Navigational Properties

        /// <summary>
        /// Gets or sets the client who made the payment.
        /// </summary>
        public Client Client { get; set; } = new Client();

        #endregion
    }
}
