using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClientManagement.Enums;
using ClientManagement.Models;

namespace ClientManagement.Models
{
    #region MembershipType Model

    /// <summary>
    /// Represents a type of membership or payment option.
    /// </summary>
    public class MembershipType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the membership type.
        /// </summary>
        [Key]
        public int MembershipTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the membership type (e.g., MonthlyLoyal, MonthlyNonLoyal, PayPerSession).
        /// </summary>
        [Required(ErrorMessage = "The membership type name is required.")]
        public MembershipTypeEnum MembershipTypeName { get; set; }

        /// <summary>
        /// Gets or sets the price associated with the membership type.
        /// </summary>
        [Required(ErrorMessage = "The price is required.")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the membership type is recurring.
        /// </summary>
        public bool IsRecurring { get; set; }

        /// <summary>
        /// Gets or sets the number of loyalty months required for the membership type.
        /// </summary>
        public int? LoyaltyMonths { get; set; }

        #endregion
    }

    #endregion
}
