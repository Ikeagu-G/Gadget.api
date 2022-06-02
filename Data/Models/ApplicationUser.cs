using Gadget.api.ENUM;
using Microsoft.AspNetCore.Identity;

namespace Gadget.api.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public Status Status { get; set; }
        public string? CreatedById { get; set; }
        public string? CreatedBy { get; set;}
        public DateTime DateCreated { get; set; }
    }

}