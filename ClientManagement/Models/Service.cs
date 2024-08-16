using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagement.Models
{
    /// <summary>
    /// Represents a service offered by the gym.
    /// </summary>
    public class Service
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the service.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; } // Primary key

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the service.
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        #endregion

        #region Navigational Properties

        /// <summary>
        /// Gets or sets the client services associated with this service.
        /// </summary>
        public ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();

        #endregion
    }
}
