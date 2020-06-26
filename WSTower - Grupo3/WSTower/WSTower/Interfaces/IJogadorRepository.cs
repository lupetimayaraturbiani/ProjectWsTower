using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;

namespace WSTower.Interfaces
{
    interface IJogadorRepository
    {
        //Lista de jogadores
        List<Jogador> Listar();

        //Buscar  um jogador por nome
        Jogador BuscarPorNome(string jogador);


    //    Jogador BuscarPorSeleção(string nome);
    }
}
