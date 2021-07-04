using Embarque.Repositorio.Repositories;
using Entities.Contracts;
using Entities.Entities;

namespace Repository.Repositories
{
    public class TipoContatoRepository : BaseRepository<TipoContato>, ITipoContatoRepository
    {
        public TipoContatoRepository(Context context) : base(context)
        {
        }
    }
}
