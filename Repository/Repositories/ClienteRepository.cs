using Embarque.Repositorio.Repositories;
using Entities.Contracts;
using Entities.Entities;

namespace Repository.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Context context) : base(context)
        {
        }
    }
}
