using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WSTower.Contexts;
using WSTower.Domains;
using WSTower.Interfaces;

namespace WSTower.Repositories
{
    public class SelecaoRepository : ISelecaoRepository
    {
       // private string stringConexao = "Data Source=DESKTOP-L6GISEU\\SQLEXPRESS; initial catalog=Campeonato; user Id=sa; pwd=fabi2001";

        public List<Selecao> Listar()
        {
              using (WSTowerContext ctx = new WSTowerContext())
              {

                return ctx.Selecao.ToList();
             }


              //Tentei Fazer um INNER JOIN para mostar as informações do jogador, porém não consegui//


          //  List<Selecao> selecao = new List<Selecao>();

         //   using (SqlConnection con = new SqlConnection(stringConexao))
          //  {
               // string querySelectAll = "SELECT Selecao.Id, Selecao.Nome, Selecao.Bandeira, Selecao.Uniforme,  Selecao.Escalacao , Jogador.Id, Jogador.Nome, Jogador.Posicao, Jogador.Foto  FROM Selecao " +
                 //                       "INNER JOIN Jogador E ON Selecao.Id = Jogador.Id";

             //   con.Open();

              //  SqlDataReader rdr;

            //    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
             //   {
                  //  rdr = cmd.ExecuteReader();

                   // while (rdr.Read())
                  //  {
                      //  Selecao Selecao = new Selecao
                      //  {
                        //    Id = Convert.ToInt32(rdr["Id"])
                        //    ,
                        //    Nome = rdr["Nome"].ToString()
                        //    ,
                        //    Escalacao = rdr["Escalao"].ToString()
                            // ,
                           // Uniforme = Convert.ToByte["Uniforme"]()
                            // ,                        
                         //    Bandeira = Convert.ToByte(rdr["Bandeira"])
                         //   ,
                       //     Jogador = new Jogador
                      //      {
                     //           Id = Convert.ToInt32(rdr["Id"])
                    //            ,
                  //              Nome = rdr["Nome"].ToString()
                               //     ,
                              //    Foto.Convert.ToByte(rdr["Foto"])
                            //           }
                            //        };

                            //          selecao.Add(Selecao);
                            //        }
                            //     }
                            //  }
                            //  return selecao;

        }
        public Selecao BuscarPorId(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Selecao.FirstOrDefault(x => x.Id == id);
            }
        }

        // Tentei outra forma para lista seleção com jogador e nao consegui tbm 
       // public Selecao GetSelecao(string id)
      //  {
       //     StringBuilder str = new StringBuilder();
       //    str.Append(@"SELECT Selecao.id, Selecao.Nome, Selecao.Bandeira, Selecao.Uniforme, Selecao.Escalacao,
        //                Jogador.Nome, Jogador.Posicao, Jogador.Foto FROM Selecao LEFT JOIN Jogador ON Jogador.Id = Selecao.Id
        //                    WHERE Selecao.Id=@Id");

       //     IDataParameter sl = new SqlParameter();
       //     sl.DbType = DbType.Int64;
       //     sl.ParameterName = "@Id";
      //     sl.Value = int.Parse(id);
      //      sl.SourceColumn = "Id";
                                                                   
       //     var resultado = db.DataBase.SqlQuery(str.ToString(),sl)
      //  }
     }
  }