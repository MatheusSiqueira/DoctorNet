using Doctor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Dto
{
    public class DtoCadastro
    {
        public long CadastroId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NumeroEndereco { get; set; }
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
