using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;

namespace WSTower.Repositories
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns></returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuário por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="novoUsuario"></param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Edita usuários existentes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// valida o usuário
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Altera a senha do usuário
        /// </summary>
        /// <param name="senha"></param>
        void AlteraSenha(string apelido, string senha);
    }
}
