using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.IdentityModel.Tokens;
using WSTower.Domains;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Algo deu errado");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Usuario uBuscado = _usuarioRepository.BuscarPorId(id);

                if (uBuscado != null)
                {
                    return Ok(uBuscado);
                }

                return NotFound("Não foi encontrado nenhum usuário com identificador informado");
            }
            catch (Exception)
            {
                return BadRequest("Algo deu errado");
            }
        }

        public bool isNameValid;
        public bool isNickNameValid;
        public bool isPasswordValid;
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            //List<Usuario> usuarios = _usuarioRepository.Listar();
            //string pattern = "[Aa][a,z]{3,}";
            //isNameValid = Regex.IsMatch(novoUsuario.Nome, pattern);
            //isNickNameValid = Regex.IsMatch(novoUsuario.Apelido, pattern);
            //isPasswordValid = Regex.IsMatch(novoUsuario.Senha, pattern);

            if (novoUsuario != null)
            {
                //if (isNameValid == true)
                //{
                //    //if (!usuarios.Contains(novoUsuario.Email.))
                //    //{

                //    //}

                //    if (isNickNameValid == true)
                //    {
                //        if (isPasswordValid == true)
                //        {
                           _usuarioRepository.Cadastrar(novoUsuario);

                            return StatusCode(201);
                //        }

                //        return BadRequest("A senha deve conter pelo menos 3 caracteres");
                //    }

                //    return BadRequest("O apelido deve conter pelo menos 3 caracteres");
                //}

                //return BadRequest("O nome deve conter pelo menos 3 caracteres");
            }

            return BadRequest("Não foi possível cadastrar o usuário");
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado == null)
                {
                    return NotFound("Nenhum usuário com o identificador fornecido foi encontrado");

                }

                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception)
            {
                return BadRequest("Algo deu errado");
            }
        }

        [HttpPut]
        public IActionResult PutPassword(string apelido, string senha)
        {
            if (senha != null)
            {

                try
                {
                    _usuarioRepository.AlteraSenha(apelido, senha);

                    return StatusCode(204);
                }
                catch (Exception)
                {

                    return BadRequest("Não foi possíivel alterar a senha");
                }
            }

            return NotFound("A nova senha precisa ser informada");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Usuario uBuscado = _usuarioRepository.BuscarPorId(id);

                if (uBuscado != null)
                {
                    _usuarioRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("O usuário não pôde ser deletado pois ele não existe!");
            }
            catch (Exception)
            {
                return BadRequest("Algo deu errado");
            }
        }
    }
}
