using Gadget.api.ENUM;
using Microsoft.AspNetCore.Identity;

namespace Gadget.api.Data.Models
{
    public class ApplicationUser : IdentityUser, IBaseEntity
    {
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string CreatedById { get; set; } = string.Empty;
        public string CreatedBy { get; set; }  = string.Empty;
        public DateTime DateCreated { get; set; }
    }

    public class BaseEntity : IBaseEntity
    {
        public string CreatedById { get; set; } = string.Empty;
        public string CreatedBy { get; set;} = string.Empty;
        public DateTime DateCreated { get; set; }
    }

    public interface IBaseEntity
    {
        string CreatedById { get; set; }
        string CreatedBy { get; set;}
        DateTime DateCreated { get; set; }
    }

}