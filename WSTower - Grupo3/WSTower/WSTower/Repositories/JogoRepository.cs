using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;
using WSTower.Interfaces;

namespace WSTower.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        //private string stringConexao = "Data Source=LAPTOP-CAKD8JG2\\SQLEXPRESS; Initial Catalog=Campeonato; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        WSTowerContext ctx = new WSTowerContext();

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        public List<Jogo> Listar()
        {
            // Retorna uma lista com todas as informações dos jogos
            return ctx.Jogo.ToList();
        }

        /// <summary>
        /// Busca os jogos pela data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Jogo BuscarPorData(DateTime data)
        {
            // Retorna os jogos da data informada
            return ctx.Jogo.FirstOrDefault(j => j.Data == data);
        }

        /// <summary>
        /// Busca os jogos pelo nome de seleção da casa
        /// </summary>
        /// <param name="selecaoCasa"></param>
        /// <returns></returns>
        public Jogo BuscarPorSelecaoCasa(string selecaoCasa)
        {
            // Retorna os jogos da seleção informada
            return ctx.Jogo.FirstOrDefault(j => j.SelecaoCasaNavigation.Nome == selecaoCasa);
        }

        /// <summary>
        /// Busca os jogos pelao nome de delecao visitante
        /// </summary>
        /// <param name="selecaoVisitante"></param>
        /// <returns></returns>
        public Jogo BuscarPorSelecaoVisitante(string selecaoVisitante)
        {
            // Retorna os jogos da seleção informada
            return ctx.Jogo.FirstOrDefault(j => j.SelecaoVisitanteNavigation.Nome == selecaoVisitante);
        }

        /// <summary>
        /// Busca os jogos pelo nome de estádio
        /// </summary>
        /// <param name="estadio"></param>
        /// <returns></returns>
        public Jogo BuscarPorEstadio(string estadio)
        {
            // Retorna os jogos do estádio informado
            return ctx.Jogo.FirstOrDefault(j => j.Estadio == estadio);
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogo</returns>
        //public List<Jogo> ListarPorId()
        //{
        //    // Cria uma lista jogos onde serão armazenados os dados
        //    List<Jogo> jogos = new List<Jogo>();

        //    // Declara a SqlConnection passando a string de conexão
        //    using (SqlConnection con = new SqlConnection(stringConexao))
        //    {
        //        // Declara a instrução a ser executada
        //        string querySelectAll = "SELECT Jogo.Id, Selecao.Nome, Jogo.PlacarCasa, Jogo.PlacarVisitante, Selecao.Uniforme, " +
        //                                "Jogo.PenaltiCasa, Jogo.PenaltiVisitante, Jogo.Data, Jogo.Estadio, " +
        //                                "Jogador.Nome, Jogador.Foto, Jogador.NumeroCamisa, Jogador.Posicao" +
        //                                "FROM Jogo" +
        //                                "INNER JOIN Selecao ON Jogo.Id = Jogo.Id" +
        //                                "INNER JOIN Jogador ON Jogo.Id = Jogo.Id";

        //        // Abre a conexão com o banco de dados
        //        con.Open();

        //        // Declara o SqlDataReader para receber os dados do banco de dados
        //        SqlDataReader rdr;

        //        // Declara o SqlCommand passando o comando a ser executado e a conexão
        //        using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
        //        {
        //            // Executa a query e armazena os dados no rdr
        //            rdr = cmd.ExecuteReader();

        //            // Enquanto houver registros para serem lidos no rdr, o laço se repete
        //            while (rdr.Read())
        //            {
        //                // Instancia um objeto jogo
        //                Jogo jogo = new Jogo
        //                {
        //                    Id = Convert.ToInt32(rdr[0]),

        //                    Selecao.Nome = rdr["Nome"].ToString(),

        //                    PlacarCasa = Convert.ToInt32(rdr[0]),

        //                    PlacarVisitante = Convert.ToInt32(rdr[0]),

        //                    Selecao.Uniforme = Convert.ToByte(rdr[0]),

        //                    PenaltisCasa = Convert.ToInt32(rdr[0]),

        //                    PenaltisVisitante = Convert.ToInt32(rdr[0]),

        //                    Data = Convert.ToDateTime(rdr[0]),

        //                    Estadio = rdr["Estadio"].ToString(),

        //                    Jogador.Nome = rdr["Nome"].ToString(),

        //                    Jogador.Foto = Convert.ToByte(rdr[0]),

        //                    Jogador.NumeroCamisa = Convert.ToInt32(rdr[0]),

        //                    Jogador.Posicao = rdr["Posicao"].ToString(),
        //                };

        //                jogos.Add(jogo);
        //            }
        //        }
        //    }

        //    // Retorna a lista de jogos
        //    return jogos;
        //}
    }
}
