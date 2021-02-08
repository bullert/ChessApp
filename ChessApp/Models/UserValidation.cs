using DataAccessLib;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class RegularExpressionMultipleAttribute : RegularExpressionAttribute
    {
        public RegularExpressionMultipleAttribute(string pattern) : base(pattern)
        {
            
        }
    }

    public class UserValidation
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(4, ErrorMessage = "Username must be at least 4 characters long")]
        [MaxLength(20, ErrorMessage = "Username must be at most 20 characters long")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", 
            ErrorMessage = "Username must consist only of letters, digits and underscore")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [MaxLength(100, ErrorMessage = "Password must be at most 100 characters long")]
        [RegularExpression("^[a-zA-Z0-9 !\"#$%&'()*+,-./\\\\:;<=>?@\\[\\]^_`{|}~]*$", 
            ErrorMessage = "Password must consist only of letters, digits, special characters and space")]
        [RegularExpressionMultipleAttribute("^.*[a-z]+.*$", 
            ErrorMessage = "Password must contain at least one small letter")]
        [RegularExpressionMultipleAttribute("^.*[A-Z]+.*$", 
            ErrorMessage = "Password must contain at least one capital letter")]
        [RegularExpressionMultipleAttribute("^.*[0-9]+.*$", 
            ErrorMessage = "Password must contain at least one digit")]
        [RegularExpressionMultipleAttribute("^.*[!\"#$%&'()*+,-./\\\\:;<=>?@\\[\\]^_`{|}~]+.*$", 
            ErrorMessage = "Password must contain at least one special character")]
        public string Password { get; set; }
    }
}
