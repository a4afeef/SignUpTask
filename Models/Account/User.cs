using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpTask.Models.Account
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid First Name.")]
        [StringLength(12, ErrorMessage = "First name must not exceed 12 characters.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid First Name.")]
        [StringLength(16, ErrorMessage = "Last name must not exceed 16 characters.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please enter valid Email.")]
        [Remote(action: "IsEmailExists", controller: "Account", ErrorMessage = "Email is already registered!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be 8 characters with at least one uppercase letter, one lowercase letter, one number and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Confirm Password do not match password.")]
        public string ConfirmPassword { get; set; }
    }
}
