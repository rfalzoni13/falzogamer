using AutoMapper;
using FalzoGamer.Api.Models;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace FalzoGamer.Api.Controllers
{
    /// <summary>
    /// Controller UsuarioController
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppServico _usuarioAppServico;
        
        /// <summary>
        /// Construtor UsuarioController que gera as interfaces _usuarioAppServico,
        /// _acessoAppServico e os Identity Managers
        /// </summary>
        /// <param name="usuarioAppServico"></param>
        public UsuarioController(IUsuarioAppServico usuarioAppServico)
        {
            _usuarioAppServico = usuarioAppServico;
        }

        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém a lista completa de usuários da Api
        /// </remarks>
        /// <returns></returns>
        //GET api/usuario/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            try
            {
                var usuarios = _usuarioAppServico.BuscarTodos();

                if (usuarios != null && usuarios.Count() > 0)
                {
                    return Ok(usuarios);
                }
                else
                {
                    return NotFound(new { Status = HttpStatusCode.NotFound,
                    Message = "Nenhum registro encontrado!" });
                }
            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Listar usuário pelo Id
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém o usuário através do seu Id
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        //GET api/usuario/BuscarPorId?id={id}
        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId([FromQuery] int id)
        {
            try
            {
                var usuario = _usuarioAppServico.BuscarPorId(id);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound(new { Status = HttpStatusCode.NotFound,
                    Message = "Nenhum registro encontrado!" });
                }
            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Inserir usuário
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Insere um novo usuário na base
        /// </remarks>
        /// <param name="usuarioModel">Objeto do usuário</param>
        /// <returns></returns>
        //POST api/usuario/Inserir
        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir([FromBody] UsuarioModel usuarioModel)
        {   
            try
            {
                usuarioModel.Created = DateTime.Now;

                usuarioModel.Novo = true;

                var usuario = Mapper.Map<UsuarioModel, Usuario>(usuarioModel);

                _usuarioAppServico.Adicionar(usuario);

                return Ok("Usuário inserido com sucesso!");

            }
            catch(Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Atualizar usuário
        /// </summary>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Atualiza o usuário na base
        /// </remarks>
        /// <param name="usuarioModel">Objeto do usuário</param>
        /// <returns></returns>
        //PUT api/usuario/Atualizar
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                usuarioModel.Modified = DateTime.Now;

                usuarioModel.Novo = false;

                var usuario = Mapper.Map<UsuarioModel, Usuario>(usuarioModel);

                _usuarioAppServico.Atualizar(usuario);

                return Ok("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Excluir usuário
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Exclui o usuário da base
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        //DELETE api/usuario/Excluir
        [HttpDelete]
        [Route("Excluir")]
        public IActionResult Excluir([FromQuery] int id)
        {
            try
            {
                var usuario = _usuarioAppServico.BuscarPorId(id);

                if(usuario != null)
                {
                    _usuarioAppServico.Apagar(usuario);

                    return Ok("Usuário apagado com sucesso!");
                }
                else
                {
                    return NotFound(new { Status = HttpStatusCode.NotFound,
                    Message = "Nenhum registro encontrado!" });
                }

            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }
    }
}