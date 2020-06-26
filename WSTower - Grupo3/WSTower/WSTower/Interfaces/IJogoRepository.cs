using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;

namespace WSTower.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista dos jogos</returns>
        List<Jogo> Listar();

        /// <summary>
        /// Busca um jogo pela data
        /// </summary>
        /// <param name="Data"></param>
        /// <returns>O jogo buscado pela data</returns>
        Jogo BuscarPorData(DateTime data);

        /// <summary>
        /// Busca um jogo pelo nome da selecaoCasa
        /// </summary>
        /// <param name="selecaoCasa"></param>
        /// <returns>O jogo buscado pelo nome da selecaoCasa</returns>
        Jogo BuscarPorSelecaoCasa(string selecaoCasa);

        /// <summary>
        /// Busca um jogo pelo nome da selecaoVisitante
        /// </summary>
        /// <param name="selecaoVisitante"></param>
        /// <returns>O jogo buscado pelo nome da selecaoVisitante</returns>
        Jogo BuscarPorSelecaoVisitante(string selecaoVisitante);

        /// <summary>
        /// Busca um jogo pelo nome do estadio
        /// </summary>
        /// <param name="estadio"></param>
        /// <returns>O jogo buscado pelo nome do estadio</returns>
        Jogo BuscarPorEstadio(string Estadio);

        ///// <summary>
        ///// /Lista as informações de jogos/confrontos
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Jogo ListarPorId(int id);
    }
}
