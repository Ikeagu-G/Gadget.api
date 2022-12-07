using System.ComponentModel.DataAnnotations;

namespace Gadget.api.Data.Models
{
    public class LoginRequest
    {

      [Required]
       public string Username { get; set; } = string.Empty;
       
       
       [Required]
       public string Password { get; set; } = string.Empty;
    }
}