using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SelecaoController : ControllerBase
    {
        SelecaoRepository SelecaoRepository = new SelecaoRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            //  return Ok(new { mensagem = "OK" });
            return Ok(SelecaoRepository.Listar());
        }

        [HttpGet ("{id}" )]
        public IActionResult BuscarPorId(int id)
        {
            Selecao selecao = SelecaoRepository.BuscarPorId(id);
            {
                if(selecao == null)
                {
                    return NotFound();
                }
                return Ok(selecao);
            }
        }

     // [HttpGet("Ordenacao/{ordem}")]
     // public IActionResult GetOrderBy(string ordem)
    //    {
      //      if(ordem != "ASC" && ordem != "DESC")
      //      {
       //         return BadRequest("Não é possivel ordenar a selecao.Por favor ordene por 'ASC' ou 'DESC");
      //      }
     //       return Ok(SelecaoRepository.ListarOrdenado(ordem));
     //   }
    }
}
