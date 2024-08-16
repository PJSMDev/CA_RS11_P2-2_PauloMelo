using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagement.Models
{
    #region Service Model

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
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service (e.g., Personal Training, Yoga).
        /// </summary>
        [Required]
        [MaxLength(100)] 
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the service.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        #endregion
    }

    #endregion
}
