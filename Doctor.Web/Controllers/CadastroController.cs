using Doctor.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : Controller
    {
        private readonly ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpGet]
        [Route("GetCadastros")]

        public async Task<IEnumerable<DtoCadastro>>
    }
}

