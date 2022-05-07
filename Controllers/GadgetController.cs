using Gadget.api.Data.Models;
using Gadget.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gadget.api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetController : ControllerBase
    {
        private readonly IGadgetRepo _repo;

        public GadgetController(IGadgetRepo repo)
        {
            _repo = repo;
        }


        [HttpPost("create")]
        public ActionResult<Gadgets> Create(Gadgets gadget)
        {
            var result = _repo.Create(gadget);
            return Ok(result);
        }
    }
}