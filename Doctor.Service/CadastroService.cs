using Doctor.Dto;
using Doctor.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.Service
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroService _cadastroService;

        public CadastroService(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }
        public async Task<IEnumerable<DtoCadastro>> GetAll()
        {
            var dtolivros = await _cadastroService.GetAll();
            return dtolivros.Select(x => new DtoCadastro
            {
                CadastroId = x.CadastroId,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                Endereco = x.Endereco,
                NumeroEndereco = x.NumeroEndereco
            }).OrderBy(o => o.CadastroId);
        }
    }
}