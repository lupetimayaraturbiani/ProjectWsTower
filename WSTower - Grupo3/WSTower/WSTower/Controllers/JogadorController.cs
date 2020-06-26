using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Interfaces;
using WSTower.Repositories;
using WSTower.Domains;


namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        JogadorRepository JogadorRepository = new JogadorRepository();

        

        [HttpGet]
        public IActionResult ListarTodos()
        {
            //  return Ok(new { mensagem = "OK" });
            return Ok(JogadorRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogador jogador = JogadorRepository.BuscarPorId(id);
            {
                if (jogador == null)
                {
                    return NotFound();
                }
                // return OK
                return Ok(jogador);
            }
        }

        [HttpGet ("nome/{jogador}")]
        public IActionResult BuscarPorNome(string jogador)
        {
            //Retorna os dados do jagador e um satus 200 - Ok
            return StatusCode(200, JogadorRepository.BuscarPorNome(jogador));
        }


        // Não consegui procura seleção por nome//

        // [HttpGet ("selecao/{nome }")]
        //  public IActionResult BuscarPorSeleção(string selecao)
        //  {

        //     return StatusCode(200, JogadorRepository.BuscarPorSeleção(selecao));
        //  }
    }
}
