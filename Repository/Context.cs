using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Mapping;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContatoCliente> ContatoClientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Status> Statuss { get; set; }
        public DbSet<TipoContato> TipoContatos { get; set; }
        public DbSet<Vendedor> Vendedors { get; set; }

        public static string Conector()
        {
            return "HowIV";
            //return "Server=localhost;Database=SistemaGerenciamentoCliente;User Id=sa;Password=.Lidoni1991;";
        }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new AtividadeConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ContatoClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TipoContatoConfiguration());
            modelBuilder.ApplyConfiguration(new VendedorConfiguration());
        }
    }
}
