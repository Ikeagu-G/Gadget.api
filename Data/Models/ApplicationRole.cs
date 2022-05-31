using Gadget.api.ENUM;

namespace Gadget.api.Data.Models
{
    public class ApplicationRole
    {
        public Status Status { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset DateCreated{get; set;}
    }
}