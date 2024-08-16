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
        [Required(ErrorMessage = "The name field is required.")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the client.
        /// </summary>
        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of birth of the client.
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the client.
        /// </summary>
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of membership for the client.
        /// </summary>
        [Required(ErrorMessage = "The membership type is required.")]
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
        public MembershipType MembershipType { get; set; } = new MembershipType();

        /// <summary>
        /// Gets or sets the collection of services used by the client.
        /// </summary>
        public ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();

        #endregion
    }

    #endregion
}
