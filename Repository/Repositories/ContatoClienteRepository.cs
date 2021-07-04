using Embarque.Repositorio.Repositories;
using Entities.Contracts;
using Entities.Entities;

namespace Repository.Repositories
{
    public class ContatoClienteRepository : BaseRepository<ContatoCliente>, IContatoClienteRepository
    {
        public ContatoClienteRepository(Context context) : base(context)
        {
        }
    }
}
