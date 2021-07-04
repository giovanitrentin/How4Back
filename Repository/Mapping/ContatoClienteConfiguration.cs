using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    class ContatoClienteConfiguration : IEntityTypeConfiguration<ContatoCliente>
    {
        public void Configure(EntityTypeBuilder<ContatoCliente> builder)
        {
            builder.ToTable("ContatoCliente", "dbo");

            // Set key for entity
            builder.HasKey(p => p.Id);
        }
    }
}
