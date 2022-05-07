using System.Threading.Tasks;
using Gadget.api.Data;
using Gadget.api.Data.Models;

namespace Gadget.api.Repository
{
    public class GadgetRepo : IGadgetRepo
    {
        private readonly AppDBContext _context;

        public GadgetRepo(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Gadgets> Create(Gadgets gadget)
        {
            gadget.CreatedDate = DateTime.Now;
            var response = await _context.Gadgets.AddAsync(gadget);
            _context.SaveChanges();
            return response.Entity;

        }
    }
}