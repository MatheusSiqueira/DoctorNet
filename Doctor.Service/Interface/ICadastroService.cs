using Doctor.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Service.Interface
{
    public interface ICadastroService
    {
        public Task<IEnumerable<DtoCadastro>> GetAll();
    }
}
