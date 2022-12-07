using AutoMapper;
using Gadget.api.Data.Models;

namespace Gadget.api.Repository
{
    public class Profiles : Profile
    {
        public Profiles()
        {
                    //source                destination
            CreateMap<CreateUserModel, GadgetUserResponseModel>();
            CreateMap<ApplicationUser, GadgetUserResponseModel>();
            CreateMap<ApplicationUser, GadgetUser>();
            
        }
        
    }
}