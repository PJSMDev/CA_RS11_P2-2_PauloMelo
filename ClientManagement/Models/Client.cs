using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Models
{
    #region Client Model

    /// <summary>
    /// Represents a client in the system.
    /// </summary>
    public class Client
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        [Key]
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the client.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the client.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the client.
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of membership for the client.
        /// </summary>
        [Required]
        public int MembershipTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the client is loyal.
        /// </summary>
        public bool IsLoyal { get; set; }

        #endregion

        #region Navigational Properties

        /// <summary>
        /// Gets or sets the membership type associated with the client.
        /// </summary>
        public MembershipType MembershipType { get; set; }

        /// <summary>
        /// Gets or sets the collection of services used by the client.
        /// </summary>
        public ICollection<ClientService> ClientServices { get; set; }

        #endregion
    }

    #endregion
}
