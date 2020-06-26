using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Interfaces;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class JogoController : Controller
    {
        /// <summary>
        /// Cria um objeto _jogoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IJogoRepository _jogoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code 200 - Ok</returns>
        /// dominio/api/Jogo
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_jogoRepository.Listar());
        }

        /// <summary>
        /// Busca um jogo através da data
        /// </summary>
        /// <param name="data">Data do jogo que será buscado</param>
        /// <returns>a data de um jogo buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Jogo/ByDate/00-00-0000
        //[Authorize(Roles = "1")]
        [HttpGet("ByDate/{data}")]
        public IActionResult ByDate(DateTime data)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _jogoRepository.BuscarPorData(data));
        }

        /// <summary>
        /// Busca um jogo através do nome selecaoCasa
        /// </summary>
        /// <param name="selecaoCasa">Jogo que será buscado pelo nome SelecaoCasa</param>
        /// <returns>Jogo buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Jogo/NomeSelecaoCasa
        //[Authorize(Roles = "1")]
        [HttpGet("ByNameSelecaoCasa/{selecaoCasa}")]
        public IActionResult ByNameSelecaoCasa(string selecaoCasa)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _jogoRepository.BuscarPorSelecaoCasa(selecaoCasa));
        }

        /// <summary>
        /// Busca um jogo através do nome selecaoVisitante
        /// </summary>
        /// <param name="selecaoVisitante">Jogo que será buscado pelo nome selecaoVisitante</param>
        /// <returns>Jogo buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Jogo/NomeSelecaoVisitante
        //[Authorize(Roles = "1")]
        [HttpGet("ByNameSelecaoVisitante/{selecaoVisitante}")]
        public IActionResult ByNameSelecaoVisitante(string selecaoVisitante)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _jogoRepository.BuscarPorSelecaoVisitante(selecaoVisitante));
        }

        /// <summary>
        /// Busca um jogo através do nome estadio
        /// </summary>
        /// <param name="estadio">Jogo que será buscado pelo nome estadio</param>
        /// <returns>Jogo buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Jogo/NomeEstadio
        //[Authorize(Roles = "1")]
        [HttpGet("ByNameEstadio/{estadio}")]
        public IActionResult ByNameEstadio(string estadio)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _jogoRepository.BuscarPorEstadio(estadio));
        }

        ///// <summary>
        ///// Busca uma consulta através do seu ID
        ///// </summary>
        ///// <param name="id">ID da consulta que será buscada</param>
        ///// <returns>Uma consulta buscada ou NotFound caso nenhuma seja encontrada</returns>
        ///// dominio/api/Consulta/1
        ////[Authorize(Roles = "1")]
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    // Retorna os dados buscados e um status code 200 - Ok
        //    return StatusCode(200, _jogoRepository.ListarPorId(id));
        //}
    }
}
