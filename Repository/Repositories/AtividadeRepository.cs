using Embarque.Repositorio.Repositories;
using Entities.Contracts;
using Entities.Entities;

namespace Repository.Repositories
{
    public class AtividadeRepository : BaseRepository<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository(Context context) : base(context)
        {
        }
    }
}
