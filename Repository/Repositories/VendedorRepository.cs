using Embarque.Repositorio.Repositories;
using Entities.Contracts;
using Entities.Entities;
using System.Linq;

namespace Repository.Repositories
{
    public class VendedorRepository : BaseRepository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(Context context) : base(context)
        {
        }

        public Vendedor ObterPorLogin(string login)
        {
            return _context.Vendedors.FirstOrDefault(l => l.Login.Equals(login));
        }
    }
}
