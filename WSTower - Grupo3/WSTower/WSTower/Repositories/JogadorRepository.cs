using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSTower.Contexts;
using WSTower.Domains;
using WSTower.Interfaces;

namespace WSTower.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        WSTowerContext ctx = new WSTowerContext();

        public List<Jogador> Listar()
        {
           
             return ctx.Jogador.ToList();
            
        }

  

        public Jogador BuscarPorId(int id)
        {
           //Retorna os jogadores buscados por Id
            return ctx.Jogador.FirstOrDefault(j => j.Id == id);
           
        }

        public Jogador BuscarPorNome(string nome)
        {
           // Retorna os jogadores por nome 
           return ctx.Jogador.FirstOrDefault(j => j.Nome == nome);
            
        }

       // public Jogador BuscarPorSeleção(string selecao)
       // {
      //      return ctx.Jogador.FirstOrDefault(j => j.Nome == selecao);
      //  }
    }
}
