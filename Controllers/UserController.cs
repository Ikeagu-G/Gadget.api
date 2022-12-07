using Gadget.api.Data.Models;
using Gadget.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gadget.api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IGadgetUserRepo _userRepo;

        public UserController(IGadgetUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("createuser")]
        public ActionResult<GadgetUserResponseModel> CreateUser(CreateUserModel model)
        {
            var result = _userRepo.CreateUser(model);
            return Ok(result);
        }
    }
}