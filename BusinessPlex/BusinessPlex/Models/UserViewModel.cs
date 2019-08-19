using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPlex.Models
{
    public class UserViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter Username")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password minimum 6 character required")]
        public string Password { get; set; }
        
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password minimum 6 character required")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }

        public bool IsEmailVerified { get; set; }

        public Guid ActivationCode { get; set; }

        [StringLength(100)]
        public string ResetPasswordCode { get; set; }

        [Display(Name = "Remember me")]
        public bool Remember { get; set; }
    }
}