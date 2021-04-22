using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please Enter Your emil")]
        [Display(Name="Email :")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter a strong password")]
        [Display(Name = "Password :")]
        [Compare("ConfirmPassword", ErrorMessage ="Password do not match")]
        [DataType(DataType.Password)]
        public string Password  { get; set; }

        [Required(ErrorMessage = "Please Confirm your password")]
        [Display(Name = "Confirm Password : :")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
