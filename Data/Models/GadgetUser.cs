using Gadget.api.ENUM;

namespace Gadget.api.Data.Models
{
    public class GadgetUser : BaseEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserType UserType {get; set;}
        public string? Email { get; set; }
    }
}