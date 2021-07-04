using Entities.Entities;

namespace Entities.Contracts
{
    public interface IVendedorRepository : IBaseRepository<Vendedor>
    {
        public Vendedor ObterPorLogin(string login);
    }
}
