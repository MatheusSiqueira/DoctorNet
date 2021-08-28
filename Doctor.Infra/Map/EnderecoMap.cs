using Doctor.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Infra.Map
{
    class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(p => p.EnderecoId);
            builder.Property(p => p.EnderecoId).HasColumnName("endereco_id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
        }
    }
}
