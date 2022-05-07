using Gadget.api.Data.Models;

namespace Gadget.api.Repository
{
    public interface IGadgetRepo
    {
        Task<Gadgets> Create(Gadgets gadget);
    }
}