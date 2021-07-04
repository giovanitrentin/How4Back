using Embarque.Repositorio.Repositories;
using Entities.Contracts;
using Entities.Entities;

namespace Repository.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(Context context) : base(context)
        {
        }
    }
}
