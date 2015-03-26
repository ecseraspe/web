using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Resources.ViewModel
{
    public class WebForgotPasswordModel
    {
        [Required(ErrorMessage = "The Email Field is reuired.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string ErrorMessage { get; set; }
    }
}
