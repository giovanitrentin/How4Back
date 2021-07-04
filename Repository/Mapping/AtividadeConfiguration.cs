using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Mapping
{
    class AtividadeConfiguration : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("Atividade", "dbo");

            // Set key for entity
            builder.HasKey(p => p.Id);
        }
    }
}
