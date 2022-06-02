using Gadget.api.ENUM;
using Microsoft.AspNetCore.Identity;

namespace Gadget.api.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        public Status Status { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset DateCreated{get; set;}
    }
}