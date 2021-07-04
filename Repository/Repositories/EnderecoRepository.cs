using Embarque.Repositorio.Repositories;
using Entities.Contracts;
using Entities.Entities;

namespace Repository.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(Context context) : base(context)
        {
        }
    }
}
