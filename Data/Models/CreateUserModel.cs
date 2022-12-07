using Gadget.api.ENUM;

namespace Gadget.api.Data.Models
{
    public class CreateUserModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserType UserType {get; set;}
        public string Email { get; set; } = string.Empty;
        
        //public List<string> roleName {get; set;}
    }

    public class GadgetUserResponseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } =  string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string roleName {get; set;}
    }
}