using Doctor.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Infra.Map
{
    class CadastroMap : IEntityTypeConfiguration<Cadastro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cadastro> builder)
        {
            builder.ToTable("Cadastro");
            builder.HasKey(p => p.CadastroId);
            builder.Property(p => p.CadastroId).HasColumnName("cadastro_id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.Senha).HasColumnName("senha").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento").IsRequired();
            builder.Property(x => x.NumeroEndereco).HasColumnName("nu_endereco").IsRequired();
            builder.Property(x => x.EnderecoId).HasColumnName("endereco_id").IsRequired();
            builder.HasOne(x => x.Endereco).WithMany().HasForeignKey(x => x.EnderecoId);
        }
    }
}
