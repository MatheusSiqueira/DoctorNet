using Doctor.Domain.Model;
using Doctor.Infra.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Infra.Configuration
{
    public class ContextBdDoctor : DbContext
    {
        public ContextBdDoctor(DbContextOptions<ContextBdDoctor> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Cadastro> Cadastros { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CadastroMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }

    }

    
}
