using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagement.Models
{
    #region ClientService Model

    /// <summary>
    /// Represents the association between a client and a service.
    /// </summary>
    public class ClientService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        [Key, Column(Order = 0)]
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        [Key, Column(Order = 1)]
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the date when the service was used.
        /// </summary>
        public DateTime ServiceDate { get; set; }

        #endregion

        #region Navigational Properties

        /// <summary>
        /// Gets or sets the client associated with the service.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the service associated with the client.
        /// </summary>
        public Service Service { get; set; }

        #endregion
    }

    #endregion
}
