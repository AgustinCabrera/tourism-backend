using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace tourismApp.Views.Home
{
    public class loginModel : PageModel
    {
        [Required]
        [EmailAddress]
        public required string LoginUser { get; set; }
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
