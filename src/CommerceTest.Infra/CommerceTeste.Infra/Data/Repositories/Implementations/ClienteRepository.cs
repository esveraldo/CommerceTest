using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Context;
using CommerceTeste.Infra.Data.Repositories.Contracts;

namespace CommerceTeste.Infra.Data.Repositories.Implementations
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
