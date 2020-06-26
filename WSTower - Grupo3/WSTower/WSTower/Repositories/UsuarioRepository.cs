using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// objeto contexto por onde os métodos do EF Core vão ser chamados
        /// </summary>
        WSTowerContext ctx = new WSTowerContext();

        public void AlteraSenha(string apelido, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(apelido);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Senha = senha;

                ctx.Usuario.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuarioAtualizado.Nome;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Apelido = usuarioAtualizado.Apelido;
                usuarioBuscado.Foto = usuarioAtualizado.Foto;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;

                ctx.Usuario.Update(usuarioBuscado);
                ctx.SaveChanges();
            }

        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            ctx.Usuario.FirstOrDefault(u => u.Id == id);

            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
            }

            return null;
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuario.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
            }

            return null;
        }
    }
}
