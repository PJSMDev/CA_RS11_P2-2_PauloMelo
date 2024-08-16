using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagement.Models
{
    /// <summary>
    /// Represents a service selected by a client.
    /// </summary>
    public class ClientService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the client service.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientServiceId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the client.
        /// </summary>
        [Required(ErrorMessage = "The client ID is required.")]
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the service.
        /// </summary>
        [Required(ErrorMessage = "The service ID is required.")]
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the date when the service was provided.
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime ServiceDate { get; set; }

        #endregion

        #region Navigational Properties

        /// <summary>
        /// Gets or sets the client who selected the service.
        /// </summary>
        public Client Client { get; set; } = new Client();

        /// <summary>
        /// Gets or sets the service selected by the client.
        /// </summary>
        public Service Service { get; set; } = new Service();

        #endregion
    }
}
