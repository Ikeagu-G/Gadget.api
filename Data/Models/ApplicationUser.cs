using Gadget.api.ENUM;

namespace Gadget.api.Data.Models
{
    public class ApplicationUser
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public string CreatedById { get; set; }
        public string CreatedBy { get; set;}
    }

}