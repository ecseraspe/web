using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines Type WebContactModel
    /// </summary>
    public class WebContactModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>
        /// The email identifier.
        /// </value>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailId { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the return message.
        /// </summary>
        /// <value>
        /// The return message.
        /// </value>
        public string ReturnMessage { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }
    }
}
